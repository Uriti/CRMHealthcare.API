using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class OpportunityType
{
    public int OpportunityTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
