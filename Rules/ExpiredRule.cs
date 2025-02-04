using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;

namespace UbsDevRisk.Rules
{
    public class ExpiredRule : BaseCategoryRule
    {
        public override string Category => "EXPIRED";
        public override bool Matches(ITrade trade, DateTime referenceDate) =>
            (referenceDate - trade.NextPaymentDate).Days > 30;
    }
}
