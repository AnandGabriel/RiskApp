using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class BetStatistics
    {
        private int CustomerID;
        private int WinPercentage;
        private int AverageBet;
        
        public BetStatistics(int customerID, int winPercentage, int averageBet)
        {
            CustomerID = customerID;
            WinPercentage = winPercentage;
            AverageBet = averageBet;
        }
    }
}
