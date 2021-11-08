using Microsoft.Win32;
using OpenFigi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlatexToSQL.DataModels;
using FlatexToSQL.Enums;

namespace FlatexToSQL
{
    public static class Parser
    {
        #region Generic
        public static string LoadFile()
        {
            string data = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                data = File.ReadAllText(openFileDialog.FileName);
            return data;
        }
        public static string GetValueAfterIdentifier(string identifier, string action)
        {
            string pattern = @"([^\s]+)(?=\s" + identifier + ")";
            Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = myRegex.Match(action);
            return m.Success ? m.Value : throw new Exception("value not found in " + action);
        }

        public static DateTime GetDate(string action)
        {
            string pattern = @"(\d{2}[.]\d{2}[.]\d{4})";
            Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = myRegex.Match(action);
            return m.Success ? DateTime.ParseExact(m.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture) : throw new Exception("no date found in " + action);
        }
        #endregion

        #region Order
        public static List<Order> GetOrders(Context context, string data)
        {
            List<Order> orders = new List<Order>();
            foreach (string action in data.Split("***"))
            {
                Order order = ParseOrder(context, action);
                if (order != null)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        private static Order ParseOrder(Context context, string action)
        {
            if (!action.Contains("Ausführung ORDER"))
            {
                return null;
            }

            OrderSide side = action.Contains("Kauf") ? OrderSide.Buy : OrderSide.Sell;
            string volume = GetValueAfterIdentifier("Stk", action);
            string price = GetValueAfterIdentifier("EUR", action);
            string ISIN = GetValueAfterIdentifier(volume, action);
            return new Order()
            {
                Side = side,
                FIGI = context.GetFIGI(ISIN),
                Volume = float.Parse(volume),
                Price = float.Parse(price),
                OrderDateTime = GetDate(action)
            };
        }
        #endregion

        #region Transaction
        public static List<Transaction> GetTransactions(string data)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (string action in data.Split("***"))
            {
                Transaction transaction = ParseTransaction(action);
                if (transaction != null)
                    transactions.Add(transaction);
            }
            return transactions;
        }

        private static Transaction ParseTransaction(string action)
        {
            try
            {
                return new Transaction()
                {
                    Value = float.Parse(GetValueAfterIdentifier("EUR", action)),
                    TransactionDateTime = GetDate(action)
                };
            }
            catch
            {
                return null;
            }
        }
        #endregion

    }
}
