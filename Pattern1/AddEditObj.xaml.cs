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
using DatabaseEntities;
using ClassLibraryForTCPConnectionAPI_C_sharp_;
using TCPConnectionAPIClientModule_C_sharp_;

namespace Pattern1
{
    /// <summary>
    /// Interaction logic for AddEditObj.xaml
    /// </summary>
    public enum AddEditObjMode
    {
        Adding,
        Editing
    }
    public partial class AddEditObj : Window
    {
        private AddEditObjMode mode;
        private IDataModifyAccess module;
        private Carrier carrierToEditOrCreate;
        public AddEditObj(IDataModifyAccess module, AddEditObjMode mode, Carrier carrier = null)
        {
            InitializeComponent();
            this.module = module;
            this.mode = mode;
            carrierToEditOrCreate = carrier;
            switch (mode)
            {
                case AddEditObjMode.Adding:
                    {
                        Title.Text = "Добавление";
                        carrierToEditOrCreate = new Carrier();
                        break;
                    }
                case AddEditObjMode.Editing:
                    {
                        Title.Text = "Редактирование";
                        if (carrier == null)
                        {
                            MessageBox.Show("Ошибка!");
                            break;
                        }
                        FirstField.Text = carrier.Name;
                        SecondField.Text = carrier.RegistrationNumber.ToString();
                        ThirdField.Text = carrier.Traffic.ToString();
                        FourthField.Text = carrier.AmountOfShips.ToString();
                        FifthField.Text = carrier.TotalRate.ToString();
                        break;
                    }
                default:
                    break;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carrierToEditOrCreate.Name = FirstField.Text;
                carrierToEditOrCreate.RegistrationNumber = int.Parse(SecondField.Text);
                carrierToEditOrCreate.Traffic = int.Parse(ThirdField.Text);
                carrierToEditOrCreate.AmountOfShips = int.Parse(FourthField.Text);
                carrierToEditOrCreate.TotalRate = double.Parse(FifthField.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }

            switch (mode)
            {
                case AddEditObjMode.Editing:
                    {
                        switch (module.ModifyCarrier(carrierToEditOrCreate))
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
                        break;
                    }
                case AddEditObjMode.Adding:
                    {
                        switch (module.CreateCarrier(carrierToEditOrCreate))
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
                        break;
                    }
                default:
                    break;

            }
        }
    }
}
