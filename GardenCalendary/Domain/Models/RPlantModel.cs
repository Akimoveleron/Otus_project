using Domain.BaseEntites;

namespace Domain.Models
{
    /// <summary>
    /// Растение
    /// </summary>
    public class RPlantModel : BaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } // сорт растения

        /// <summary>
        /// Номера месяцев для высаживания
        /// </summary>
        public int[] NumberMonthsForPlanting { get; set; } 

        /// <summary>
        /// Максимальная температура
        /// </summary>
        public int MaxTemperaturaForPlanting { get; set; } 

        /// <summary>
        /// Минимальная температура
        /// </summary>
        public int MinTemperaturaForPlanting { get; set; } 

        /// <summary>
        /// Скорее всего лишнее,  тк первая поливка идет в момент посадки
        /// </summary>
        public int? FirstWateringAfterPlanting { get; set; } 

        /// <summary>
        /// Период полива
        /// </summary>
        public int? WateringPeriod { get; set; } 

        public int[]? HoeingAfterPlanting { get; set; }  // окучивание

        public int? LooseningPeriod { get; set; } // рыхление

        public int? WeedingPeriod { get; set; } // прополка

        public int? HarvestingAfterPlanting { get; set; } //  период сбора урожая
    }
}
