using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Mappings
{
    public class UsersMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Nome).IsRequired();
            builder.Property(x=> x.Email).IsRequired();
            builder.Property(x=> x.Senha).IsRequired();
            builder.Property(x=> x.Sobrenome).IsRequired();
            builder.Property(x=> x.Login).IsRequired();
            builder.Property(x=> x.Idade).IsRequired();  

        }
    }
}
