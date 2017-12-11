using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TermProject
{
    public interface IBusinessLayer
    {
        //ObservableCollection<Passer> QueryPassersByScore(int minScore, int maxScore, out List<Passer> p);
        //ObservableCollection<Receiver> QueryReceiversByScore(int minScore, int maxScore, out List<Receiver> r);
        //ObservableCollection<Rusher> QueryRushersByScore(int minScore, int maxScore, out List<Rusher> r);
        //void QueryByScoreAndYards(Table table, int minYards, int maxYards);
        //ObservableCollection<Passer> SortPassersByScore(ObservableCollection<Passer> oc);
        //ObservableCollection<Receiver> SortReceiversByScore(ObservableCollection<Receiver> oc);
        //ObservableCollection<Rusher> SortRushersByScore(ObservableCollection<Rusher> oc);
        Task<ObservableCollection<Passer>> GetAllPassers();
        void InsertPasser(Passer p);
        Task<bool> Delete(Table table, int recordNumber);
        void DeletePasser(int n);
        Task<ObservableCollection<Receiver>> GetAllReceivers();
        void InsertReceiver(Receiver r);
        Task<ObservableCollection<Passer>> QueryPassers(PasserOperationData opData);
        ObservableCollection<Passer> SortPassers(PasserSortData sD, ObservableCollection<Passer> p);
        ObservableCollection<Receiver> SortReceivers(PasserSortData sD, ObservableCollection<Receiver> p);
        //void SortByScoreAndYards(Table table);

    }
}
