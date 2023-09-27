using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAwardsAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Title
    {
        [Key]
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUTC { get; set; }
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<StoryLine> StoryLines { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }

    }
}
