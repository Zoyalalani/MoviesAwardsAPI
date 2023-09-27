using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAwardsAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class StoryLine
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public virtual Title Title { get; set; }

    }
}
