using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PO_V
{
    class Login
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string log { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string pass { get; set; }
    }
}
