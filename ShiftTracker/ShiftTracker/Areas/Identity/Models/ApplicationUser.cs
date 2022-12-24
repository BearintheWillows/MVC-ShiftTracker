using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Areas.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Shift>? Shifts { get; set; }
    }
}