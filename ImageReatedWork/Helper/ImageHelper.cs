namespace ImageReatedWork.Helper
{
    public  static class ImageHelper
    {
        public static readonly string DefaultImagePath = "wwwroot/Images";
        public static string SaveImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return null;
            }
              
            if (! Directory.Exists(DefaultImagePath))
            {
                Directory.CreateDirectory(DefaultImagePath);
            }
           string actualPath= Path.Combine(DefaultImagePath, image.FileName);
            if(File.Exists(actualPath))
            {
                return image.FileName;
            }
            var file = new FileStream(actualPath, FileMode.Create);
           image.CopyTo(file);
            file.Close();
            return image.FileName;

        }
        public static void DeleteImage(string ImageName)
        {
            string deleteImagePath=Path.Combine(DefaultImagePath, ImageName);
            if (File.Exists(deleteImagePath))
                 File.Delete(deleteImagePath);
        }
    }
}
