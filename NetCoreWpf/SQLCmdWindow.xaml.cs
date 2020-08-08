using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using MahApps.Metro.Controls;

namespace NetCoreWpf
{
    /// <summary>
    /// Логика взаимодействия для SQLCmdWindow.xaml
    /// </summary>
    public partial class SQLCmdWindow : MetroWindow
    {
        public SQLCmdWindow()
        {
            InitializeComponent();
            using XmlTextReader reader = new XmlTextReader("SQLSyntaxH.xshd");
            queryTextBox.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if(window is WorkspaceWindow)
                {
                    WorkspaceWindow wk = (WorkspaceWindow)window;
                    wk.workspaceDataGrid.ItemsSource = Server.ExecuteCommand(queryTextBox.Text).DefaultView;
                }
            }
            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MinWindow(this);
        }

        private void MaxResBtn_Click(object sender, RoutedEventArgs e)
        {
            App.MaxResWindow(this, MaxResBtn);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.DragMove();
            base.OnMouseLeftButtonDown(e);
        }
    }
}
