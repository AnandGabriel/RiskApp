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
        public decimal AverageBet { get; }

        public BetStatistics(int customerID, decimal winPercentage, decimal averageBet)
        {
            CustomerID = customerID;
            WinPercentage = winPercentage;
            AverageBet = averageBet;
        }
    }
}
