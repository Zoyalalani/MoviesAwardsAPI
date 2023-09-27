using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAwardsAPI.Models
{

    [ExcludeFromCodeCoverage]
    public class TitleGenre
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }
        public virtual Title Title { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
