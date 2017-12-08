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
        ObservableCollection<Passer> QueryPassersByScore(int minScore, int maxScore, out List<Passer> p);
        ObservableCollection<Receiver> QueryReceiversByScore(int minScore, int maxScore, out List<Receiver> r);
        ObservableCollection<Rusher> QueryRushersByScore(int minScore, int maxScore, out List<Rusher> r);
        //void QueryByScoreAndYards(Table table, int minYards, int maxYards);
        void SortByScore(Table table);
        //void SortByScoreAndYards(Table table);

    }
}
