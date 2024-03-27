using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WaterDrink.ViewModel
{
    public partial class WaterDrink_ViewModel : ObservableObject
    {
        public WaterDrink_ViewModel()
        {
            
        }

        // VM 数据结构
        // 存放的有：
        // 当前时间
        // 6个百分比
        // 

        // 当前时间，精确到秒
        [ObservableProperty]
        private DateTime currentTime = DateTime.Now;
        //private string currentTime = "2023-5-6 12:23:32";
        
        // 时间轴进度条
        [ObservableProperty]
        private double timeLine = 0;

        // 6个进度条
        [ObservableProperty]
        private ObservableCollection<int> process = new ObservableCollection<int> { 1,2,3,4,5,6 };

        [ObservableProperty]
        private int process1 = 10;


        // ！函数名称ButtonExit，绑定的是ButtonExitCommand
        [RelayCommand] 
        private void ButtonExit()
        {
            timer.Stop();
            timer.Tick -= Update;
            Environment.Exit(0);
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void UpdateProcessByTime(DateTime time)
        {
            //将时间转换为数字
            string timeStr = time.ToString("HHmm");
            int timeInt = int.Parse(timeStr);
            // 现在得到了时间 1534，查找对应的
        }
        private void Update(object? sender,EventArgs e)
        {
            currentTime = DateTime.Now;
            //CurrentTime = DateTime.Now;
            //// 更新进度，通过map处理，开始时间，结束时间

            //UpdateProcessByTime(CurrentTime);
            // TimeBarItem

            Process[0] +=1;
            Process[0] %= 100;

            Process1 += 1;
            Process1 %= 100;
        }

        [RelayCommand]        
        public void ButtonStart()
        {
            // 开启定时器，定时更新            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();
        }
   
    }
}
