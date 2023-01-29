using Core.Utilities.Helpers.GuidHelperr;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        // Gönderilen dosyayı GUID olarak yeniden isimlendirmek için kullanılır
        public string RePath(IFormFile file)
        {
            if (file.Length > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string newFilePath = guid + extension;
                return newFilePath;

            }
            return null;
        }

        // Dosya var mı kontrol et, directory mevcut mu, değilse oluştur, dosyayı directory'e ekle
        public void Upload(IFormFile file, string root, string filePath)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
        }

        // yolu verilen dosya var mı kontrol et, varsa sil
        public void Delete(string fullFilePath)
        {
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
        }

        // yolu verilen eski dosya var mı kontrol et, varsa sil, yeni dosya için Upload metodunu çalıştır
        public void Update(IFormFile file, string oldFileFullPath, string newFilePath, string root)
        {
            if (File.Exists(oldFileFullPath))
            {
                File.Delete(oldFileFullPath);
            }

            Upload(file, root, newFilePath);
        }



    }
}


