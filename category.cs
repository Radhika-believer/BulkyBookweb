using BulkyBookweb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookweb.Models
{ }
    public class category
    {
        [KEY]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only !!")]
        public int Displayorder { get; set; }
        public DateTime Craetedatetime { get; set; } = DateTime.Now;
    }
}
