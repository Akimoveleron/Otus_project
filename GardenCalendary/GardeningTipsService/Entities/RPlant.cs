namespace GardeningTipsService.Entities;

/// <summary>
/// Справочник растений и базовой информации о них
/// </summary>
public class RPlant
{
    public int Id { get; set; }

    public string Name { get; set; } // сорт растения

    public int[] NumberMonthsForPlanting { get; set; } // номера месяцев для высаживания

    public int MaxTemperaturaForPlanting { get; set; } // максимальная температура. А это скорее лишнее

    public int MinTemperaturaForPlanting { get; set; } // минимальная температура

    public int? FirstWateringAfterPlanting { get; set; } // скорее всего лишнее,  тк первая поливка идет в момент посадки. А вот нет , первый полив через орпеделнное время

    public int WateringPeriod { get; set; } // период полива

    public int[]? HoeingAfterPlanting { get; set; }  // окучивание

    public int? LooseningPeriod { get; set; } // рыхление

    public int? WeedingPeriod { get; set; } // прополка

    public int? HarvestingAfterPlanting { get; set; } //  период сбора урожая
}
