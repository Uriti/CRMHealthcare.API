using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public int? LeadSourceId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual LeadSource? LeadSource { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
