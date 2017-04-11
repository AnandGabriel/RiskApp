using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public enum BetType
    {
        Settled = 1,
        UnSettled = 2
    }

    public enum RiskType
    {
        None = 1,
        Risky = 2,
        Unusual = 3,
        HighlyUnusal = 4,
        MoreThan1000 = 5
        
    }

    /// <summary>
    /// Holds bet details
    /// </summary>
    public class Bet
    {
        public int CustomerID { get; }
        public int EventID { get; }
        public int ParticipantID { get; }
        public decimal Stake { get; }
        public decimal Win { get; }
        public BetType BetType { get; }
        public RiskType RiskType { get; }

        public Bet(int customerID, int eventID, int participantID, decimal stake, decimal win, BetType betType, RiskType riskType = RiskType.None)
        {
            CustomerID = customerID;
            EventID = eventID;
            ParticipantID = participantID;
            Stake = stake;
            Win = win;
            BetType = betType;
            RiskType = riskType;
        }
    }
}
