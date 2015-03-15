namespace PolarConverter.JSWeb.ViewModels
{
    public class FrontPageModel
    {
        public string BlobPath { get; set; }
        public bool HasDropbox { get; set; }

		public bool HasStrava { get; set; }
		public bool HasRunkeeper { get; set; }
        public UserViewModel User { get; set; }
		public string RunkeeperUsername { get; set; }
	}
}