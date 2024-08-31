using System;
using System.Collections.Generic;

namespace HealthCareManagementSystem_EF_.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();
}
