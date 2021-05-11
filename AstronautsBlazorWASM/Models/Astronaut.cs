using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AstronautsBlazorWASM.Models
{
    public class Astronaut
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Položka jméno musí být vyplněna")]
        [MinLength(1)]
        [MaxLength(20, ErrorMessage = "maximální počet znaků ve jménu je {1}")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Položka příjmení musí být vyplněna")]
        [MinLength(1)]
        [MaxLength(20, ErrorMessage = "maximální počet znaků v příjmení je {1}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Musí být uvedeno datum narození")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Musí být přidána superschopnost")]
        [Range(1, int.MaxValue, ErrorMessage = "Musí být přidána superschopnost")]
        public int SuperpowerId { get; set; }

        public Superpower Superpower { get; set; }
    }
}
