using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NetCoreWpf
{
    /// <summary>
    /// Класс отвечающий за настройку сервера и подключение к нему.
    /// </summary>
    class Server
    {
        /// <summary>
        /// Представляет подключение к серверу SQL Server
        /// </summary>
        public static SqlConnection appConnection = new SqlConnection();
        private static DataTable dataSet;
        private static SqlDataAdapter dataAdapter;
        public Server()
        {
            appConnection.StateChange += AppConnection_StateChange;
        }

        /// <summary>
        /// Метод уведомляющий пользователя об обрыве соединения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            if (appConnection.State == ConnectionState.Broken)
            {
                MessageBox.Show("Connection Broken !");
                try
                {
                    appConnection.OpenAsync();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        /// <summary>
        /// Метод подключения к базе данных MS SQL Server
        /// </summary>
        /// <param name="adress">Адрес сервера.</param>
        /// <param name="timeout">Устанавливает лимит по времени для попытки подключится</param>
        /// <param name="catalog">Имя базы данных к которой будет осуществленно подключение.</param>
        /// <param name="auth">Задает режим аутентификации. Если <see langword="false"/>, аутентификация будет происходить с помощью
        /// User ID и Password. Если <see langword="true"/>, аутентификация будет происходить с помощью проверки подленности Windows</param>
        /// <param name="login">(Только если <paramref name="auth"/> = <see langword="false"/>) Задает логин пользователя MS Sql Server.</param>
        /// <param name="pass">(Только если <paramref name="auth"/> = <see langword="false"/>) Задает пароль пользователя MS Sql Server.</param>
        public static void OpenConnection(string adress, int timeout, string catalog, bool auth, string login, string pass)
        {
            SqlConnectionStringBuilder _appConStrBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = adress,
                ConnectTimeout = timeout,
                InitialCatalog = catalog,
                IntegratedSecurity = auth,
                UserID = login,
                Password = pass
            };
            appConnection.ConnectionString = _appConStrBuilder.ConnectionString;
            try
            {
                appConnection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public static DataTable ExecuteCommand(string cmd)
        {
            try
            {
                dataSet = new DataTable();
                dataAdapter = new SqlDataAdapter(cmd, Server.appConnection);
                dataAdapter.Fill(dataSet);
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
            return dataSet;
        }

        public static void DataUpdate()
        {
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet);
        }
    }
}
