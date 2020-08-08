using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NetCoreWpf
{
    /// <summary>
    /// Класс отвечающй за настройку приложения. Цвет, тема, язык.
    /// </summary>
    class Settings
    {
        /// <summary>
        /// Метод изменения языка приложения
        /// </summary>
        /// <param name="lang">Название (имя) языка.</param>
        public static void SetAppLang(string lang)
        {
            ResourceDictionary langResDic = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resources/Languages/" + lang + ".xaml", UriKind.RelativeOrAbsolute)
            };
            Application.Current.Resources.MergedDictionaries.Add(langResDic);
        }
        /// <summary>
        /// Метод изменения цветовой темы приложения.
        /// </summary>
        /// <param name="appTheme">Если = <see langword="true"/>, тёмная тема. Если <see langword="false"/>, светлая тема.</param>
        public static void SetAppTheme(bool appTheme, Window window)
        {
            ResourceDictionary themeResDic = new ResourceDictionary();
            if (appTheme == true)
            {
                themeResDic.Source = new Uri("pack://application:,,,/Resources/Controls/Colors/Theme.Dark.xaml", UriKind.RelativeOrAbsolute);
                App.color = 0x0000000F;
            }
            else
            {
                themeResDic.Source = new Uri("pack://application:,,,/Resources/Controls/Colors/Theme.Light.xaml", UriKind.RelativeOrAbsolute);
                App.color = 0x0FFFFFFF;
            }
            if (App.isFluentSupported == true)
            {
                App.EnableFluentWindow(window, AppSettings.Default.app_fluent);
            }
            Application.Current.Resources.MergedDictionaries.Add(themeResDic);
        }
       /// <summary>
       /// Метод изменения цветовой схемы приложения.
       /// </summary>
       /// <param name="colorName">Название (имя) цветовой схемы.</param>
        public static void SetAppColor(string colorName)
        {
            ResourceDictionary colorResDic = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resources/Controls/Colors/Accent." + colorName + ".xaml", UriKind.RelativeOrAbsolute)
            };
            Application.Current.Resources.MergedDictionaries.Add(colorResDic);
        }
    }
}
