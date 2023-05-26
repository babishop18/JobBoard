namespace JobBoard.Models.Response
{
    public class ResponseDetail
    {
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string AppResponseMessage { get; set; }
    }
}
