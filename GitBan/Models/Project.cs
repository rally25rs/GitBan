namespace GitBan.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public string HtmlUrl { get; set; }
        public int OpenIssuesCount { get; set; }
    }
}