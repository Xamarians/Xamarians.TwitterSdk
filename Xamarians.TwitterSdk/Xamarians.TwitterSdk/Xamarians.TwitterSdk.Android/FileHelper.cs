
using Xamarians.TwitterSdk.Droid;
using Xamarians.TwitterSdk.DS;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Xamarians.TwitterSdk.Droid
{
    public class FileHelper : IFile
    {
        public BinaryWriter file(string path)
        {
            try
            {
                byte[] b = File.ReadAllBytes(path);
                Stream stream = new MemoryStream(b);
                var data = new BinaryWriter(stream);
                return data;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}