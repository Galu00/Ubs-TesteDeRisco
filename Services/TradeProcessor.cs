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
        private readonly IReadOnlyList<ICategoryRule> _rules;

        public TradeProcessor(IEnumerable<ICategoryRule> rules)
        {
            _rules = rules?.ToList() ?? throw new ArgumentNullException(nameof(rules));
        }

        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            if (trade == null) throw new ArgumentNullException(nameof(trade));
            return _rules.FirstOrDefault(rule => rule.Matches(trade, referenceDate))?.Category ?? "UNCATEGORIZED";
        }
    }
}
