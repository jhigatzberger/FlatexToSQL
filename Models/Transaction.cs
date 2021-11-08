using System;

namespace FlatexToSQL.DataModels
{
    public class Transaction : FlatexAction
    {
        #region SQL Mapped Properties
        public int TransactionID { get; set; }
        public float Value { get; set; }
        public DateTime TransactionDateTime { get; set; }
        #endregion

        #region Flatex Action Abstraction
        public override string ID
        {
            get
            {
                return "T" + TransactionID;
            }
        }
        public override double EffectiveValue
        {
            get
            {
                return Value;
            }
        }
        public override DateTime DateTime
        { 
            get
            {
                return TransactionDateTime;
            }
        }
        #endregion
    }
}