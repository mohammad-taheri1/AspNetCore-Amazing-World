using CleanArch.Domain.Common;

namespace CleanArch.Domain.Entities;

public class Employee : BaseEntity<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Rank { get; set; }
}
