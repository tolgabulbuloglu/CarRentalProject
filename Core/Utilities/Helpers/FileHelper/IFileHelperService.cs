using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        string RePath(IFormFile file);
        public void Upload(IFormFile file, string root, string filePath);
        void Delete(string fullFilePath);
        void Update(IFormFile file, string oldFileFullPath, string newFilePath, string root);

    }
}
