using CleanArch.Domain.Common;

namespace CleanArch.Domain.Entities;

public class Teacher : BaseEntity<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Grade { get; set; }
}
