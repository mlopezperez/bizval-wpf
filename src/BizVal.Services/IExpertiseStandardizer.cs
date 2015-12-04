using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizVal.Model;

namespace BizVal.Services
{
    interface IExpertiseStandardizer
    {
        Expertise Standardize(Expertise expertise);
    }
}
