using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Variable.Models;
using Microsoft.AspNetCore.Identity;

namespace Variable.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; } //automatic create the table with the help of migration
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		public DbSet<OrderHeader> OrderHeaders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Phones",DisplayOrder=1},
                new Category { Id = 2, Name = "Laptops", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Pc components", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Phone Accessories", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Pc & Laptop Accessories", DisplayOrder = 5 }

                );
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Amazon",
                    StreetAddress = "54/A NA Street",
                    City = "New York",
                    PostalCode = "256900",
                    State = "US",
                    PhoneNumber = "6669990000"
                },
                new Company
                {
                    Id = 2,
                    Name = "Flipkart",
                    StreetAddress = "312, Sree Balaji Business Park",
                    City = "Kolkata",
                    PostalCode = "700845",
                    State = "West Bengal",
                    PhoneNumber = "7779990000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Digital World",
                    StreetAddress = "999 Main St",
                    City = "Devarabeesanahalli",
                    PostalCode = "560103",
                    State = "Bengaluru ",
                    PhoneNumber = "589648742"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    ProductName = "iPhone 15 Pro", 
                    Storage="256 GB", 
                    Brand="Apple",
                    Price=134900.00, 
                    DisccountPrice=130499.00,
                    Color= "Natural Titanium",
                    Description1= "iPhone 15 Pro has a strong and light aerospace-grade titanium design with a textured matte-glass back. It also features a Ceramic Shield front that’s tougher than any smartphone glass.",
                    Description2= "The 6.1” Super Retina XDR display with ProMotion ramps up refresh rates to 120Hz when you need exceptional graphics performance. ",
                    Description3= "A Pro-class GPU makes mobile games feel so immersive, with rich environments and realistic characters. ",
                    CategoryId= 1,
                    ImageURl = ""
                },
                new Product
                {
                    Id = 2,
                    ProductName = "ASUS Vivobook 16",
                    Storage = "512 GB SSD",
                    Brand = "Asus",
                    Price = 55990.00,
                    DisccountPrice = 37990.00,
                    Color = "Black",
                    Description1 = "Processor: IntelCore i3-1215U Processor 1.2 GHz (10M Cache, up to 4.4 GHz, 6 cores).",
                    Description2 = "Memory: 8GB DDR4 on board 3200MHz with | Storage: 512GB M.2 NVMe PCIe 4.0 SSD. ",
                    Description3 = "I/O Port: 1x USB 2.0 Type-A, 1x USB 3.2 Gen 1 Type-C, 2x USB 3.2 Gen 1 Type-A, 1x HDMI 1.4, 1x 3.5mm Combo Audio Jack, 1x DC-in.",
                    CategoryId = 2,
                    ImageURl = ""
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Samsung Galaxy S22 Ultra 5G",
                    Storage = "256 GB",
                    Brand = "Samsung",
                    Price = 131900.00,
                    DisccountPrice = 84499.00,
                    Color = "Dark Red",
                    Description1 = "The first Galaxy S with embedded S Pen. Write comfortably like pen on paper, turn quick notes into legible text and use Air Actions to control your phone remotely.",
                    Description2 = "5G Ready powered by Galaxy’s first 4nm processor. Our fastest, most powerful chip ever.",
                    Description3 = "The Dynamic AMOLED 2x display improves outdoor visibility with up to 1750 nits in peak brightness.* And the 120Hz adaptive refresh rate keeps the scroll smooth, adjusting to what's on screen for an optimized view.",
                    CategoryId = 1,
                    ImageURl=""
                }
                );
        }
    }
}
