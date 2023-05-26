namespace JobBoard.Models.Application
{
    public class ApplicationListItem
    {
        public string FullName { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public bool HasResponse { get; set; }
        public int PhoneNumber { get; set; }
        public int AppId { get; set; }
    }
}
