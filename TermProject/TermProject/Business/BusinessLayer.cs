using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TermProject
{ 
    public class BusinessLayer : IBusinessLayer
    {
        #region PROPERTIES
        
        #endregion

        #region METHODS
        public ObservableCollection<Passer> QueryPassersByScore(int minScore, int maxScore, out List<Passer> passerReturnList)
        {
            JSONRepository repo = new JSONRepository();
            repo.GetAllPassersAsList();
            List<Passer> allPassers = repo.AllPassersList;
            passerReturnList = (List<Passer>)allPassers.Where(p => p.Score >= minScore && p.Score <= maxScore);
            ObservableCollection<Passer> queryResult = new ObservableCollection<Passer>(passerReturnList);

            return queryResult;
            
        }

        public ObservableCollection<Receiver> QueryReceiversByScore(int minScore, int maxScore, out List<Receiver> receiverReturnList)
        {
            JSONRepository repo = new JSONRepository();
            repo.GetAllReceiversAsList();
            List<Receiver> allReceivers = repo.AllReceiversList;
            receiverReturnList = (List<Receiver>)allReceivers.Where(r => r.Score >= minScore && r.Score <= maxScore);
            ObservableCollection<Receiver> queryResult = new ObservableCollection<Receiver>(receiverReturnList);

            return queryResult;
        }

        public ObservableCollection<Rusher> QueryRushersByScore(int minScore, int maxScore, out List<Rusher> rusherReturnList)
        {
            JSONRepository repo = new JSONRepository();
            repo.GetAllRushersAsList();
            List<Rusher> allRushers = repo.AllRushersList;
            rusherReturnList = (List<Rusher>)allRushers.Where(r => r.Score >= minScore && r.Score <= maxScore);
            ObservableCollection<Rusher> queryResult = new ObservableCollection<Rusher>(rusherReturnList);

            return queryResult;
        }

        public ObservableCollection<Passer> SortPassersByScore(ObservableCollection<Passer> pageOutput)
        {
            return (ObservableCollection<Passer>)pageOutput.OrderBy(p => p.Score);
        }

        public ObservableCollection<Receiver> SortReceiversByScore(ObservableCollection<Receiver> pageOutput)
        {
            return (ObservableCollection<Receiver>)pageOutput.OrderBy(p => p.Score);
        }

        public ObservableCollection<Rusher> SortRushersByScore(ObservableCollection<Rusher> pageOutput)
        {
            return (ObservableCollection<Rusher>)pageOutput.OrderBy(p => p.Score);
        }

        public async Task<ObservableCollection<Passer>> GetAllPassers()
        {
            JSONRepository j = new JSONRepository();
            //await j.GetAllPassers();
            
            ObservableCollection<Passer> ob = await j.GetAllPassers();
            return ob;

        }

        public void InsertPasser(Passer p)
        {
            JSONRepository j = new JSONRepository();
            j.InsertPasser(p);
        }

        public async Task<bool> Delete(Table table, int recordNumber)
        {
            bool taskResult;
            JSONRepository j = new JSONRepository();
            taskResult = await j.Delete(table, recordNumber);
            return taskResult;
        }

        public void DeletePasser(int recordNumber)
        {
            bool taskResult;
            JSONRepository j = new JSONRepository();
            j.DeletePasser(recordNumber);
            
        }

        public async Task<bool> UpdatePasser(Passer p)
        {
            JSONRepository j = new JSONRepository();
            bool wasSuccessful = await j.UpdatePasser(p);
            return wasSuccessful;
        }
        #endregion

    }
}
