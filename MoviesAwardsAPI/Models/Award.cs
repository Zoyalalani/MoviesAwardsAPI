using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAwardsAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Award
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public bool AwardWon { get; set; }
        public int AwardYear { get; set; }
        public string AwardCompany { get; set; }
        [Column("Award")]
        public string AwardCategory { get; set; }
        public virtual Title Title { get; set; }

    }
}
