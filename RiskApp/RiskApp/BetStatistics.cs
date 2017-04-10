using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class BetStatistics
    {
        public int CustomerID { get; }
        public int WinPercentage { get; }
        public int AverageBet { get; }

        public BetStatistics(int customerID, int winPercentage, int averageBet)
        {
            CustomerID = customerID;
            WinPercentage = winPercentage;
            AverageBet = averageBet;
        }
    }
}
