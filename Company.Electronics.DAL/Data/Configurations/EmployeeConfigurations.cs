using Company.Electronics.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Electronics.DAL.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(D => D.Id);
            builder.Property(D => D.Name).HasMaxLength(50);
            builder.Property(S => S.Salary).HasColumnType("decimal(18,2)");
        }
    }
}
