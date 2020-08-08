using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace NetCoreWpf
{
    /// <summary>
    /// Логика взаимодействия для TablesWindow.xaml
    /// </summary>
    public partial class TablesWindow : MetroWindow
    {
        public static string tableName = null;
        public TablesWindow()
        {
            InitializeComponent();
            this.Loaded += TablesWindow_Loaded;
        }

        private void TablesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tablesDataGrid.ItemsSource = Server.ExecuteCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES").DefaultView;
        }

        private void SelectTable_Click(object sender, RoutedEventArgs e)
        {
            if (tablesDataGrid.SelectedItem != null)
            {
                tableName = ((DataRowView)tablesDataGrid.SelectedItem).Row[0].ToString();
            }
            this.DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.DragMove();
            base.OnMouseLeftButtonDown(e);
        }
    }
}
