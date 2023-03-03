using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author{
                        AuthorName="Kemal",
                        AuthorSurname = "Erol"
                    },
                    new Author{
                        AuthorName="Mert ",
                        AuthorSurname = "Muslu"
                    },
                    new Author{
                        AuthorName="Berkay",
                        AuthorSurname = "Çolak"
                    }
                );
                context.Genres.AddRange(
                    new Genre{
                        Name="Personel Growth",
                    },
                    new Genre{
                        Name="Science Fiction"
                    },
                    new Genre{
                        Name="Romance"
                    }
                );
                
                context.Books.AddRange(
                    new Book{
                // Id = 1,
                Title="Lean Startup",
                GenreId=1, //Personal Growth
                PageCount=200,
                PublishDate=new DateTime(2001,06,12),
                

                   },

                     new Book{
                // Id = 2,
                Title="Herland",
                GenreId=2, //Science Fiction
                PageCount=250,
                PublishDate=new DateTime(2010,05,23)
                   },

                    new Book{
                // Id = 3,
                Title="Lean Startup",
                GenreId=2, //Science Fiction
                PageCount=540,
                PublishDate=new DateTime(2002,12,12)
                   }

                );

                context.SaveChanges();
            }
        }
    }
}