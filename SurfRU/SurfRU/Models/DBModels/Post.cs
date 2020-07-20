using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfRU.Models.DBModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Текст поста
        /// </summary>
        [Display(Name = "Введите текст"), MaxLength(4095)]
        public string Text { get; set; }

        /// <summary>
        /// Приложенное фото
        /// </summary>
        [Display(Name = "Прикрепить изображение")]
        public Guid Photo { get; set; }

        /// <summary>
        /// Дата и время публикации
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        public virtual User Author { get; set; }
    }
}