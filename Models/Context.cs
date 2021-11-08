using Microsoft.EntityFrameworkCore;
using OpenFigi;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FlatexToSQL.DataModels
{
    public class Context: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server = localhost; Database = flatexsql; Uid = root; Pwd = root;");
        }

        public string GetFIGI(string ISIN)
        {
            Stock stock = Stocks.Where(s => s.ISIN.Equals(ISIN)).FirstOrDefault();
            if (stock != null)
            {
                Debug.WriteLine(stock.Ticker);
                return stock.FIGI;
            }
            else
            {
                OpenFigiStockData data = OpenFIGI.GetStockData(new List<OpenFIGIRequest> { new OpenFIGIRequest("ID_ISIN", ISIN) });
                if (data != null)
                {
                    Stocks.Add(new Stock
                    {
                        FIGI = data.Figi,
                        Ticker = data.Ticker,
                        ISIN = ISIN
                    });
                    SaveChanges();
                    return data.Figi;
                }
            }
            return null;
        }

        public List<Order> AllTickerOrders(string ticker)
        {
            return Orders.Join(Stocks.Where(s => s.Ticker == ticker), s => s.FIGI, o => o.FIGI, (order, stock) => order).ToList();
        }

        public List<FlatexAction> GetAllActions()
        {
            List<FlatexAction> actions = new();
            actions.AddRange(Orders.ToList());
            actions.AddRange(Transactions.ToList());
            return actions;
        }

        public void SetOrders(List<Order> orders)
        {
            RemoveRange(Orders.ToList());
            Orders.AddRange(orders);
            SaveChanges();
        }
        public void SetTransactions(List<Transaction> transactions)
        {
            RemoveRange(Transactions.ToList());
            Transactions.AddRange(transactions);
            SaveChanges();
        }
    }
}
