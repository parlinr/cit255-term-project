using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public interface IRepository : IDisposable
    {
        //all of the return types are void because all IO in UWP uses
        //async methods
        void GetAllPassers();
        void GetAllRushers();
        void GetAllReceivers();
        void SelectByRecordNumber(int recordNumber, Table table);
        void InsertPasser(Passer obj);
        void Dispose();

    }
}
