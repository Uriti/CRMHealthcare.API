using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class OpportunityStage
{
    public int OpportunityStageId { get; set; }

    public string StageName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsClosed { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
