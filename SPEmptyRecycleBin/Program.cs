using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SPEmptyRecycleBin
{
    class Program
    {
        #region Initializations

        string siteURL = "http://fdotsp.dot.state.fl.us/sites/Design/LeaveOvertimeTravel";

        #endregion

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.EmptyTheRecycleBin();
        }

        #region Methods
        private void EmptyTheRecycleBin()
        {
            try
            {
                using (var clientContext = new ClientContext(siteURL))
                {
                    // Get the SharePoint site  
                    Site site = clientContext.Site;

                    // Delete all the recycle bin items
                    SP.RecycleBinItemCollection rbc = site.RecycleBin;
                    //if (rbc.Count > 0)
                    //{
                        rbc.DeleteAll();
                        // Execute the query to the server  
                        clientContext.ExecuteQuery();

                    //}
                }

                Console.WriteLine("Recycle Bin Emptied");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        #endregion

    }
}
