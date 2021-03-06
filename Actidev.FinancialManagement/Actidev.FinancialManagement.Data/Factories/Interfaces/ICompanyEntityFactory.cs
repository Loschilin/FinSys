﻿using System;
using Actidev.FinancialManagement.Data.Entities;

namespace Actidev.FinancialManagement.Data.Factories.Interfaces
{
    public interface ICompanyEntityFactory
    {
        Company Create(Guid id, Guid useerId, string name);
    }
}