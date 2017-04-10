using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public interface IFileHandler
    {
        List<Bet> GetBets();
    }
}
