﻿namespace DashboardTemplate.Helpers
{
    public static class FileSettings
    {

        public const string imgesPath = "/Images";
        public const string AllowedExtentions = ".jpg,.jpeg,.png";
        public static string UploadFile(IFormFile file, string folderName)
        {

            // 1. Get located file path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", folderName);

            // 2. Get file Name and make it Unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3. Get file path
            string filePath = Path.Combine(folderPath, fileName);

            // 4. Save file as stream [Data per time]
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);

            return fileName;


        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

        }
    }
}
