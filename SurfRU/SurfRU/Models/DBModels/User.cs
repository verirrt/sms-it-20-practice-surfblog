using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfRU.Models.DBModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        [Display(Name="Псевдоним")]
        [Required(ErrorMessage = "Ошибка в псевдониме"), MinLength(3), MaxLength(20)]
        public string Nickname { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Указание электронной почты обязательно")]
        [EmailAddress(ErrorMessage = "Неверно указан e-mail")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Ошибка в пароле"), MinLength(6), MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [NotMapped]
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Контактная информация
        /// </summary>
        [Display(Name = "Контактная информация")]
        public string ContactInfo { get; set; }

        /// <summary>
        /// О себе
        /// </summary>
        [Display(Name = "О себе")]
        public string About { get; set; }

        /// <summary>
        /// Достижения
        /// </summary>
        [Display(Name = "Достижения")]
        public string Achievements { get; set; }

        /// <summary>
        /// Фото профиля
        /// </summary>
        [Display(Name = "Выберите фото")]
        public Guid Photo { get; set; }

    }
}