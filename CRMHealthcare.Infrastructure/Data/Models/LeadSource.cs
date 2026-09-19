using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class LeadSource
{
    public int LeadSourceId { get; set; }

    public string SourceName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
