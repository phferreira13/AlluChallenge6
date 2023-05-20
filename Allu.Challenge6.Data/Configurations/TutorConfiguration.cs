using Allu.Challenge6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allu.Challenge6.Data.Configurations
{
    public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.ProfilePicture).IsRequired(false);
            builder.Property(p => p.Telefone).IsRequired(false);
            builder.Property(p => p.Cidade).IsRequired(false);
            builder.Property(p => p.Sobre).IsRequired(false);
        }
    }
}
