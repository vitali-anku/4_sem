using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PO_V
{
    class Atrib
    {
        [Required(ErrorMessage = "Введите значения!")]
        [Display(Name = "Текст")]
        public string Pole { get; set; }

        //[Required(ErrorMessage = "Введите логин!")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина логина")]
        //public string Login { get; set; }
        //[Required(ErrorMessage = "Введите имя!")]
        //[StringLength(30, MinimumLength = 3, ErrorMessage = "Имя больше 30 символов!")]
        //public string Name { get; set; }
        //[Required(ErrorMessage = "Введите фамилию!")]
        //[StringLength(40, MinimumLength = 3, ErrorMessage = "Фамилия больше 40 символов!")]
        //public string Last_Name { get; set; }
        //[Required(ErrorMessage = "Введите Email!")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес!")]
        //public string Email { get; set; }
        //public string Hash { get; set; }
        //public string Salt { get; set; }
    }
}
