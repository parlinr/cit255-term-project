using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace TermProject
{ 
    public class ViewModel
    {
        public ObservableCollection<Passer> p { get; set; }
        public BusinessLayer BusinessLayer { get; set; }

        public ViewModel()
        {
            p = new ObservableCollection<Passer>();
            BusinessLayer = new BusinessLayer();
        }

        public async Task<ObservableCollection<Passer>> GetAllPassers()
        {
            
            ObservableCollection<Passer> returnedCollection = new ObservableCollection<Passer>();
            returnedCollection = await BusinessLayer.GetAllPassers();
            return returnedCollection;
        }

        public void InsertPasser(Passer p)
        {
            BusinessLayer.InsertPasser(p);
        }

        public Task<bool> Delete(Table table, int recordNumber)
        {
            return BusinessLayer.Delete(table, recordNumber);
            
        }

        public void DeletePasser(int recordNumber)
        {
            BusinessLayer.DeletePasser(recordNumber);

        }

        public Task<bool> UpdatePasser(Passer p)
        {
            return BusinessLayer.UpdatePasser(p);
        }
    }
}
