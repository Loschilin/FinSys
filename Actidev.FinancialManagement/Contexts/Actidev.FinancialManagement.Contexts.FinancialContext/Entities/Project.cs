﻿using System;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}