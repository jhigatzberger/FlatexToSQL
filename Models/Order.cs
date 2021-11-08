using System;
using FlatexToSQL.Enums;

namespace FlatexToSQL.DataModels
{
    public class Order : FlatexAction
    {
        #region SQL Mapped Properties
        public int OrderID { get; set; }
        public string FIGI { get; set; }
        public OrderSide Side { get; set; }
        public float Volume { get; set; }
        public float Price { get; set; }
        public DateTime OrderDateTime { get; set; }
        #endregion

        #region Flatex Action Abstraction
        public override string ID {
            get
            {
                return "O" + ID;
            }
        }
        public override double EffectiveValue
        {
            get
            {
                return Volume * Price;
            }
        }
        public override DateTime DateTime
        {
            get
            {
                return OrderDateTime;
            }
        }
        #endregion
    }
}
