using DonutsGo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.DataAccess.Configurations
{
    public class ProductUserConfiguration: IEntityTypeConfiguration<ProductUser>
    {
        public void Configure(EntityTypeBuilder<ProductUser> builder)
        {
            builder
                .HasKey(productUser => new { productUser.UserId, productUser.ProductId });

            builder
                .HasOne<Product>(x => x.Product)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ProductId);


            builder
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.UserId);

        }

    }
}
