﻿using BizVal.Model;

namespace BizVal
{
    public interface ICwAggregator
    {
        Interval AggregateByExpertone(Expertise expertise);
    }
}