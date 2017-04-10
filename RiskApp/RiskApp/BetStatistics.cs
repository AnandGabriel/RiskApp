using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public class BetStatistics
    {
        public int CustomerID { get; }
        public decimal WinPercentage { get; }
        public int AverageBet { get; }

        public BetStatistics(int customerID, decimal winPercentage, int averageBet)
        {
            CustomerID = customerID;
            WinPercentage = winPercentage;
            AverageBet = averageBet;
        }
    }
}
