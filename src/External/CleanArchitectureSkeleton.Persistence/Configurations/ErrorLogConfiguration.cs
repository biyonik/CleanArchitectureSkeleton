using CleanArchitectureSkeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureSkeleton.Persistence.Configurations;

public class ErrorLogConfiguration: IEntityTypeConfiguration<ErrorLog>
{
    public void Configure(EntityTypeBuilder<ErrorLog> builder)
    {
        builder.ToTable("ErrorLogs");
        builder.HasKey(errorLog => errorLog.Id);
    }
}