using System;
using System.Collections.Generic;

namespace HealthCareManagementSystem_EF_.Models;

public partial class TreatmentPlan
{
    public int TreatmentPlanId { get; set; }

    public int? PatientId { get; set; }

    public string? TreatmentDetails { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? DoctorId { get; set; }

    public virtual Patient? Patient { get; set; }
}
