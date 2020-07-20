using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurfRU.Models.DBModels;

namespace SurfRU.DAL
{
    public class SurfDbInitializer : DropCreateDatabaseIfModelChanges<SurfDbContext>
    {
        protected override void Seed(SurfDbContext context)
        {
            var user = new User
            {
                Nickname = "vsel",
                Password = "123456",
                LastName = "Старозубов",
                Name = "Всеволод",
                Email = "vsel@star.ru",
                About = "Продавец досок для сёрфинга"
            };

            var post1 = new Post
            {
                Text = "Первый тестовый пост",
                //Photo = Guid.NewGuid(),
                PublishDate = DateTime.Now,
                Author = user
            };

            var post2 = new Post
            {
                Text = "Второй тестовый пост",
                //Photo = Guid.NewGuid(),
                PublishDate = DateTime.Now,
                Author = user
            };

            context.Users.Add(user);
            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.SaveChanges();
        }
    }
}