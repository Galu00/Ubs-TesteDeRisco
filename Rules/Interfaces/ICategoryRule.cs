using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;

namespace UbsDevRisk.Rules.Interfaces
{
    public interface ICategoryRule
    {
        bool Matches(ITrade trade, DateTime referenceDate);
        string Category { get; }
    }
}
