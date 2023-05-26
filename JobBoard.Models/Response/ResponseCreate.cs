namespace JobBoard.Models.Response
{
    public class ResponseCreate
    {
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string AppResponseMessage { get; set; }
        public int ResponseId { get; set; }
    }
}
