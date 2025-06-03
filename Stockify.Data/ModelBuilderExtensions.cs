using Microsoft.EntityFrameworkCore;
using Stockify.Objects;
namespace Stockify.Data;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
           new Customer { Id = 1, Name = "Liesbeth Peeters", Street = "Meir", City = "Antwerpen", ZipCode = "2000" },
           new Customer { Id = 2, Name = "Tom De Smet", Street = "Veldstraat", City = "Gent", ZipCode = "9000" },
           new Customer { Id = 3, Name = "Sofie Maes", Street = "Zuidzandstraat", City = "Brugge", ZipCode = "8000" },
           new Customer { Id = 4, Name = "Bram Janssens", Street = "Bondgenotenlaan", City = "Leuven", ZipCode = "3000" },
           new Customer { Id = 5, Name = "Eline Willems", Street = "Onze-Lieve-Vrouwestraat", City = "Mechelen", ZipCode = "2800" },
           new Customer { Id = 6, Name = "Niels Vermeulen", Street = "Groenplaats", City = "Antwerpen", ZipCode = "2000" },
           new Customer { Id = 7, Name = "Karen Van Damme", Street = "Kapellestraat", City = "Oostende", ZipCode = "8400" },
           new Customer { Id = 8, Name = "Dries De Clercq", Street = "Kortrijksesteenweg", City = "Kortrijk", ZipCode = "8500" },
           new Customer { Id = 9, Name = "Inge Goossens", Street = "Lippenslaan", City = "Knokke-Heist", ZipCode = "8300" },
           new Customer { Id = 10, Name = "Wim Van den Broeck", Street = "Rue de Namur", City = "Brussel", ZipCode = "1000" }
        );

        modelBuilder.Entity<Product>().HasData(
          new Product { Id = 1, Name = "Toothbrush" },
          new Product { Id = 2, Name = "Schrijfbic" },
          new Product { Id = 3, Name = "Notitieboekje" },
          new Product { Id = 4, Name = "Afwasborstel" },
          new Product { Id = 5, Name = "Wc-borstel" },
          new Product { Id = 6, Name = "Flesopener" },
          new Product { Id = 7, Name = "Zaklamp" },
          new Product { Id = 8, Name = "Brooddoos" },
          new Product { Id = 9, Name = "Koffiemok" },
          new Product { Id = 10, Name = "Drinkfles" },
          new Product { Id = 11, Name = "Keukenschaar" },
          new Product { Id = 12, Name = "Tandenstoker" },
          new Product { Id = 13, Name = "Stekkerdoos" },
          new Product { Id = 14, Name = "Timer" },
          new Product { Id = 15, Name = "Fietslichtje" },
          new Product { Id = 16, Name = "Ovenwant" },
          new Product { Id = 17, Name = "Schroevendraaier" },
          new Product { Id = 18, Name = "Gsm-houder" },
          new Product { Id = 19, Name = "Rekenmachine" },
          new Product { Id = 20, Name = "Geurkaars" }
        );
    }
}
