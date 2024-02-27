namespace Domain.Models.Data;

public class UpdateModel
{
    public int UserId { get; set; }
    
    public List<GardenModel> Gardens { get; set; }
}