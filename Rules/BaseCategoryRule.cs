using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;

namespace UbsDevRisk.Rules
{
    public abstract class BaseCategoryRule : ICategoryRule
    {
        public abstract string Category { get; }
        public abstract bool Matches(ITrade trade, DateTime referenceDate);
    }

}
