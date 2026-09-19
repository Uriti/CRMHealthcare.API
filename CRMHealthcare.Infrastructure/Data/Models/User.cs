using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? MobileNumber { get; set; }

    public string? Email { get; set; }

    public string Username { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
