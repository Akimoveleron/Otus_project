using Domain.BaseEntites;

namespace Domain.Entities;

public partial class RReestrObject : BaseEntity
{
    /// <summary>
    /// справочник адресных  объектов ( города,  населенные пункты )  
    /// </summary>
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? AccuweatherId { get; set; }
}
