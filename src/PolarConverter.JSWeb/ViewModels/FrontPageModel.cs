namespace PolarConverter.JSWeb.ViewModels
{
    public class FrontPageModel
    {
        public string BlobPath { get; set; }
        public bool HasDropbox { get; set; }

        public UserViewModel User { get; set; }
    }
}