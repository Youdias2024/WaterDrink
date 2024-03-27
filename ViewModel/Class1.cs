using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterDrink.ViewModel
{
    internal class Class1
    {
    }

    public partial class WaterDrink_ViewModel_1 : ObservableObject
    {
        // VM 数据结构
        // 存放的有：当前时间， 目标进度(分三个记录)
        // 对应6个百分比
        // 

        // UI 展示：
        // 一个时间轴进度条：从0600到2200，上面有一个点显示当前实时时间


        // 当前时间，精确到秒
        [ObservableProperty]
        private DateTime currentTime = DateTime.Now;
        // 时间轴进度条
        [ObservableProperty]
        private double timeLine = 0;

        // 6个进度条
        [ObservableProperty]
        private double[] process = { 0 };

    }
}
