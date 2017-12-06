using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using Windows.Storage;

namespace TermProject
{
    public class JSONRepository : IRepository
    {
        //With UWP's subset of .NET, we cannot have: 1) return types, or 2) out or
        //ref keywords in async methods (required for file IO in UWP). Intermediary
        //properties will have to do.
        public ObservableCollection<Passer> AllPassers { get; set; }
        public ObservableCollection<Rusher> AllRushers { get; set; }
        public ObservableCollection<Receiver> AllReceivers { get; set; }
        public ObservableCollection<Passer> APasser { get; set; }
        public ObservableCollection<Rusher> ARusher { get; set; }
        public ObservableCollection<Receiver> AReceiver { get; set; }

        public async void GetAllPassers()
        {
            List<Passer> passers = new List<Passer>();
            string jsonText;

            //specify where the target (JSON) file is
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile passersFile = await storageFolder.GetFileAsync("ms-appx:///passers.json");
            //Windows.Storage.StorageFile passersFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Assets\\passers.json");
            var passerFile = @"Assets\passers.json";
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, passerFile);
            Windows.Storage.StorageFile passersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

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

        public async void GetAllRushers()
        {
            List<Rusher> rushers = new List<Rusher>();
            string jsonText;

            //specify where the target (JSON) file is
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile passersFile = await storageFolder.GetFileAsync("ms-appx:///passers.json");
            //Windows.Storage.StorageFile passersFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Assets\\passers.json");
            var rusherFile = @"Assets\rushers.json";
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, rusherFile);
            Windows.Storage.StorageFile rushersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            //build the stream and write it to a string
            var stream = await rushersFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
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
            rushers = JsonConvert.DeserializeObject<List<Rusher>>(jsonText);
            ObservableCollection<Rusher> collection = new ObservableCollection<Rusher>(rushers);
            AllRushers = collection;
        }

        public async void GetAllReceivers()
        {
            List<Receiver> receivers = new List<Receiver>();
            string jsonText;

            //specify where the target (JSON) file is
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile passersFile = await storageFolder.GetFileAsync("ms-appx:///passers.json");
            //Windows.Storage.StorageFile passersFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Assets\\passers.json");
            var receiverFile = @"Assets\receivers.json";
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, receiverFile);
            Windows.Storage.StorageFile receiversFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            //build the stream and write it to a string
            var stream = await receiversFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
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
            receivers = JsonConvert.DeserializeObject<List<Receiver>>(jsonText);
            ObservableCollection<Receiver> collection = new ObservableCollection<Receiver>(receivers);
            AllReceivers = collection;
        }

        public async void SelectByRecordNumber(int recordNumber, Table table)
        {
            //declarations
            List<Passer> passers = new List<Passer>();
            List<Receiver> receivers = new List<Receiver>();
            List<Rusher> rushers = new List<Rusher>();

            //read from file
            var ext = "";
            string jsonText = "";
            if (table == Table.Passers)
            {
                ext = @"Assets\passers.json";
            }
            else if (table == Table.Receivers)
            {
                ext = @"Assets\receivers.json";
            }
            else if (table == Table.Rushers)
            {
                ext = @"Assets\rushers.json";
            }
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, ext);
            Windows.Storage.StorageFile File = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            //build the stream and write it to a string
            var stream = await File.OpenAsync(Windows.Storage.FileAccessMode.Read);
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
            if (table == Table.Passers)
            {
                passers = JsonConvert.DeserializeObject<List<Passer>>(jsonText);
                List<Passer> result = new List<Passer>();
                //TODO: exception handling
                result.Add(passers.Find(p => p.RecordNumber == recordNumber));
                ObservableCollection<Passer> collection = new ObservableCollection<Passer>(result);
                APasser = collection;

            }
            else if (table == Table.Receivers)
            {
                receivers = JsonConvert.DeserializeObject<List<Receiver>>(jsonText);
                List<Receiver> result = new List<Receiver>();
                //TODO: exception handling
                result.Add(receivers.Find(p => p.RecordNumber == recordNumber));
                ObservableCollection<Receiver> collection = new ObservableCollection<Receiver>(result);
                AReceiver = collection;
                
            }
            else if (table == Table.Rushers)
            {
                rushers = JsonConvert.DeserializeObject<List<Rusher>>(jsonText);
                List<Rusher> result = new List<Rusher>();
                //TODO: exception handling
                result.Add(rushers.Find(p => p.RecordNumber == recordNumber));
                ObservableCollection<Rusher> collection = new ObservableCollection<Rusher>(result);
                ARusher = collection;
            }
            


        }

        public async void InsertPasser(Passer p)
        {
            //get the file
            var passerFile = @"Assets\passers.json";
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, passerFile);
            Windows.Storage.StorageFile passersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            string jsonText = JsonConvert.SerializeObject(p, Formatting.Indented);

            //write to the file
            var stream = await passersFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(jsonText);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.
        }

        public void Dispose()
        {
            AllPassers = null;
            AllReceivers = null;
            AllRushers = null;
            APasser = null;
            AReceiver = null;
            ARusher = null;
        }
    }
}
