using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Data;

namespace Application.Interfaces.Services
{
    public interface IGardenService
    {
        // Task<GardensRecommendationsModel> GetAllByUserId(int userId);

        Task<UpdateModel> GetData(int userId);
        Task<UpdateModel> SetData(UpdateModel updateModel);
    }
}
