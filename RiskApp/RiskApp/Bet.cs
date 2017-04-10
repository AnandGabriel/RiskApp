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

        public Bet(int customerID, int eventID, int participantID, decimal stake, decimal win, BetType betType)
        {
            CustomerID = customerID;
            EventID = eventID;
            ParticipantID = participantID;
            Stake = stake;
            Win = win;
            BetType = betType;
        }
    }
}
