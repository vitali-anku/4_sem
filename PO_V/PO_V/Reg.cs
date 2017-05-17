using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PO_V
{
    class Validate
    {
        public static bool Valid(object value)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(value);
            if (!Validator.TryValidateObject(value, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                    return false;
                }
            }
            return true;
        }
    }

    class Registr
    {
        [Required(ErrorMessage = "Введите логин")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{4,20}")]
        public string Log { get; set; }

        [Required(ErrorMessage = "Введите Ф.И.О. пользователя")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}", ErrorMessage = "Не верно введен ФИО")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина Ф.И.О.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите номер паспорта")]
        [RegularExpression(@"([A-Z]){2}([0-9]){7}", ErrorMessage = "Неверный номер паспорта")]
        public string NumberPassport { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20}", ErrorMessage = "Придумайте другой пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Повторите пароль")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }

    class Login
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Log { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
    }

    class UpdateLogin
    {
        [Required(ErrorMessage = "Введите логин")]

        public string Log { get; set; }
    }

    class UpdateName
    {
        [Required(ErrorMessage = "Введите Ф.И.О. пользователя")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}", ErrorMessage = "Не верно введен ФИО")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Недопустимая длина Ф.И.О.")]
        public string FullName { get; set; }
    }

    class UpdatePass
    {
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20}", ErrorMessage = "Придумайте другой пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
