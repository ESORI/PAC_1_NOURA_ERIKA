﻿using System;
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
using WPF_MVVM_SPA_Template.ViewModels;

namespace WPF_MVVM_SPA_Template.Views
{
    /// <summary>
    /// Interaction logic for ClientFormView.xaml
    /// </summary>
    public partial class ClientFormView : UserControl

    {
        private MainViewModel _mainViewModel;
      
        
        
        public ClientFormView()
        {
            InitializeComponent();
            _mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            







        }

       
    }
}
