using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TermProject
{
    public interface IRepository : IDisposable
    {
        //all of the return types are void because all IO in UWP uses
        //async methods
        Task<ObservableCollection<Passer>> GetAllPassers();
        void GetAllPassersAsList();
        void GetAllRushers();
        void GetAllRushersAsList();
        void GetAllReceivers();
        void GetAllReceiversAsList();
        void SelectByRecordNumber(int recordNumber, Table table);
        void InsertPasser(Passer obj);
        void Dispose();

    }
}
