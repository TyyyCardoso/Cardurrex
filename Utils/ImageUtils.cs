using CardurrexAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace CardurrexAPI.Utils
{
    public class ImageUtils
    {
        private static string profilePicturesPath = "/img/ProfilePictures";



        public static byte[] Base64StringToByteArray(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static string SaveImageToServer(byte[] image, string rootPath)
        {
            string definedPath = rootPath + profilePicturesPath;

            try {
                if (!Directory.Exists(definedPath))
                {
                    Directory.CreateDirectory(definedPath);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + ".png";

                string fullFilePath = Path.Combine(definedPath, uniqueFileName);

                File.WriteAllBytes(fullFilePath, image);

                return uniqueFileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }  
        }

        public static bool DeleteImageFromServer(string imageName, string rootPath)
        {
            string definedPath = rootPath + profilePicturesPath;

            // Eliminar imagem caso tenha sido criada
            string caminhoImagem = Path.Combine(definedPath, imageName);
            if (System.IO.File.Exists(caminhoImagem))
            {
                System.IO.File.Delete(caminhoImagem);
                return true;
            }
            return false;
        }


    }
}
