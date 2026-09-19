using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class Interaction
{
    public int InteractionId { get; set; }

    public int OpportunityId { get; set; }

    public int UserId { get; set; }

    public DateTime InteractionDate { get; set; }

    public string InteractionType { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime? FollowUpDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Opportunity Opportunity { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User User { get; set; } = null!;
}
