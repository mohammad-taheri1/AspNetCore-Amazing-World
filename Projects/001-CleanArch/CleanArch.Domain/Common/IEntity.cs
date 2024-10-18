namespace CleanArch.Domain.Common;

public interface IEntity<TypeOfKey>
{
    public TypeOfKey Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
