namespace BugTracker.UI.DTO.TicketDTO
{
    public class DeveloperCheckboxItem
    {
        public string DeveloperName { get; set; } = null!;
        public bool IsChecked { get; set; } = false;
        public int DeveloperId { get; set; }
    }
}
