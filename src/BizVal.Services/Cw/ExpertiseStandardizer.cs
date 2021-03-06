﻿using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.Cw
{
    /// <summary>
    /// Implementation of a standardizer for linguistic expertise.
    /// </summary>
    /// <seealso cref="BizVal.Services.IExpertiseStandardizer" />
    internal sealed class ExpertiseStandardizer : IExpertiseStandardizer
    {
        /// <summary>
        /// Standardizes the specified expertise.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy"></param>
        /// <param name="level"></param>
        /// <returns>A standarized expertise.</returns>
        Expertise IExpertiseStandardizer.Standardize(Expertise expertise, Hierarchy hierarchy, int level)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");

            var result = new Expertise(expertise.Interval);
            foreach (var item in expertise.Opinions)
            {
                var lowerTuple = hierarchy.Translate(item.LowerOpinion, level);
                var upperTuple = hierarchy.Translate(item.UpperOpinion, level);
                result.Opinions.Add(new Opinion(lowerTuple, upperTuple));
            }
            return result;
        }
    }
}