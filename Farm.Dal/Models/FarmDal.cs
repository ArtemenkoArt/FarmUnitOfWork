using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Dal.Models
{
    public class FarmDal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "OwnerName can't be empty!")]
        public string OwnerName { get; set; }
        public int AmnAnimal { get; set; }
    }
}
