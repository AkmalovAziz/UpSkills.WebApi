namespace UpSkills.Domain.Entities.Orders;

public class Order : BaseEntitiy
{
    public long CourseId { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}