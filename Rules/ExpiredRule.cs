using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;

namespace UbsDevRisk.Rules
{
    public class ExpiredRule : ICategoryRule
    {
        public string Category => "EXPIRED";
        public bool Matches(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).Days > 30;
        }
    }
}
