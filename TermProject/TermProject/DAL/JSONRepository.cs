using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace TermProject
{
    public class JSONRepository
    {
        //With UWP's subset of .NET, we cannot have: 1) return types, or 2) out or
        //ref keywords in async methods (required for file IO in UWP). Intermediary
        //properties will have to do.
        public ObservableCollection<Passer> AllPassers { get; set; }

        public async void GetAllPassers()
        {
            List<Passer> passers = new List<Passer>();
            string jsonText;

            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile passersFile = await storageFolder.GetFileAsync("ms-appx:///passers.json");
            Windows.Storage.StorageFile passersFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("..\\passers.json");

            //build the stream and write it to a string
            var stream = await passersFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            ulong size = stream.Size;
            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    jsonText = dataReader.ReadString(numBytesLoaded);
                }
            }

            //serialize the string
            passers = JsonConvert.DeserializeObject<List<Passer>>(jsonText);
            ObservableCollection<Passer> collection = new ObservableCollection<Passer>(passers);
            AllPassers = collection;
        }
    }
}
