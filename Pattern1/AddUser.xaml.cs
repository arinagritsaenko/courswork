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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public enum RegistrationMode
    {
        CalledByAdmin,
        CalledByAuthorization
    }
    public partial class AddUser : Window
    {
        IAuthorizationAccess module;
        RegistrationMode mode;
        public  TypeOfUser type;
        public AddUser(IAuthorizationAccess access, RegistrationMode openMode)
        {
            module = access;
            mode = openMode;
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (EditPass.Password != EditPassRepeat.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            switch (mode)
            {
                case RegistrationMode.CalledByAdmin:
                    {
                        TypeOfUser registrationType = (TypeOfUser)ComboStatus.SelectedIndex;
                        switch (registrationType)
                        {
                            case TypeOfUser.Admin:
                                {
                                    Admin adminToRegister = new Admin(EditLogin.Text, EditPass.Password);
                                    switch ((module as IAdminAccess).RegisterNewAdmin(adminToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Admin;
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Client:
                                {
                                    Client clientToRegister = new Client(EditLogin.Text, EditPass.Password);
                                    switch ((module as IAdminAccess).RegisterNewClient(clientToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Client;
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Expert:
                                {
                                    Expert expertToRegister = new Expert(EditLogin.Text, EditPass.Password);
                                    switch ((module as IAdminAccess).RegisterNewExpert(expertToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Expert;
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Undefined:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case RegistrationMode.CalledByAuthorization:
                    {
                        TypeOfUser registrationType = (TypeOfUser)ComboStatus.SelectedIndex;
                        switch (registrationType)
                        {
                            case TypeOfUser.Admin:
                                {
                                    Admin adminToRegister = new Admin(EditLogin.Text, EditPass.Password);
                                    switch (module.Registration(registrationType, adminToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Admin;
                                                this.Close();
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Client:
                                {
                                    Client clientToRegister = new Client(EditLogin.Text, EditPass.Password);
                                    switch (module.Registration(registrationType, clientToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Client;
                                                this.Close();
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Expert:
                                {
                                    Expert expertToRegister = new Expert(EditLogin.Text, EditPass.Password);
                                    switch (module.Registration(registrationType, expertToRegister))
                                    {
                                        case AnswerFromServer.Successfully:
                                            {
                                                MessageBox.Show("Успешно");
                                                type = TypeOfUser.Expert;
                                                this.Close();
                                                break;
                                            }
                                        case AnswerFromServer.Error:
                                            {
                                                MessageBox.Show("Ошибка");
                                                break;
                                            }
                                        case AnswerFromServer.UnknownCommand:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case TypeOfUser.Undefined:
                                break;
                            default:
                                break;
                        }
                        
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
