using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;
using UbsDevRisk.Rules;

namespace UbsDevRisk.Services
{
    public class TradeProcessor
    {
        private readonly List<ICategoryRule> _rules;

        public TradeProcessor()
        {
            _rules = new List<ICategoryRule>
            {
                new ExpiredRule(),
                new HighRiskRule(),
                new MediumRiskRule()
            };
        }

        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            return _rules.FirstOrDefault(rule => rule.Matches(trade, referenceDate))?.Category ?? "UNCATEGORIZED";
        }
    }
}
