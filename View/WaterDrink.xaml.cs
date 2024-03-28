using HandyControl.Controls;
using HandyControl.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaterDrink.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Threading;
using System.ComponentModel.Design;

namespace WaterDrink.View
{
    /// <summary>
    /// WaterDrink.xaml 的交互逻辑
    /// </summary>
    public partial class WaterDrink : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        WaterDrink_ViewModel vm = new WaterDrink_ViewModel();
        private void Update(object? sender, EventArgs e)
        {
            MyTimeBar.SelectedTime = vm.CurrentTime;
        }
        // TODO# 页面关闭的时候最好需要关闭定时器，可以用命令聚合器处理。暂不处理

        public WaterDrink()
        {
            InitializeComponent();
            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();

            
            this.DataContext = vm;

            MyTimeBar.SelectedTime = vm.CurrentTime;

            //MyTimeBar.SetBinding(TimeBar.SelectedTimeProperty, new Binding("CurrentTime")
            //{
            //    Source = this.DataContext,
            //    Mode = BindingMode.TwoWay
            //});

            // MyTimeBar.SelectedTime = "1234-5-6 12:23:32";

        }
    }
}
