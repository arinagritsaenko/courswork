using ClassLibraryForTCPConnectionAPI_C_sharp_;
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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        IAuthorizationAccess module;
        public TypeOfUser type { get; set; }
        public Authorization(IAuthorizationAccess module, ref TypeOfUser type)
        {
            InitializeComponent();
            this.module = module;
            this.type = type;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            type = module.Authorization(EditLogin.Text, EditPass.Password);
            switch (type)
            {
                case TypeOfUser.Admin:
                    {
                        MessageBox.Show("Вы авторизовались как администратор!");
                        type = TypeOfUser.Admin;
                        this.Close();
                        break;
                    }
                case TypeOfUser.Client:
                    {
                        MessageBox.Show("Вы авторизовались как пользователь!");
                        type = TypeOfUser.Client;
                        this.Close();

                        break;
                    }
                case TypeOfUser.Expert:
                    {
                        MessageBox.Show("Вы авторизовались как эксперт!");
                        type = TypeOfUser.Expert;
                        this.Close();
                        break;
                    }
                case TypeOfUser.Undefined:
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                        break;
                    }
                default:
                    break;
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(module, RegistrationMode.CalledByAuthorization);
            addUser.ShowDialog();
            type = addUser.type;
            if (type != TypeOfUser.Undefined)
            {
                this.Close();
            }
        }
    }
}
