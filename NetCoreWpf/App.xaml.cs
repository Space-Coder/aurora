using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;

namespace NetCoreWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool isWindows10 = false;
        public static bool isFluentSupported = false;
        public static uint color;
        public App()
        {
            InitializeComponent();
            Settings.SetAppColor(AppSettings.Default.app_Color);
            Settings.SetAppLang(AppSettings.Default.app_lang);
            Settings.SetAppTheme(AppSettings.Default.app_Theme, null);
            CheckWindowSystem();
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
        /// <summary>
        /// Метод проверки ОС, указывает может ли приложение использовать Fluent Design System
        /// </summary>
        private void CheckWindowSystem()
        {
            isWindows10 = Environment.OSVersion.Version.Major == 10 ? true : false;
            isFluentSupported = Environment.OSVersion.Version.Build >= 17763 ? true : false;
        }
        /// <summary>
        /// Метод включения Fluent Design (Acrylic Window) для окна.
        /// </summary>
        /// <param name="window">Окно к которому применяется эффект Acrylic</param>
        public static void EnableFluentWindow(Window window , bool isEnabled)
        {
            if (isFluentSupported == true)
            {
                var windowHelper = new WindowInteropHelper(window);
                AcrylicWindow.EnableBlur(windowHelper.Handle, color, isEnabled);
            }
        }

        /// <summary>
        /// Метод выхода из приложения
        /// </summary>
        public static void ExitApplication()
        {
            MessageBoxResult res = MessageBox.Show(Current.Resources["mbox_ExitText"].ToString(), Current.Resources["mbox_Exit"].ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Метод скрытия окна в трей.
        /// </summary>
        /// <param name="obj">Окно которое необходимо скрыть в трей</param>
        public static void MinWindow(Window obj)
        {
            obj.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Метод изменения размера окна
        /// </summary>
        /// <param name="obj">Окно которому необходимо изменить размер</param>
        /// <param name="sender">Кнопка "НЭЙМ"</param>
        public static void MaxResWindow(Window obj, object sender)
        {
            ToggleButton MaxResBtn = (ToggleButton)sender;  
            if (MaxResBtn.IsChecked == true)
            {
                obj.WindowState = WindowState.Maximized;
            }
            else
            {
                obj.WindowState = WindowState.Normal;
            }
        }

    }
}
