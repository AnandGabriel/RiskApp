using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RiskApp
{
    public class FileHandler : IFileHandler
    {
        private string FilePath;
        private BetType BetType;

        public FileHandler(string filePath, BetType betType)
        {
            FilePath = filePath;
            BetType = betType;
        }

        public List<Bet> GetBets()
        {
            List<Bet> bets = new List<Bet>();

            if (!File.Exists(FilePath))
                throw new FileNotFoundException(string.Format("Bets file is not found: {0}", FilePath));

            IEnumerable<string> fileLines = File.ReadLines(FilePath);
            foreach(string fileLine in fileLines)
            {
                string[] data = fileLine.Split(',');

                int customerID;
                int eventID;
                int participantID;
                decimal stake;
                decimal win;

                if (!int.TryParse(data[0], out customerID))
                    throw new Exception(string.Format("CustomerID is not valid. {0}", data[0]));

                if (!int.TryParse(data[1], out eventID))
                    throw new Exception(string.Format("eventID is not valid. {0}", data[1]));

                if (!int.TryParse(data[2], out participantID))
                    throw new Exception(string.Format("participantID is not valid. {0}", data[2]));

                if (!decimal.TryParse(data[3], out stake))
                    throw new Exception(string.Format("stake is not valid. {0}", data[3]));

                if (!decimal.TryParse(data[4], out win))
                    throw new Exception(string.Format("win is not valid. {0}", data[4]));

                Bet bet = new Bet(customerID, eventID, participantID, stake, win, BetType);
                bets.Add(bet);
            }

            return bets;
        }
    }
}
