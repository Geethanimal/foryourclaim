using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foryourclaim___0._2V.Models
{
    public class WebMaster
    {
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
