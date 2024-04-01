using Domain.Users;


namespace Domain.Activities;
public class Activity
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public required User CreatedBy { get; set; }
    public required User ModifiedBy { get; set; }
}
