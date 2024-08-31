﻿using System;
using System.Collections.Generic;

namespace HealthCareManagementSystem_EF_.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppointmentTime { get; set; }

    public string? Status { get; set; }

    public virtual Patient? Patient { get; set; }
}
