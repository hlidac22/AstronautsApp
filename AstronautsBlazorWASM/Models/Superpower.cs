using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AstronautsBlazorWASM.Models
{
    public class Superpower
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Položka název musí být vyplněna")]
        [MaxLength(20, ErrorMessage = "maximální počet znaků v názvu je {1}")]
        public string Name { get; set; }
    }
}
