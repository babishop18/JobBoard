namespace JobBoard.Models.Application
{
    public class UserAppListItem
    {
        public string JobTitle { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public int AppId { get; set; }
    }
}
