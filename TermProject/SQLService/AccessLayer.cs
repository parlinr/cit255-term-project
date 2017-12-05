using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using System.Data.SqlClient;
using Windows.ApplicationModel.Resources;


namespace SQLService
{
    public sealed class AccessLayer : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn't terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request

            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don't want this call to get cancelled while we are waiting.
            
            var messageDeferral = args.GetDeferral();

                

            
            ResourceLoader resourceLoader = new ResourceLoader();
            ValueSet message = args.Request.Message;
            ValueSet returnData = new ValueSet();
            int? testNum = null;
            List<Passer> testResult = new List<Passer>();

            string command = message["Command"] as string;

            switch(command)
            {
                case "test":
                    
                    
                    string connString = resourceLoader.GetString("connString");
                    string sqlCommandString = "SELECT * FROM dbo.NFLOffensePassing";

                    using (SqlConnection sqlConn = new SqlConnection(connString))
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn))
                    {
                        try
                        {
                            sqlConn.Open();
                            
                            
                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                    
                                    while (reader.Read())
                                    {
                                        Passer p = new Passer();
                                        p.FirstName = reader["playerFirstName"].ToString();
                                        p.LastName = reader["playerLastName"].ToString();
                                        p.Interceptions = Convert.ToInt32(reader["interceptionsThrown"]);
                                        p.TeamNameLong = reader["teamNameLong"].ToString();
                                        p.TeamNameShort = reader["teamNameShort"].ToString();
                                        p.Touchdowns = Convert.ToInt32(reader["touchdownPasses"]);
                                        p.Yards = Convert.ToInt32(reader["yards"]);
                                        testResult.Add(p);
                                    }
                                
                                
                            }
                            
                        }
                        catch (Exception e)
                        {

                        }
                    }

                    testNum = testResult.ElementAt(25).Interceptions;
                    returnData.Add("Result", testNum);
                    returnData.Add("Status", "OK");

                       
                    break;
                default:
                    break;
                
            }

            if (testResult.Count != 0)
            {
                throw new NotImplementedException();
            }
            //return data
            try
            {
                await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
            }
            catch (Exception e)
            {
                // your exception handling code here
            }
            finally
            {
                // Complete the deferral so that the platform knows that we're done responding to the app service call.
                // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
                messageDeferral.Complete();
            }
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }
    }
}
