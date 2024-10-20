﻿using CleanArch.Domain.Common;

namespace CleanArch.Domain.Entities;

public class Student : BaseEntity<long>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Avatar { get; set; }
}
