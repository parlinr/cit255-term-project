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
        /*
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
        */
        public async Task<ObservableCollection<Passer>> GetAllPassers()
        {
            JSONRepository j = new JSONRepository();
            //await j.GetAllPassers();
            
            ObservableCollection<Passer> ob = await j.GetAllPassers();
            return ob;

        }

        public async Task<ObservableCollection<Receiver>> GetAllReceivers()
        {
            JSONRepository j = new JSONRepository();
            //await j.GetAllPassers();

            ObservableCollection<Receiver> ob = await j.GetAllReceivers();
            return ob;

        }
        
        public void InsertPasser(Passer p)
        {
            JSONRepository j = new JSONRepository();
            j.InsertPasser(p);
        }

        public void InsertReceiver(Receiver p)
        {
            JSONRepository j = new JSONRepository();
            j.InsertReceiver(p);
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

        public async Task<ObservableCollection<Passer>> QueryPassers(PasserOperationData opData)
        {
            JSONRepository j = new JSONRepository();
            
            List<Passer> passers = await j.GetAllPassersAsList();
            List<Passer> queryResult = new List<Passer>();
            

            if (opData.MinScore != -99999 || opData.MaxScore != -99999)
            {
                if (opData.MinScore != -99999 && opData.MaxScore != -99999)
                {
                    foreach (Passer p in passers)
                    {
                        if (p.Score >= opData.MinScore && p.Score <= opData.MaxScore)
                        {
                            queryResult.Add(p);
                        }
                    }
                        
                }
                else if (opData.MinScore == -99999)
                {
                    foreach (Passer p in passers)
                    {
                        if (p.Score <= opData.MaxScore)
                        {
                            queryResult.Add(p);
                        }
                    }
                        
                }
                else
                {
                    foreach (Passer p in passers)
                    {
                        if (p.Score >= opData.MinScore)
                        {
                            queryResult.Add(p);
                        }
                    }
                        
                }
                
            }
            if (opData.MinYards != -99999 || opData.MaxYards != -99999)
            {
                if (queryResult.Count == 0)
                {
                    if (opData.MinYards != -99999 && opData.MaxYards != -99999)
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Yards >= opData.MinYards && p.Yards <= opData.MaxYards)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                    else if (opData.MinYards == -99999)
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Yards <= opData.MaxYards)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                    else
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Yards >= opData.MinYards)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                }
                else
                {
                    List<Passer> subQueryResult = new List<Passer>();
                    if (opData.MinYards != -99999 && opData.MaxYards != -99999)
                    {
                        foreach (Passer p in queryResult)
                        {
                            if (p.Yards >= opData.MinYards && p.Yards <= opData.MaxYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }
                    else if (opData.MinYards == -99999)
                    {
                        foreach (Passer p in queryResult)
                        {
                            if (p.Yards <= opData.MaxYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }
                    else
                    {
                        foreach (Passer p in queryResult)
                        {
                            if (p.Yards >= opData.MinYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }

                    queryResult = subQueryResult;
                    if (queryResult.Count == 0)
                    {
                        return new ObservableCollection<Passer>(queryResult);
                    }
                }
            }
            
            if (opData.MinTouchdowns != -99999 || opData.MaxTouchdowns != -99999)
            {
                if (queryResult.Count == 0)
                {
                    if (opData.MinTouchdowns != -99999 && opData.MaxTouchdowns != -99999)
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns && p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                    else if (opData.MinTouchdowns == -99999)
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                    else
                    {
                        foreach (Passer p in passers)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }
                        
                    }
                }
                else
                {
                    List<Passer> subQueryResult = new List<Passer>();
                    if (opData.MinTouchdowns != -99999 && opData.MaxTouchdowns != -99999)
                    {
                        foreach (Passer p in queryResult)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns && p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }
                    else if (opData.MinTouchdowns == -99999)
                    {
                        foreach(Passer p in queryResult)
                        {
                            if (p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }
                    else
                    {
                        foreach (Passer p in queryResult)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }
                        
                    }

                    queryResult = subQueryResult;
                    if (queryResult.Count == 0)
                    {
                        return new ObservableCollection<Passer>(queryResult);
                    }
                }
            }

            ObservableCollection<Passer> returnedCollection = new ObservableCollection<Passer>(queryResult);
            return returnedCollection;


        }

        public async Task<ObservableCollection<Receiver>> QueryReceivers(PasserOperationData opData)
        {
            JSONRepository j = new JSONRepository();

            List<Receiver> receivers = await j.GetAllReceiversAsList();
            List<Receiver> queryResult = new List<Receiver>();


            if (opData.MinScore != -99999 || opData.MaxScore != -99999)
            {
                if (opData.MinScore != -99999 && opData.MaxScore != -99999)
                {
                    foreach (Receiver p in receivers)
                    {
                        if (p.Score >= opData.MinScore && p.Score <= opData.MaxScore)
                        {
                            queryResult.Add(p);
                        }
                    }

                }
                else if (opData.MinScore == -99999)
                {
                    foreach (Receiver p in receivers)
                    {
                        if (p.Score <= opData.MaxScore)
                        {
                            queryResult.Add(p);
                        }
                    }

                }
                else
                {
                    foreach (Receiver p in receivers)
                    {
                        if (p.Score >= opData.MinScore)
                        {
                            queryResult.Add(p);
                        }
                    }

                }

            }
            if (opData.MinYards != -99999 || opData.MaxYards != -99999)
            {
                if (queryResult.Count == 0)
                {
                    if (opData.MinYards != -99999 && opData.MaxYards != -99999)
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Yards >= opData.MinYards && p.Yards <= opData.MaxYards)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                    else if (opData.MinYards == -99999)
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Yards <= opData.MaxYards)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                    else
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Yards >= opData.MinYards)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                }
                else
                {
                    List<Receiver> subQueryResult = new List<Receiver>();
                    if (opData.MinYards != -99999 && opData.MaxYards != -99999)
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Yards >= opData.MinYards && p.Yards <= opData.MaxYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }
                    else if (opData.MinYards == -99999)
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Yards <= opData.MaxYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }
                    else
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Yards >= opData.MinYards)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }

                    queryResult = subQueryResult;
                    if (queryResult.Count == 0)
                    {
                        return new ObservableCollection<Receiver>(queryResult);
                    }
                }
            }

            if (opData.MinTouchdowns != -99999 || opData.MaxTouchdowns != -99999)
            {
                if (queryResult.Count == 0)
                {
                    if (opData.MinTouchdowns != -99999 && opData.MaxTouchdowns != -99999)
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns && p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                    else if (opData.MinTouchdowns == -99999)
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                    else
                    {
                        foreach (Receiver p in receivers)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns)
                            {
                                queryResult.Add(p);
                            }
                        }

                    }
                }
                else
                {
                    List<Receiver> subQueryResult = new List<Receiver>();
                    if (opData.MinTouchdowns != -99999 && opData.MaxTouchdowns != -99999)
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns && p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }
                    else if (opData.MinTouchdowns == -99999)
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Touchdowns <= opData.MaxTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }
                    else
                    {
                        foreach (Receiver p in queryResult)
                        {
                            if (p.Touchdowns >= opData.MinTouchdowns)
                            {
                                subQueryResult.Add(p);
                            }
                        }

                    }

                    queryResult = subQueryResult;
                    if (queryResult.Count == 0)
                    {
                        return new ObservableCollection<Receiver>(queryResult);
                    }
                }
            }

            ObservableCollection<Receiver> returnedCollection = new ObservableCollection<Receiver>(queryResult);
            return returnedCollection;


        }

        public ObservableCollection<Passer> SortPassers(PasserSortData sData, ObservableCollection<Passer> passersToSort)
        {
            ObservableCollection<Passer> sorted = new ObservableCollection<Passer>();

            if (sData.SortByScore == true && sData.SortByYards == false && sData.SortByTouchdowns == false)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Score).ToList();
                sorted = new ObservableCollection<Passer>(q);
                
            }
            if (sData.SortByScore == false && sData.SortByYards == true && sData.SortByTouchdowns == false)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Yards).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }
            if (sData.SortByScore == false && sData.SortByYards == false && sData.SortByTouchdowns == true)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == true && sData.SortByTouchdowns == false)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Yards).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == false && sData.SortByTouchdowns == true)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }
            if (sData.SortByScore == false && sData.SortByYards == true && sData.SortByTouchdowns == true)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Yards).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == true && sData.SortByTouchdowns == true)
            {
                List<Passer> q = passersToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Yards).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Passer>(q);
            }

            return sorted;
        }

        public ObservableCollection<Receiver> SortReceivers(PasserSortData sData, ObservableCollection<Receiver> receiversToSort)
        {
            ObservableCollection<Receiver> sorted = new ObservableCollection<Receiver>();

            if (sData.SortByScore == true && sData.SortByYards == false && sData.SortByTouchdowns == false)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Score).ToList();
                sorted = new ObservableCollection<Receiver>(q);

            }
            if (sData.SortByScore == false && sData.SortByYards == true && sData.SortByTouchdowns == false)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Yards).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }
            if (sData.SortByScore == false && sData.SortByYards == false && sData.SortByTouchdowns == true)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == true && sData.SortByTouchdowns == false)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Yards).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == false && sData.SortByTouchdowns == true)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }
            if (sData.SortByScore == false && sData.SortByYards == true && sData.SortByTouchdowns == true)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Yards).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }
            if (sData.SortByScore == true && sData.SortByYards == true && sData.SortByTouchdowns == true)
            {
                List<Receiver> q = receiversToSort.OrderByDescending(p => p.Score).ThenByDescending(p => p.Yards).ThenByDescending(p => p.Touchdowns).ToList();
                sorted = new ObservableCollection<Receiver>(q);
            }

            return sorted;
        }


        #endregion

    }
}
