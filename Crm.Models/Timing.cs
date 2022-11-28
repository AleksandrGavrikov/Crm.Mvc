﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Models
{
    public class Timing
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public DateTime Data { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }

   
}

namespace Crm.Models
{
    public enum Status
    {
        Available,Pending,Confirm
    }
}