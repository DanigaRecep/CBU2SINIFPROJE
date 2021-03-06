﻿using System;
using System.Linq;
using System.Windows;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.ViewModels.Login;

using Microsoft.Extensions.DependencyInjection;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IAuthService authService;

        public LoginWindow(IServiceProvider serviceProvider,IAuthService authService)
        {
            InitializeComponent();
            btn_submit.Click += Btn_submit_Click;
            this.serviceProvider = serviceProvider;
            this.authService = authService;
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel model = DataContext.Cast<LoginViewModel>();
            LoginResult result = authService.Login(model);
            if (result.State!=LoginState.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
            Close();
        }
    }
}
