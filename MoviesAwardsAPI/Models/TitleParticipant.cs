using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAwardsAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class TitleParticipant
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int? ParticipantId { get; set; }
        public string RoleType { get; set; }
        public bool? IsOnScreen { get; set; }
        public Title Title { get; init; }
        public virtual Participant Participant { get; set; }

    }
}
