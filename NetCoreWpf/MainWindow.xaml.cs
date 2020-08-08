using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using ControlzEx.Standard;
using SourceChord.FluentWPF;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Data;

namespace NetCoreWpf
{
    /// </summary>
    /// Interaction logic for MainWindow.xaml
    /// <summary>
    public partial class MainWindow : MetroWindow
    {
        private int portNumber;
        private int timeout;
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
            this.Loaded += MainWindow_Loaded;
        }
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
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

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ParseFromString();
            Server.OpenConnection(AdressTxtBox.Text, portNumber, timeout, DatabaseTxtBox.Text, AuthSlider.IsChecked.Value, LoginBox.Text, PassBox.Password);
            if (Server.appConnection.State == ConnectionState.Open)
            {
                new WorkspaceWindow().Show();
                this.Close();
            }
           
        }

        #region WindowCommands
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
            base.OnMouseLeftButtonDown(e);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ExitApplication();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            App.MaxResWindow(this, sender);
        }

        private void MinWindBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MinWindow(this);
        }
        #endregion

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Animation.SlideAnimation(SettingsSliderGrid, SettingsSliderGrid.Margin, new Thickness(717, 0, 0, 0), 0.3);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            Animation.SlideAnimation(SettingsSliderGrid, SettingsSliderGrid.Margin, new Thickness(990, 0, -273, 0), 0.3);
        }

        /// <summary>
        /// Метод загрузки настроек.
        /// </summary>
        private void LoadSettings()
        {
            AdressTxtBox.Text = AppSettings.Default.server_adress;
            PortTxtBox.Text = AppSettings.Default.server_port.ToString();
            TimeoutTxtBox.Text = AppSettings.Default.server_timeout.ToString();
            DatabaseTxtBox.Text = AppSettings.Default.server_catalog;
            AuthSlider.IsChecked = AppSettings.Default.server_auth;
            ColorComboBox.Text = AppSettings.Default.app_Color;
            ThemeSlider.IsChecked = AppSettings.Default.app_Theme;
            LanguageSlider.IsChecked = AppSettings.Default.app_lang == "EN" ? true : false;
        }
        /// <summary>
        /// Метод сохранения настроек
        /// </summary>
        private void SaveSettings()
        {
            ParseFromString();
            AppSettings.Default.server_adress = AdressTxtBox.Text;
            AppSettings.Default.server_port = portNumber;
            AppSettings.Default.server_timeout = timeout;
            AppSettings.Default.server_catalog = DatabaseTxtBox.Text;
            AppSettings.Default.server_auth = AuthSlider.IsChecked.Value;
            AppSettings.Default.app_Color = ColorComboBox.Text;
            AppSettings.Default.app_Theme = ThemeSlider.IsChecked.Value;
            AppSettings.Default.app_lang = LanguageSlider.IsChecked == true ? "EN" : "RU";
            AppSettings.Default.Save();
        }

        /// <summary>
        /// Метод парсинга строк
        /// </summary>
        private void ParseFromString()
        {
            int.TryParse(PortTxtBox.Text, out int _portNumber);
            int.TryParse(TimeoutTxtBox.Text, out int _timeout);
            portNumber = _portNumber == 0 ? 1433 : _portNumber;
            timeout = _timeout == 0 ? 20 : _timeout;
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            Animation.SlideAnimation(SettingsSliderGrid, SettingsSliderGrid.Margin, new Thickness(990, 0, -273, 0), 0.3);
        }

        private void ThemeSlider_Click(object sender, RoutedEventArgs e)
        {
            Settings.SetAppTheme(ThemeSlider.IsChecked.Value, this);
        }

        private void LanguageSlider_Click(object sender, RoutedEventArgs e)
        {
            string lang = LanguageSlider.IsChecked == true ? "EN" : "RU";
            Settings.SetAppLang(lang);
        }

        private void FluentDesignSlider_Checked(object sender, RoutedEventArgs e)
        {
            App.EnableFluentWindow(this, AppSettings.Default.app_fluent);
        }

        private void ColorComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            Settings.SetAppColor(item.Content.ToString());
        }

        /// <summary>
        /// Метод изменяет стиль и положения элементов на окне если не поддерживается Fluent Design (Acrylic Window)
        /// </summary>
        private void NotFluentWindow()
        {       
            LoginCardGrid.Margin = new Thickness(584, 0, 0, 0);
            LoginCardGrid.SetResourceReference(Grid.BackgroundProperty, "Theme_2");
            LoginLabel.SetResourceReference(Label.ForegroundProperty, "ThemeForeground");
            PassLabel.SetResourceReference(Label.ForegroundProperty, "ThemeForeground");
            ExitBtn.SetResourceReference(Button.ForegroundProperty, "ThemeForeground");
            SettingsBtn.SetResourceReference(Button.ForegroundProperty, "ThemeForeground");
            TrayBtn.SetResourceReference(Button.ForegroundProperty, "ThemeForeground");
            SignInLabel.SetResourceReference(Label.ForegroundProperty, "ThemeForeground");
            LoginBtn.SetResourceReference(Button.ForegroundProperty, "ThemeForeground");
            AuroraLabelF.Visibility = Visibility.Collapsed;
            SignInLabel.Visibility = Visibility.Visible;
            AuroraGrid.Visibility = Visibility.Visible;
            loginBGImage.Visibility = Visibility.Visible;
            LoginBox.SetResourceReference(TextBox.StyleProperty, "DefaultTextBoxStyle");
            PassBox.SetResourceReference(TextBox.StyleProperty, "DefaultPassBoxStyle");
        }

    }
}
