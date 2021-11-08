using System;

namespace FlatexToSQL.DataModels
{
    public abstract class FlatexAction
    {
        public abstract string ID { get; }
        public abstract DateTime DateTime { get; }
        public abstract double EffectiveValue { get; }
    }
}
