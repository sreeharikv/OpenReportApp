﻿using System;

namespace OpenReportApp.Model.Dapper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IgnorePropertyAttribute : Attribute
    {
        public IgnorePropertyAttribute(bool ignore)
        {
            Value = ignore;
        }

        public bool Value { get; set; }
    }
}
