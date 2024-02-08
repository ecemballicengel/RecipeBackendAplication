using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Bll.Services.HelperServices
{
    public class HelperService : IHelperService
    {
        public string SaveImage(string imageData)
        {
            try
            {
                var data = DecodeBase64(imageData);

                var imageName = $"{Guid.NewGuid()}.jpg";

                if (data == null)
                {
                    throw new Exception("Resim Donusturulemedi");
                }
                var filePath = Path.Combine("wwwroot", "Images", $"{imageName}");

                File.WriteAllBytes(filePath, data);

                return $"https://localhost:7056/Images/{imageName}";

            }
            catch (Exception ex)
            {

                throw new Exception("Resim Kaydedilemedi");
            }

        }
        private byte[] DecodeBase64(string base64String)
        {
            try
            {
                var data = base64String.Split(',');
                var x = data.First();
                if (!x.Contains("jpg") && !data.First().Contains("png") && !data.First().Contains("jpeg"))
                {
                    throw new Exception("Hatali resim uzantisi");
                }

                byte[] imageBytes = Convert.FromBase64String(data.Last());

                return imageBytes;
            }
            catch (Exception ex)
            {

                throw new Exception("Fotograf cevrilemedi.");
            }
        }
    }
}
