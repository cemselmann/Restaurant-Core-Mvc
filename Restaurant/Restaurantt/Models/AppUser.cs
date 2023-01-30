﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurantt.Models
{
	public class AppUser:IdentityUser
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string SurName { get; set; }
		[NotMapped]
		public string  Role { get; set; }

	}
}
