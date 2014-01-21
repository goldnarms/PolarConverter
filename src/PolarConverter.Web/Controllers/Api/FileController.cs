using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Http;
using Amazon.S3;
using Amazon.S3.Model;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.Web.Controllers.Api
{
    public class FileController : ApiController
    {
        AmazonS3Client s3Client = new AmazonS3Client("AKIAJAK243KC3DLSLS2A", "VCqr7sy2QeqlsYOLFN5+VZos2cWfGt8zLFSdt/oV");
        public FileController()
        {

        }

        [HttpPost]
        public bool PostFile(List<PolarFile> files)
        {
            var userModel = new UserModel
            {
                HrmFiles = new Dictionary<string, string>(),
                GpxFiles = new Dictionary<string, string>(),
                XmlFiles = new Dictionary<string, string>(),
                SportName = new Dictionary<string, string>()
            };
            var test = files;
            //var hrmFiles = files.Where(file => file.Filename.Contains(".hrm"));
            //var gpxFiles = files.Where(file => file.Filename.Contains(".gpx"));
            //var xmlFiles = files.Where(file => file.Filename.Contains(".xml"));

            foreach (var polarFile in files)
            {
                var filename = polarFile.Filename.Substring(0, polarFile.Filename.Length - 4);
                Stream fileStream = new MemoryStream();
                var request = new GetObjectRequest { BucketName = "polarconverterfilpicker", Key = polarFile.Key };
                using (GetObjectResponse response = s3Client.GetObject(request))
                {
                    //response.ResponseStream.CopyTo(fileStream);
                    using (var reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                        if (polarFile.Filename.Contains(".hrm"))
                        {
                            userModel.HrmFiles.Add(filename, fileContent);
                            userModel.SportName.Add(filename, polarFile.SportName);
                        }
                        else if (polarFile.Filename.Contains(".gpx"))
                            userModel.GpxFiles.Add(filename, fileContent);
                        else if (polarFile.Filename.Contains(".xml"))
                        {
                            userModel.XmlFiles.Add(filename, fileContent);
                            userModel.SportName.Add(filename, polarFile.SportName);
                        }
                    }
                }
            }
            return true;
        }


        //protected void btnDownload_Click(object sender, EventArgs e)
        //{
        //    string imageKey = txtFileName.Text;
        //    string eTagToMatch = txtEtag.Text;
        //    string extension = imageKey.Substring(imageKey.LastIndexOf("."));
        //    string imagePath = Server.MapPath("S3FilesDownload") + "\\" + imageKey;

        //    Stream imageStream = new MemoryStream();

        //    GetObjectRequest request = new GetObjectRequest { BucketName = "YourBucketName", Key = imageKey, ETagToMatch = eTagToMatch };
        //    using (GetObjectResponse response = s3Client.GetObject(request))
        //    {
        //        response.ResponseStream.CopyTo(imageStream);
        //    }

        //    imageStream.Position = 0;

        //    SaveStreamToFile(imagePath, imageStream);

        //    imgDownloaded.ImageUrl = "S3FilesDownload/" + imageKey;

        //    Response.Write("<script>alert('File Downloaded from S3 Successfully.');</script>");
        //}

        //private void SaveStreamToFile(string fileFullPath, Stream stream)
        //{
        //    using (stream)
        //    {
        //        using (FileStream fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write))
        //        {
        //            byte[] data = new byte[32768];
        //            int bytesRead = 0;
        //            do
        //            {
        //                bytesRead = stream.Read(data, 0, data.Length);
        //                fs.Write(data, 0, bytesRead);
        //            }
        //            while (bytesRead > 0);
        //            fs.Flush();
        //        }
        //    }

        //} 
    }

}