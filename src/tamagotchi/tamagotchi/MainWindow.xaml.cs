using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tamagotchi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        ProgressBar feedBar;

        Dog mainDog;
        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += engine;

            timer.Interval = TimeSpan.FromMilliseconds(20);

            timer.Start();

            mainDog = new Dog();


            for (int i = 0; i < 5; i++)
            {
                main.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 5; i++)
            {
                main.ColumnDefinitions.Add(new ColumnDefinition());
            }

            feedBar = new ProgressBar
            {
                Value = 1,
                Maximum = 1

            };

            main.Children.Add(feedBar);

            feedBar.SetValue(Grid.RowProperty, 1);
            feedBar.SetValue(Grid.ColumnProperty, 0);
            feedBar.SetValue(Grid.ColumnSpanProperty, 3);

        }

        public void clickToFeed(object sender, RoutedEventArgs e)
        {
            mainDog.Feed();
        }

        private void engine(object sender, EventArgs e)
        {
            feedBar.Value = mainDog.Feedability;
            mainDog.update();

            if(mainDog.Feedability < 0) System.Windows.Application.Current.Shutdown();
        }
    }
}
