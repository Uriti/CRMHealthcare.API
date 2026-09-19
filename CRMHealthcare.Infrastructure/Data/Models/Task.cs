using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int OpportunityId { get; set; }

    public int? InteractionId { get; set; }

    public int AssignedUserId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User AssignedUser { get; set; } = null!;

    public virtual Interaction? Interaction { get; set; }

    public virtual Opportunity Opportunity { get; set; } = null!;
}
