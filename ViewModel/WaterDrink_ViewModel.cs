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
        //private DateTime currentTime = DateTime.Now;
        private DateTime currentTime = new DateTime();
        // 时间轴进度条
        [ObservableProperty]
        private double timeLine = 0;

        // 6个进度条
        [ObservableProperty]
        private double[] process = { 0 };


        private RelayCommand _btnExit;
        public RelayCommand ButtonExit => _btnExit ??= new RelayCommand(Exit);

        [RelayCommand]
        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
