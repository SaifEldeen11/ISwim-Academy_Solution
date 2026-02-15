namespace Application.Dtos.TeamDto
{
    public class CreateTeamDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CoachId { get; set; }
    }
}
