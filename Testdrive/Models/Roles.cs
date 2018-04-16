using System;
using System.ComponentModel;

namespace TestRide.Models
{
    [Flags]
    public enum Roles
    {
        [Description("Användare")]
        User = 1,
        [Description("Administratör")]
        Admin = 2
    }
}
