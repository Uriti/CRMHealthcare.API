using System;
using System.Collections.Generic;

namespace CRMHealthcare.Infrastructure.Data.Models;

public partial class Opportunity
{
    public int OpportunityId { get; set; }

    public int ContactId { get; set; }

    public int OpportunityTypeId { get; set; }

    public int? AssignedUserId { get; set; }

    public int OpportunityStageId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? ClosedDate { get; set; }

    public virtual User? AssignedUser { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();

    public virtual OpportunityStage OpportunityStage { get; set; } = null!;

    public virtual OpportunityType OpportunityType { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
