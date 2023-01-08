using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CinemaTickets.ViewModel
{
    public class RoleFormViewModel
    {
        [Required,StringLength(100)]
        public string RoleName { get; set; }
    }
}
