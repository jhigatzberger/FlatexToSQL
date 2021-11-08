using System;
using System.Windows;
using FlatexToSQL.DataModels;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.Win32;
using System.Diagnostics;
using OpenFigi;
using FlatexToSQL.Views;
using FlatexToSQL.ViewModels;

namespace FlatexToSQL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowGraph(object sender, RoutedEventArgs e)
        {
            new GraphView().Show();
        }
        private void LoadOrders(object sender, RoutedEventArgs e)
        {
            using Context context = new Context();
            context.SetOrders(Parser.GetOrders(context, Parser.LoadFile()));
        }
        private void LoadTransactions(object sender, RoutedEventArgs e)
        {
            new Context().SetTransactions(Parser.GetTransactions(Parser.LoadFile()));
        }

        private void QueryTicker(object sender, RoutedEventArgs e)
        {
            new OrderView(OrderViewModel.Query(query_input.Text)).Show();
        }
    }
}
