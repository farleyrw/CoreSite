using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreSite.Base;

namespace CoreSite.Logic.Models
{
	[Table("skill", Schema = "helperfinder")]
	public class Stuff : BaseEntity
    {
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }

		public DateTime CreatedAt { get; set; }
    }
}