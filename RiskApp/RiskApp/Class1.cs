using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    /// <summary>
    /// Holds bet details
    /// </summary>
    public class Bet
    {
        private int CustomerID;
        private int EventID;
        private int ParticipantID;
        private decimal Stake;
        private decimal Win;

        public Bet(int customerID, int eventID, int participantID, decimal stake, decimal win)
        {
            CustomerID = customerID;
            EventID = eventID;
            ParticipantID = participantID;
            Stake = stake;
            Win = win;
        }
    }
}
