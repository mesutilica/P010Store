namespace P010Store.WebAPIUsing.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/wwwroot/Img/")
        {
            var fileName = "";

            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }

        public static bool FileRemover(string fileName, string filePath = "/wwwroot/Img/")
        {
            string directory = Directory.GetCurrentDirectory() + filePath + fileName;

            if (File.Exists(directory)) // .net de dosya ve klasör işlemleri için File sınıfı mevcuttur. File.Exists metodu kendisine verilen yolda(directory) bir dosya var mı yok mu kontrol eder. Dosya varsa true yoksa false bilgisini getirir.
            {
                File.Delete(directory); // eğer klasörde dosya varsa dosyayı fiziksel olarak sil.
                return true; // silme başarılıysa geriye true dön ki metodu kullandığımız yerde işlemin başarılı olduğunu bilelim.
            }

            return false;
        }

    }
}
