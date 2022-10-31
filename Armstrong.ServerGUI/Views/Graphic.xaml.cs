using OxyPlot;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Armstrong.WinServer.Models;

namespace Armstrong.WinServer.Views
{
    /// <summary>
    /// Логика взаимодействия для Graphic.xaml
    /// </summary>
    public partial class Graphic : Window
    {
        public readonly List<ChannelChartInfo> channelsList;

        public Graphic(List<ChannelChartInfo> channelsList)
        {
            InitializeComponent();
            this.channelsList = channelsList;
            this.DataContext = this;

            InfoListView.ItemsSource = channelsList;

            SetSeries();
        }

        public void SetSeries()
        {
            foreach(var channel in channelsList)
            {
                MainPlot.Series.Add(channel.Series);
            }
        }
    }
}
