using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace LichtbandzargeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            //It's responsible for initializing the XAML components and the visual aspects of the window:
            InitializeComponent();
            //This allows the XAML in your view to bind to the properties and commands exposed by the ViewModel
            DataContext = new ViewModel.MainViewViewModel();

        }
               
    }
}
