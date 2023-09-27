using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAwardsAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }

    }
}
