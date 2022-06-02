using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
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
using TCPConnectionAPIClientModule_C_sharp_;

namespace Pattern1
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class UserControl : Window
    {
        IUserModifyAccess module;
        Client selectedObj;
        List<Client> clients;
        public UserControl(IUserModifyAccess module)
        {
            this.module = module;
            InitializeComponent();
            clients = module.GetAllClients();
            GridUsers.ItemsSource = clients;
            selectedObj = new Client();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (var item in clients)
            {
                switch (module.ModifyClient(item))
                {
                    case AnswerFromServer.Successfully:
                        break;
                    case AnswerFromServer.Error:
                        {
                            module.RegisterNewClient(item);
                            break;
                        }
                    case AnswerFromServer.UnknownCommand:
                        break;
                    default:
                        break;
                }
            }
        }

        private void GridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedObj = GridUsers.SelectedItem as Client;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void GridUsers_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && selectedObj != null)
            {
                clients.RemoveAll(c => c.Id == selectedObj.Id);
                switch (module.DeleteClientWith(selectedObj.Login))
                {
                    case AnswerFromServer.Successfully:
                        {
                            MessageBox.Show("Успешно!");
                            break;
                        }
                    case AnswerFromServer.Error:
                        {
                            MessageBox.Show("Ошибка!");
                            break;
                        }
                    case AnswerFromServer.UnknownCommand:
                        break;
                    default:
                        break;
                }
                GridUsers.ItemsSource = new List<Carrier>();
                GridUsers.ItemsSource = clients;
            }
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {

        }
    }
}
