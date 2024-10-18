using CleanArch.Domain.Common;

namespace CleanArch.Domain.Entities;

public class Course : BaseEntity<long>
{
    public string Title { get; set; }
}
