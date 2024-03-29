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
        private ObservableCollection<int> process = new ObservableCollection<int> { 0, 0, 0, 0, 0, 0 };

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

        public class SingleTimeBar
        {
            public int Begin { get; set; }
            public int End { get; set; }
            public SingleTimeBar(int b, int e)
            {
                Begin = b;
                End = e;
            }
        }

        List<SingleTimeBar> timeBars = new List<SingleTimeBar>
        {
            new SingleTimeBar(900,1030),
            new SingleTimeBar(1030,1200),
            new SingleTimeBar(1300,1430),
            new SingleTimeBar(1430,1600),
            new SingleTimeBar(1600,1730),
            new SingleTimeBar(1800,1930),
        };
        private int GetTotalMinutes(int timeInt)
        {
            // 将1020(10H20M)这种形式的时间转换为620(620分钟)
            return timeInt / 100 * 60 + timeInt % 100;
        }
        private void UpdateProcessByTime(DateTime time)
        {
            //将时间转换为数字
            string timeStr = time.ToString("HHmm");
            int timeInt = int.Parse(timeStr);
            if(timeInt <=0030) // 1 软件初次启动所有进度都会清零，如果连续运行超过1天，过了12点也会给清零
            {
                for(int i=0;i<Process.Count;i++)
                {
                    Process[i] = 0;
                }
            }
            // 现在得到了时间 1534，查找对应的段，如果还没到开始，
            for (int i = 0; i < timeBars.Count; i++)
            {
                if (timeInt <= timeBars[i].Begin)
                {
                    // 还没到这个的开始，结束后续处理
                    break;
                }
                if (timeInt >= timeBars[i].End)
                {
                    // 这一段已经结束
                    Process[i] = 100;
                }
                else
                {
                    // 位于中间
                    double process = 0;
                    int beginMinutes = GetTotalMinutes(timeBars[i].Begin);
                    int endMinutes = GetTotalMinutes(timeBars[i].End);
                    int currentMinutes = GetTotalMinutes(timeInt);
                    Process[i] = (currentMinutes - beginMinutes) * 100 / (endMinutes - beginMinutes);
                }
            }
        }
        private void Update(object? sender, EventArgs e)
        {
            // 更新时间
            CurrentTime = DateTime.Now;
            // 更新进度
            UpdateProcessByTime(CurrentTime);
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
