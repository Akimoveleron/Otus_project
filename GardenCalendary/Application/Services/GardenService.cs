using Accuweather.Core.Models;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Application.Services
{

    public class GardenService : IGardenService
    {
        private readonly IGardenCalendaryContext _context;
        
        public GardenService(IGardenCalendaryContext context)
        {
            _context = context;
        }

        public async Task<UpdateModel> GetData(int userId)
        {
            var data = new UpdateModel();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                throw new NullReferenceException("Пользователь не найден");

            data.UserId = userId;

            data.Gardens = new List<Domain.Models.Data.GardenModel>();
            foreach (var userGarden in await _context.UserGardens.Where(g => g.UserId == userId).ToListAsync())
            {
                var garden = await _context.Gardens.FirstOrDefaultAsync(g => g.Id == userGarden.GardenId);
                if (garden is null)
                    continue;

                var region = await _context.RReestrObjects.FirstOrDefaultAsync(r => r.Id == garden.ObjectId);
                if (region is null)
                    continue;
                
                var gardenModel = new Domain.Models.Data.GardenModel()
                {
                    Name = garden.Name,
                    Id = garden.Id,
                    UserGardenId = userGarden.Id,
                    Plants = new List<PlantModel>(),
                    Region = new RegionModel()
                    {
                        Id = region.Id,
                        Name = region.Name ?? "",
                        accuweatherId = region.AccuweatherId
                    }
                };

                foreach (var plantInGarden in await _context.PlantsInGarden.Where(p => p.GardenId == garden.Id).ToListAsync())
                {
                    var plant = await _context.RPlants.FirstOrDefaultAsync(p => p.Id == plantInGarden.RPlantId);
                    if (plant is null)
                        continue;

                    var plantModel = new PlantModel()
                    {
                        Id = plant.Id,
                        PlantInGardenId = plantInGarden.Id,
                        Name = plant.Name,
                    };
                    
                    gardenModel.Plants.Add(plantModel);
                }

                await GetRecommendation(gardenModel);
                
                data.Gardens.Add(gardenModel);
            }
            return data;
        }
        
        public async Task<UpdateModel> SetData(UpdateModel updateModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updateModel.UserId);
            if (user is null)
                throw new NullReferenceException(nameof(user));
            
            // Id огородов которые есть на фронте и есть в бозе
            var gardenIds = updateModel.Gardens.Where(g => g.UserGardenId.HasValue).Select(g => g.UserGardenId).ToList();
            
            // Id огородов которые есть в бозе но нет у пользователя на фронте
            var gardenToRemove = await _context.UserGardens.Where(g => g.UserId == updateModel.UserId && !gardenIds.Contains(g.Id)).ToListAsync();
            
            // Если таковые есть
            if (gardenToRemove.Any())
            {
                foreach (var userGarden in await _context.UserGardens.Where(g => g.UserId == updateModel.UserId && !gardenIds.Contains(g.Id)).ToListAsync())
                {
                    if (userGarden.Garden is not null)
                        _context.Gardens.Remove(userGarden.Garden);
            
                    _context.UserGardens.Remove(userGarden);
                }
            
                _context.SaveChanges();
            }

            // Создаем тех которых нет и обновляем те что есть
            foreach (var gardenModel in updateModel.Gardens)
            {
                // Создаем огород
                if (gardenModel.UserGardenId.HasValue == false)
                {
                    var garden = await _context.Gardens.AddAsync(new Garden()
                    {
                        Name = gardenModel.Name,
                        ObjectId = gardenModel.Region.Id,
                        PlantsInGarden = new List<PlantInGarden>(),
                    });

                    _context.SaveChanges();

                    foreach (var plantModel in gardenModel.Plants)
                    {
                        var plant = await _context.RPlants.FirstOrDefaultAsync(p => p.Id == plantModel.Id);
                        if (plant is null)
                            continue;
                        
                        var plantsInGarde = await _context.PlantsInGarden.AddAsync(new PlantInGarden()
                        {
                            Garden = garden.Entity,
                            Plant = plant,
                            GardenId = garden.Entity.Id,
                            RPlantId = plant.Id,
                        });

                        _context.SaveChanges();
                    }

                    await _context.UserGardens.AddAsync(new UserGarden()
                    {
                        Garden = garden.Entity,
                        GardenId = garden.Entity.Id,
                        UserId = updateModel.UserId,
                        User = user
                    });
                    
                    _context.SaveChanges();
                }
                
                // Обновляем огород
                else
                {
                    var garden = await _context.Gardens.FirstOrDefaultAsync(g => g.Id == gardenModel.Id);
                    if (garden is null)
                        continue;
                    
                    // Удаляем растения
                    var ids = gardenModel.Plants
                        .Where(p => p.PlantInGardenId.HasValue)
                        .Select(p => p.PlantInGardenId)
                        .ToList();
                
                    // Id посаженных растений в огороде из базы которых нет в таблице на фронте
                    var plantInGardens = await _context.PlantsInGarden.Where(p => !ids.Contains(p.Id) && p.GardenId == garden.Id).ToListAsync();
                    if (plantInGardens.Any())
                    {
                        foreach (var plantInGarden in plantInGardens)
                            _context.PlantsInGarden.Remove(plantInGarden);
                
                        _context.SaveChanges();
                    }
                    
                    // Добавляем растения (если нет ключа связи с огородом считаем что он не посажен)
                    foreach (var plantModel in gardenModel.Plants.Where(p => !p.PlantInGardenId.HasValue))
                    {
                        var plant = await _context.RPlants.FirstOrDefaultAsync(p => p.Id == plantModel.Id);
                        if (plant is null)
                            continue;
                            
                        await _context.PlantsInGarden.AddAsync(new PlantInGarden()
                        {
                            
                            GardenId = garden.Id,
                            RPlantId = plant.Id,
                            Plant = plant
                        });
                
                        _context.SaveChanges();
                    }
                }

                await GetRecommendation(gardenModel);
            }

            return updateModel;
        }

        private async Task GetRecommendation(Domain.Models.Data.GardenModel gardenModel)
        {
            //foreach (var gardenModelPlant in gardenModel.Plants)
            //    gardenModelPlant.Recommendation = "Какая то рекомендация";

            //// Посмотреть почему не работает
            //return;

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7162/Recommendation/GardenId?gardenId={gardenModel.Id}");
            if (response.IsSuccessStatusCode)
            {
                var recommendationModels = JsonConvert.DeserializeObject<List<RecommendationModel>>(await response.Content.ReadAsStringAsync());
                if (recommendationModels is not null)
                {
                    foreach (var recommendationModel in recommendationModels)
                    {
                        var plantInGarden = gardenModel.Plants.FirstOrDefault(p => p.PlantInGardenId == recommendationModel.PlantInGardenId);
                        if (plantInGarden is not null)
                        {
                            var recommendation = string.Empty;

                            if (!string.IsNullOrWhiteSpace(recommendationModel.Planting))
                                recommendation += recommendationModel.Planting;

                            if (!string.IsNullOrWhiteSpace(recommendationModel.Watering))
                                recommendation += recommendationModel.Watering;

                            if (!string.IsNullOrWhiteSpace(recommendationModel.Hoeing))
                                recommendation += recommendationModel.Hoeing;

                            if (!string.IsNullOrWhiteSpace(recommendationModel.Loosing))
                                recommendation += recommendationModel.Loosing;

                            if (!string.IsNullOrWhiteSpace(recommendationModel.Weeding))
                                recommendation += recommendationModel.Weeding;

                            plantInGarden.Recommendation = recommendation;
                        }
                    }
                }
            }
        }

        // public async Task<CreateGardenModel> CreateGarden(CreateGardenModel createGardenModel)
        // {
        //     var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == createGardenModel.UserId);
        //     if (user is null)
        //         throw new NullReferenceException("Пользователь не найден");
        //
        //     var garden = await _context.Gardens.AddAsync(new Garden()
        //     {
        //         Name = createGardenModel.Name,
        //         ObjectId = createGardenModel.RegionId,
        //         PlantsInGarden = new List<PlantInGarden>(),
        //     });
        //
        //     _context.SaveChanges();
        //
        //     await _context.UserGardens.AddAsync(new UserGarden()
        //     {
        //         GardenId = garden.Entity.Id,
        //         UserId = user.Id,
        //         User = user
        //     });
        //
        //     _context.SaveChanges();
        //
        //     createGardenModel.Id = garden.Entity.Id;
        //     return createGardenModel;
        // }
        //
        // public async Task DeleteGarden(int gardenId)
        // {
        //     var garden = await _context.Gardens.FirstOrDefaultAsync(g => g.Id == gardenId);
        //     if (garden is not null)
        //     {
        //         var userGarden = await _context.UserGardens.FirstOrDefaultAsync(g => g.GardenId == gardenId);
        //         if (userGarden is not null)
        //         {
        //             _context.UserGardens.Remove(userGarden);
        //             _context.SaveChanges();
        //         }
        //         
        //         _context.Gardens.Remove(garden);
        //         _context.SaveChanges();
        //     }
        // }
        //
        // public async Task AddPlant(PlantToGardenModel model)
        // {
        //     var garden = await _context.Gardens.FirstOrDefaultAsync(g => g.Id == model.GardenId);
        //     if (garden is null)
        //         throw new NullReferenceException(nameof(garden));
        //
        //     var plant = await _context.RPlants.FirstOrDefaultAsync(p => p.Id == model.PlantId);
        //     if (plant is null)
        //         throw new NullReferenceException(nameof(plant));
        //
        //     var plantInGarden = await _context.PlantsInGarden.AddAsync(new PlantInGarden()
        //     {
        //         GardenId = garden.Id,
        //         Plant = plant,
        //     });
        //
        //     _context.SaveChanges();
        //     
        //     var httpClient = new HttpClient();
        //     
        //     var response = await httpClient
        //         .GetAsync($"https://localhost:7162/Recommendation/GetRecommendationByPlantId" +
        //                   $"/GardenId?gardenId={model.GardenId}&plantId={model.PlantId}");
        //     
        //     response.EnsureSuccessStatusCode();
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var recom = JsonConvert.DeserializeObject<RecommendationModel>(await response.Content.ReadAsStringAsync())!;
        //     }
        // }
        //
        // public async Task RemovePlantInGarden(PlantToGardenModel model)
        // {
        //     var garden = await _context.Gardens.FirstOrDefaultAsync(g => g.Id == model.GardenId);
        //     if (garden is null)
        //         throw new NullReferenceException(nameof(garden));
        //     
        //     var plant = await _context.PlantsInGarden.FirstOrDefaultAsync(p => p.Id == model.PlantId);
        //     if (plant is null)
        //         throw new NullReferenceException(nameof(plant));
        //
        //     _context.PlantsInGarden.Remove(plant);
        //     _context.SaveChanges();
        // }

        // public async Task<GardensRecommendationsModel> GetAllByUserId(int userId)
        // {
        //     var httpClient = new HttpClient();
        //     var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //     if (user is null)
        //     {
        //         throw new NullReferenceException("Пользователь не найден");
        //     }
        //
        //     var gardens = await _context.UserGardens.Where(x => x.UserId == userId)
        //         .Include(x => x.Garden)
        //         .ThenInclude(x => x.PlantsInGarden)
        //         .ThenInclude(x => x.Plant)
        //         .Select(x => x.Garden)
        //         .ToListAsync();
        //     
        //     var resModel = new GardensRecommendationsModel();
        //     resModel.UserId = userId;
        //     resModel.Gardens = new List<GardensModel>();
        //     foreach (var garden in gardens)
        //     {
        //         var city = await _context.RReestrObjects.FirstOrDefaultAsync(x => x.Id == garden!.ObjectId);
        //         if (city is null)
        //         {
        //             throw new Exception("Не найден такой город в БД");
        //         }
        //
        //         var gardenModel = new GardensModel()
        //         {
        //             Id = garden!.Id,
        //             Name = garden.Name,
        //             CityName = city!.Name!,
        //             PlantsWithRecommendations = new()
        //         };
        //         
        //         foreach (var plant in garden.PlantsInGarden)
        //         {
        //             var response = await httpClient
        //                 .GetAsync($"https://localhost:7162/Recommendation/GetRecommendationByPlantId" +
        //                           $"/GardenId?gardenId={gardenModel.Id}&plantId={plant.RPlantId}");
        //             response.EnsureSuccessStatusCode();
        //             // Получение ответа и извлечение имени города
        //             string recommendation = await response.Content.ReadAsStringAsync();
        //
        //             var thisPlant = plant.Plant;
        //             var plantWithRecommendation = new PlantWithRecommendations();
        //             plantWithRecommendation.Id = plant.Id;
        //             plantWithRecommendation.Name = thisPlant!.Name;
        //             plantWithRecommendation.RPlantId = plant.RPlantId;
        //             plantWithRecommendation.Recommendation = JsonConvert.DeserializeObject<RecommendationModel>(recommendation)!;
        //             gardenModel.PlantsWithRecommendations.Add(plantWithRecommendation);
        //         }
        //         resModel.Gardens.Add(gardenModel);
        //     }
        //     return resModel;
        // }
    }
}