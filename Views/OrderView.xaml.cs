using FlatexToSQL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlatexToSQL.Views
{
    public partial class OrderView : Window
    {
        public OrderView(List<OrderViewModel> list)
        {
            InitializeComponent();
            foreach(OrderViewModel o in list)
            {
                listview.Items.Add(o);
            }
        }
    }
}
