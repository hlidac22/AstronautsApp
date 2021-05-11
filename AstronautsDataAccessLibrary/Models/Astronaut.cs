using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronautsDataLibrary.Models
{
    public class Astronaut
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Birthdate { get; set; }

        [Required]
        public int SuperpowerId { get; set; }

        public Superpower Superpower { get; set; }
    }
}
