using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterDrink.ViewModel
{
    public partial class WaterDrink_ViewModel : ObservableObject
    {
        // VM 数据结构
        // 存放的有：
        // 当前时间
        // 6个百分比
        // 
        
        // 当前时间，精确到秒
        [ObservableProperty]        
        private DateTime currentTime = new DateTime();
        // 时间轴进度条
        [ObservableProperty]
        private double timeLine = 0;

        // 6个进度条
        [ObservableProperty]
        private double[] process = new double[6];




        // ！函数名称ButtonExit，绑定的是ButtonExitCommand
        [RelayCommand] 
        private void ButtonExit()
        {
            Environment.Exit(0);
        }


        [RelayCommand]        
        public void ButtonStart()
        {
            // 开启定时器，定时更新            
        }
        
        private void Update()
        {
            // 更新数据

        }
    }
}
