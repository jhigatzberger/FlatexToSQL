using FlatexToSQL.DataModels;
using FlatexToSQL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatexToSQL.ViewModels
{
    public class OrderViewModel
    {
        private Order order;
        public string Value
        {
            get
            {
                return order.EffectiveValue.ToString();
            }
        }
        public string Date
        {
            get
            {
                return order.DateTime.ToString();
            }
        }
        public override string ToString()
        {
            return order.DateTime.ToString() + " " + order.Side.ToString() + " " + order.EffectiveValue;
        }
        public OrderViewModel(Order order)
        {
            this.order = order;
        }
        public static List<OrderViewModel> Query(string query)
        {
            List<Order> orders = new Context().AllTickerOrders(query);
            List<OrderViewModel> viewModels = new();
            foreach (Order order in orders)
                viewModels.Add(new OrderViewModel(order));
            return viewModels;
        }
    }
}
