using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarians.TwitterSdk.DS
{
    public interface IFile
   {
        BinaryWriter file(string path);
    }
}
