using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


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
        public List<Passer> AllPassersList { get; set; }
        public List<Rusher> AllRushersList { get; set; }
        public List<Receiver> AllReceiversList { get; set; }
        public ObservableCollection<Passer> APasser { get; set; }
        public ObservableCollection<Rusher> ARusher { get; set; }
        public ObservableCollection<Receiver> AReceiver { get; set; }

        public JSONRepository()
        {
            AllPassersList = new List<Passer>();
        }

        public async Task<ObservableCollection<Passer>> GetAllPassers()
        {
            List<Passer> passers = new List<Passer>();
            string jsonText;

            //copy JSON file to AppData folder if it doesn't already exist
            TransferToStorage("passers.json");



            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\passers.json";
            //string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, passerFile);
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
            //AllPassers = collection;
            return collection;
        }

        public async Task<ObservableCollection<Passer>> GetPasserByRecordNumber(int recordNumber)
        {
            List<Passer> passers = new List<Passer>();
            string jsonText;

            //copy JSON file to AppData folder if it doesn't already exist
            TransferToStorage("passers.json");



            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\passers.json";
            //string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, passerFile);
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
            ObservableCollection<Passer> collection = new ObservableCollection<Passer>();
            foreach (Passer p in passers)
            {
                if (p.RecordNumber == recordNumber)
                {
                    collection.Add(p);
                }
            }

            //AllPassers = collection;
            return collection;
        }

        public async void GetAllPassersAsList()
        {
            List<Passer> passers = new List<Passer>();
            string jsonText;

            //copy JSON file to AppData folder if it doesn't already exist
            TransferToStorage("passers.json");



            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\passers.json";
            //string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, passerFile);
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
            AllPassersList = passers;
        }

        public async void GetAllRushers()
        {
            List<Rusher> rushers = new List<Rusher>();
            string jsonText;

            TransferToStorage("rushers.json");
            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\rushers.json";
                  
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

        public async void GetAllRushersAsList()
        {
            List<Rusher> rushers = new List<Rusher>();
            string jsonText;

            TransferToStorage("rushers.json");
            //specify where the target (JSON) file is
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\rushers.json";

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
            AllRushersList = rushers;
        }

        public async void GetAllReceivers()
        {
            List<Receiver> receivers = new List<Receiver>();
            string jsonText;

            //specify where the target (JSON) file is
            TransferToStorage("receivers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\receivers.json";

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

        public async void GetAllReceiversAsList()
        {
            List<Receiver> receivers = new List<Receiver>();
            string jsonText;

            //specify where the target (JSON) file is
            TransferToStorage("receivers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var pth = root + "\\receivers.json";

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
            AllReceiversList = receivers;
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
                GetAllPassersAsList();
                passers = AllPassersList;
            }
            else if (table == Table.Receivers)
            {
                ext = @"\receivers.json";
                TransferToStorage("receivers.json");
            }
            else if (table == Table.Rushers)
            {
                ext = @"\rushers.json";
                TransferToStorage("rushers.json");
            }

            //serialize the string
            if (table == Table.Passers)
            {
                
                List<Passer> result = new List<Passer>();
                //TODO: exception handling
                foreach (Passer p in passers)
                {
                    if (p.RecordNumber == recordNumber)
                    {
                        result.Add(p);
                    }
                }
                if (result.ElementAt(0).RecordNumber != recordNumber)
                {
                    ContentDialog failed = new ContentDialog
                    {
                        Title = "Failure",
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK",
                        Content = "The passer with the specified Record Number was not found."
                    };
                    await failed.ShowAsync();
                    return;
                }
                ObservableCollection<Passer> collection = new ObservableCollection<Passer>(result);
                APasser = collection;

                
            }
            else if (table == Table.Receivers)
            {
                receivers = JsonConvert.DeserializeObject<List<Receiver>>(jsonText);
                List<Receiver> result = new List<Receiver>();
                //TODO: exception handling
                foreach (Receiver r in receivers)
                {
                    if (r.RecordNumber == recordNumber)
                    {
                        result.Add(r);
                    }
                }
                if (result.ElementAt(0).RecordNumber != recordNumber)
                {
                    ContentDialog failed = new ContentDialog
                    {
                        Title = "Failure",
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK",
                        Content = "The receiver with the specified Record Number was not found."
                    };
                    await failed.ShowAsync();
                    return;
                }
                ObservableCollection<Receiver> collection = new ObservableCollection<Receiver>(result);
                AReceiver = collection;

                ContentDialog success = new ContentDialog
                {
                    Title = "Success",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                    Content = "The specific receiver was successfully selected."
                };
                await success.ShowAsync();
            }
            else if (table == Table.Rushers)
            {
                rushers = JsonConvert.DeserializeObject<List<Rusher>>(jsonText);
                List<Rusher> result = new List<Rusher>();
                //TODO: exception handling
                foreach (Rusher r in rushers)
                {
                    if (r.RecordNumber == recordNumber)
                    {
                        result.Add(r);
                    }
                }
                if (result.ElementAt(0).RecordNumber != recordNumber)
                {
                    ContentDialog failed = new ContentDialog
                    {
                        Title = "Failure",
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK",
                        Content = "The rusher with the specified Record Number was not found."
                    };
                    await failed.ShowAsync();
                    return;
                }
                ObservableCollection<Rusher> collection = new ObservableCollection<Rusher>(result);
                ARusher = collection;

                ContentDialog success = new ContentDialog
                {
                    Title = "Success",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                    Content = "The specific receiver was successfully selected."
                };

                await success.ShowAsync();
            }
            


        }

        public async void InsertPasser(Passer p)
        {
            //get the file
            TransferToStorage("passers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            string comma = ",";
            string rightBracket = "]";
            var pth = root + "\\passers.json";
            Windows.Storage.StorageFile passersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            string jsonText = JsonConvert.SerializeObject(p, Formatting.Indented);

            //write to the file
            var stream = await passersFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            if (stream.Size != 0)
            {
                using (var outputStream = stream.GetOutputStreamAt(stream.Size - 1))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        dataWriter.WriteString(comma);
                        dataWriter.WriteString(jsonText);
                        dataWriter.WriteString(rightBracket);
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();
            }
            else
            {
                using (var outputStream = stream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        dataWriter.WriteString(jsonText);
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();
            }
            
        }

        public async void InsertRusher(Rusher r)
        {
            //get the file
            TransferToStorage("rushers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            string comma = ",";
            string rightBracket = "]";
            var pth = root + "\\rushers.json";
            Windows.Storage.StorageFile rushersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            string jsonText = JsonConvert.SerializeObject(r, Formatting.Indented);

            //write to the file
            var stream = await rushersFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(stream.Size - 1))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(comma);
                    dataWriter.WriteString(jsonText);
                    dataWriter.WriteString(rightBracket);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose(); 
        }

        public async void InsertReceiver(Receiver r)
        {
            //get the file
            TransferToStorage("receivers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            string comma = ",";
            string rightBracket = "]";
            var pth = root + "\\receivers.json";
            Windows.Storage.StorageFile receiversFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

            string jsonText = JsonConvert.SerializeObject(r, Formatting.Indented);

            //write to the file
            var stream = await receiversFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(stream.Size - 1))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(comma);
                    dataWriter.WriteString(jsonText);
                    dataWriter.WriteString(rightBracket);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();
        }

        private async void TransferToStorage(string file)
        {
            //from https://stackoverflow.com/questions/26940802/copy-file-from-app-installation-folder-to-local-storage

            //has file been copied already?
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(file);
                //no exception means file already exists
                return;
            }
            catch (FileNotFoundException e)
            {
                //file does not exist if this exception is caught
                
                
            }
            //I get exceptions when I attempt to run the below in a catch block (especially the task)
            //This is where the file is copied to the ApplicationData location (where the app has read and write permissions,
            //as opposed to the install directory, where it only has read permissions
            var ext = @"Assets\" + file;
            string pth = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, ext);
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            var t = Task.Run(() => File.Copy(pth, root + "\\" + file));
            t.Wait();
         
        }

        public async void UpdatePasser(Passer q)
        {
            TransferToStorage("passers.json");
            string jsonText = "";
            List<Passer> passers = new List<Passer>();
            Passer isThePasserThere = new Passer
            {
                RecordNumber = -999999
            };

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("passers.json");

            var stream = await file.OpenAsync(FileAccessMode.Read);
            ulong size = stream.Size;
            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    jsonText = dataReader.ReadString(numBytesLoaded);
                }
            }

            passers = JsonConvert.DeserializeObject<List<Passer>>(jsonText);
            foreach (Passer p in passers)
            {
                if (p.RecordNumber == q.RecordNumber)
                {
                    isThePasserThere = p;
                }
            }
            
            if (isThePasserThere.RecordNumber == -999999)
            {
                ContentDialog failed = new ContentDialog
                {
                    Title = "Failure",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                    Content = "The passer with the specified Record Number was not found."
                };

                await failed.ShowAsync();
                return;
            }
            foreach (Passer p in passers)
            {
                if (p.RecordNumber == q.RecordNumber)
                {
                    if (q.FirstName != "")
                    {
                        p.FirstName = q.FirstName;
                    }
                    if (q.Interceptions != -1)
                    {
                        p.Interceptions = q.Interceptions;
                    }
                    if (q.LastName != "")
                    {
                        p.LastName = q.LastName;
                    }
                    if (q.Score != -1)
                    {
                        p.Score = q.Score;
                    }
                    if (q.TeamNameLong != "")
                    {
                        p.TeamNameLong = q.TeamNameLong;
                    }
                    if (q.TeamNameShort != "")
                    {
                        p.TeamNameShort = q.TeamNameShort;
                    }
                    if (q.Touchdowns != -1)
                    {
                        p.Touchdowns = q.Touchdowns;
                    }
                    if (q.Yards != -999)
                    {
                        p.Yards = q.Yards;
                    }

                }
            }

            File.WriteAllText(file.Path, "");

            stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    jsonText = JsonConvert.SerializeObject(passers, Formatting.Indented);
                    dataWriter.WriteString(jsonText);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();

            ContentDialog success = new ContentDialog
            {
                Title = "Success",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Content = "The specified passer record was updated."
            };
            await success.ShowAsync();
        }

        public async Task<bool> Delete(Table table, int recordNumber)
        {
            string ext = "";
            string jsonText = "";
            bool wasDeleted = false;
            List<Passer> passers = new List<Passer>();
            List<Receiver> receivers = new List<Receiver>();
            List<Rusher> rushers = new List<Rusher>();

            if (table == Table.Passers)
            {
                TransferToStorage("passers.json");
                ext = "\\passers.json";
            }
            else if (table == Table.Receivers)
            {
                TransferToStorage("receivers.json");
                ext = "\\receivers.json";
            }
            else
            {
                TransferToStorage("rushers.json");
                ext = "\\rushers.json";
            }
            
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            string filePath = root + ext;
            Windows.Storage.StorageFile file = await Windows.Storage.StorageFile.GetFileFromPathAsync(filePath); //hangs

            //build the stream and write it to a string
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            ulong size = stream.Size;
            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    jsonText = dataReader.ReadString(numBytesLoaded);
                }
            }

            if (table == Table.Passers)
            {
                Passer passerToDelete = new Passer();
                passers = JsonConvert.DeserializeObject<List<Passer>>(jsonText);

                //yes, I know this takes time O(n) ....
                foreach (Passer p in passers)
                {
                    
                    if (p.RecordNumber == recordNumber)
                    {
                        //if such a record is found, mark it for deletion
                        passerToDelete = p;
                        
                    }

                }
                if (passerToDelete == null)
                {
                    return wasDeleted;
                }

                //delete the marked record
                passers.Remove(passerToDelete);

                jsonText = JsonConvert.SerializeObject(passers, Formatting.Indented);

                //overwrite the file
                File.WriteAllText(filePath, "");

                //write the modified list to the file
                var passersStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (var outputStream = passersStream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        
                        
                        dataWriter.WriteString(jsonText);
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();
                wasDeleted = true;
                return wasDeleted;

            }
            else if (table == Table.Receivers)
            {
                //serialize the string
                Receiver receiverToDelete = new Receiver();
                receivers = JsonConvert.DeserializeObject<List<Receiver>>(jsonText);

                //yes, I know this takes time O(n) ....
                foreach (Receiver r in receivers)
                {

                    if (r.RecordNumber == recordNumber)
                    {
                        //if such a record is found, mark it for deletion
                        receiverToDelete = r;

                    }

                }
                if (receiverToDelete == null)
                {
                    return wasDeleted;
                }


                //delete the marked record
                receivers.Remove(receiverToDelete);

                jsonText = JsonConvert.SerializeObject(receivers, Formatting.Indented);

                //overwrite the file
                File.WriteAllText(filePath, "");

                //write the modified list to the file
                var receiversStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (var outputStream = receiversStream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {


                        dataWriter.WriteString(jsonText);
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();
                wasDeleted = true;
                return wasDeleted;
            }
            else
            {
                Rusher rusherToDelete = new Rusher();
                rushers = JsonConvert.DeserializeObject<List<Rusher>>(jsonText);

                //yes, I know this takes time O(n) ....
                foreach (Rusher r in rushers)
                {

                    if (r.RecordNumber == recordNumber)
                    {
                        //if such a record is found, mark it for deletion
                        rusherToDelete = r;

                    }

                }
                if (rusherToDelete == null)
                {
                    return wasDeleted;
                }

                //delete the marked record
                rushers.Remove(rusherToDelete);

                jsonText = JsonConvert.SerializeObject(rushers, Formatting.Indented);

                //overwrite the file
                File.WriteAllText(filePath, "");

                //write the modified list to the file
                var rushersStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (var outputStream = rushersStream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {


                        dataWriter.WriteString(jsonText);
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();
                wasDeleted = true;
                return wasDeleted;
            }
            


        }

        public async void DeletePasser(int recordNumber)
        {
            TransferToStorage("passers.json");
            Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string root = folder.Path;
            string jsonText = "";
            List<Passer> passers = new List<Passer>();
            Passer passerToDelete = new Passer
            {
                Yards = -99999
            };
            string comma = ",";
            string rightBracket = "]";
            var pth = root + "\\passers.json";
            Windows.Storage.StorageFile passersFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(pth);

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


            passers = JsonConvert.DeserializeObject<List<Passer>>(jsonText);
            foreach (Passer p in passers)
            {
                if (p.RecordNumber == recordNumber)
                {
                    passerToDelete = p;
                }
            }
            if (passerToDelete.Yards == -99999)
            {
                ContentDialog failed = new ContentDialog
                {
                    Title = "Failure",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                    Content = "The passer with the specified Record Number was not found."
                };

                await failed.ShowAsync();
                return;

            }

            passers.Remove(passerToDelete);

            jsonText = JsonConvert.SerializeObject(passers, Formatting.Indented);

            File.WriteAllText(pth, "");

            stream = await passersFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(jsonText);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();

            ContentDialog success = new ContentDialog
            {
                Title = "Success",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Content = "The specified passer record was deleted."
            };
            await success.ShowAsync();

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
