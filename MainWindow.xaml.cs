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

namespace WaterDrink
{
    /// <summary>
    /// MainWIndow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWIndow : Window
    {
        public MainWIndow()
        {
            InitializeComponent();
            WaterDrink.View.WaterDrink waterDrink = new WaterDrink.View.WaterDrink();
            UserControlHost.Content = waterDrink;
        }
    }
}
