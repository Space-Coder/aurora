using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace NetCoreWpf
{
    /// <summary>
    /// Логика взаимодействия для WorkspaceWindow.xaml
    /// </summary>
    public partial class WorkspaceWindow : MetroWindow
    {
        private bool isMenuOpen = false;
        private bool isSettingsOpen = false;
        public WorkspaceWindow()
        {
            InitializeComponent();
            LoadSettings();
            this.Loaded += WorkspaceWindow_Loaded;
            workspaceDataGrid.MouseLeftButtonDown += WorkspaceDataGrid_MouseLeftButtonDown;
        }

        private void WorkspaceDataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void WorkspaceWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.isFluentSupported == true && AppSettings.Default.app_fluent == true)
            {
                App.EnableFluentWindow(this, true);
            }
            else
            {
                NotFluentWindow();
            }
        }


        #region Commands

       

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ExitApplication();
        }

        private void MaxResBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MaxResWindow(this, MaxResBtn);
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MinWindow(this);
        }

        #endregion

        private void NotFluentWindow()
        {
            this.SetResourceReference(Window.BackgroundProperty, "Theme_1");
        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuOpen)
            {
                Animation.SlideAnimation(WorkspaceGrid, WorkspaceGrid.Margin, new Thickness(50, 0, 0, 0), 0.3);
                isMenuOpen = false;
            }
            else
            {
                Animation.SlideAnimation(WorkspaceGrid, WorkspaceGrid.Margin, new Thickness(200, 0, 0, 0), 0.3);
                isMenuOpen = true;
            }
        }

        private void TablesBtn_Click(object sender, RoutedEventArgs e)
        {
            TablesWindow tablesWind = new TablesWindow();
            if (tablesWind.ShowDialog() == true)
            {
                workspaceDataGrid.ItemsSource = Server.ExecuteCommand("SELECT * FROM " + TablesWindow.tableName).DefaultView;
            }
        }

        private void QBuilderBtn_Click(object sender, RoutedEventArgs e)
        {
            SQLCmdWindow queryBuilderWind = new SQLCmdWindow();
            queryBuilderWind.Owner = this;
            queryBuilderWind.Show();
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isSettingsOpen)
            {
                Animation.SlideAnimation(SettingsGrid, new Thickness(0), new Thickness(0, -90, 0, 90), 0.3);
                Animation.OpacityAnimation(SettingsGrid, true, 0.2);
                isSettingsOpen = false;
                SaveSettings();
            }
            else
            {
                Animation.SlideAnimation(SettingsGrid, new Thickness(0, -90, 0, 90), new Thickness(0), 0.4);
                Animation.OpacityAnimation(SettingsGrid, false, 0.5);
                isSettingsOpen = true;
            }
            
        }


        private void ColorComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            Settings.SetAppColor(item.Content.ToString());
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsBtn_Click(sender, e);
        }

        private void ThemeSlider_Click(object sender, RoutedEventArgs e)
        {
            Settings.SetAppTheme(ThemeSlider.IsChecked.Value, this);
        }

        private void FluentDesignSlider_Click(object sender, RoutedEventArgs e)
        {
            if (FluentDesignSlider.IsChecked == true)
            {
                App.EnableFluentWindow(this, true);
                this.Background = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                App.EnableFluentWindow(this, false);
                NotFluentWindow();
            }
        }

        private void LanguageSlider_Click(object sender, RoutedEventArgs e)
        {
            string result = LanguageSlider.IsChecked == true ? "EN" : "RU";
            Settings.SetAppLang(result);
        }

        private void LoadSettings()
        {

            ColorComboBox.Text = AppSettings.Default.app_Color;
            ThemeSlider.IsChecked = AppSettings.Default.app_Theme;
            if (App.isFluentSupported == false)
            {
                FluentDesignSlider.IsEnabled = false;
            }
            FluentDesignSlider.IsChecked = AppSettings.Default.app_fluent;
            LanguageSlider.IsChecked = AppSettings.Default.app_lang == "EN" ? true : false;
            ManagementObjectSearcher osInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher ramInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectSearcher cpuInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject queryObj in osInfo.Get())
            {
                osLabel.Content = string.Format("{0} Build ({1})", queryObj["Caption"], queryObj["BuildNumber"]);
                sysTypeLabel.Content = string.Format("{0}", queryObj["OSArchitecture"]);
                compNameLabel.Content = Environment.MachineName;
                userLabel.Content = Environment.UserName;
            }
            foreach (ManagementObject queryObj in ramInfo.Get())
            {
                ramLabel.Content = Math.Round(Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2).ToString() + " GB";
            }
            foreach (ManagementObject queryObj in cpuInfo.Get())
            {
                cpuLabel.Content = string.Format("{0}", queryObj["Name"]);
            }
        }

        private void SaveSettings()
        {

            AppSettings.Default.app_Color = ColorComboBox.Text;
            AppSettings.Default.app_Theme = ThemeSlider.IsChecked.Value;
            AppSettings.Default.app_fluent = FluentDesignSlider.IsChecked.Value;
            AppSettings.Default.app_lang = LanguageSlider.IsChecked == true ? "EN" : "RU";
            AppSettings.Default.Save();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            SaveBtn_Click(sender, e);
            Server.appConnection.Close();
            new MainWindow().Show();
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (workspaceDataGrid.ItemsSource != null)
            {
                Server.DataUpdate();
            }
        }
    }
}
