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
using Microsoft.VisualBasic;

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
            //0000-0001初始化新的一天
            string timeStr = vm.CurrentTime.ToString("HHmm");
            if (int.Parse(timeStr)>=0 && int.Parse(timeStr)<=1)
            {
                DateTime beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTimeRange dtR = new DateTimeRange();
                dtR.Start = beginTime.AddHours(9);
                dtR.End = beginTime.AddHours(20);
                MyTimeBar.Hotspots.Add(dtR);
            }
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

            // 首次启动，将当天的0900-2000设置为热点区
            DateTime beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTimeRange dtR = new DateTimeRange();
            dtR.Start = beginTime.AddHours(9);
            dtR.End = beginTime.AddHours(20);
            MyTimeBar.Hotspots.Add(dtR);
            


            // MyTimeBar.SelectedTime = "1234-5-6 12:23:32";

        }
    }
}
