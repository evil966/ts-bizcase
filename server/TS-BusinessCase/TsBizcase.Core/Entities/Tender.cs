using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBizcase.Core.Entities
{
    public class Tender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ReferenceNumber { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime ClosingDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CreatorId { get; set; }

        public virtual AppUser Creator { get; set; } = new AppUser();
    }
}
