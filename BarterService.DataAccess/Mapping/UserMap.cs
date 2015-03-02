using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasRequired(u => u.ScoreAccount);
            
            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode()
                .IsVariableLength();

            Property(u => u.MiddleName)
                .HasMaxLength(100)
                .IsUnicode()
                .IsVariableLength();
            
            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode()
                .IsVariableLength();

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsVariableLength();
        }
    }
}
