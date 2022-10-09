using Microsoft.EntityFrameworkCore;
using MyCash.Models;

namespace MyCash.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacionamentos das Categorias
            modelBuilder.Entity<Category>()
                        .HasMany(cat => cat.Incomes)
                        .WithOne(income => income.Category)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>()
                        .HasMany(cat => cat.Expenses)
                        .WithOne(expense => expense.Category)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            //Default Expense Category
            modelBuilder.Entity<Expense>()
                        .Property(exp => exp.CategoryId)
                        .HasDefaultValue(8);

            //Populando tabela Categories com os padrões
            modelBuilder.Entity<Category>()
                        .HasData(
                                    new Category
                                    {
                                        Id = 1,
                                        Name = "Alimentação",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 2,
                                        Name = "Saúde",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 3,
                                        Name = "Moradia",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 4,
                                        Name = "Transporte",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 5,
                                        Name = "Educação",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 6,
                                        Name = "Lazer",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 7,
                                        Name = "Imprevistos",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 8,
                                        Name = "Outras",
                                        isIncomeType = false,
                                        CreatedAt = System.DateTime.Now
                                    },
                                    new Category
                                    {
                                        Id = 9,
                                        Name = "Salário",
                                        isIncomeType = true,
                                        CreatedAt = System.DateTime.Now
                                    }
                                );
        }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
