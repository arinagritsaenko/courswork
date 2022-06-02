using DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TCPConnectionAPIClientModule_C_sharp_;
using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System.IO;

namespace Pattern1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientConnectionModule module;
        protected List<Carrier> carriers;
        private Carrier selectedObj;
        private TypeOfUser type;
        public MainWindow()
        {
            this.module = new ClientConnectionModule();
            type = TypeOfUser.Undefined;
            Authorization authorization = new Authorization(module, ref type);
            authorization.ShowDialog();
            InitializeComponent();
            switch (authorization.type)
            {
                case TypeOfUser.Admin:
                    {
                        ExpertBtn.IsEnabled = false;
                        break;
                    }
                case TypeOfUser.Client:
                    {
                        GridObjects.CanUserAddRows = false;
                        GridObjects.CanUserDeleteRows = false;
                        GridObjects.IsReadOnly = true;
                        ExpertBtn.IsEnabled = false;
                        UserControlBtn.IsEnabled = false;
                        ReportBtn.IsEnabled = false;
                        break;
                    }
                case TypeOfUser.Expert:
                    {
                        GridObjects.CanUserAddRows = false;
                        GridObjects.CanUserDeleteRows = false;
                        GridObjects.Columns[0].IsReadOnly = true;
                        GridObjects.Columns[1].IsReadOnly = true;
                        GridObjects.Columns[2].IsReadOnly = true;
                        GridObjects.Columns[3].IsReadOnly = true;
                        GridObjects.Columns[4].IsReadOnly = false;
                        UserControlBtn.IsEnabled = false;
                        break;
                    }
                case TypeOfUser.Undefined:
                    {
                        this.Close();
                        return;
                    }
                default:
                    break;
            }
            carriers = module.GetAllCarriers();
            GridObjects.ItemsSource = carriers;
            selectedObj = new Carrier();

        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            bool sampleByTraffic = false;
            var trafficFrom = 0;
            var trafficTo = 0;
            if (int.TryParse(EditFirstFrom.Text, out trafficFrom) && int.TryParse(EditFirstTo.Text, out trafficTo))
            {
                sampleByTraffic = true;
            }
            bool sampleByAmountOfShips = false;
            var amountOfShipsFrom = 0;
            var amountOfShipsTo = 0;
            if (int.TryParse(EditSecondFrom.Text, out amountOfShipsFrom) && int.TryParse(EditSecondTo.Text, out amountOfShipsTo))
            {
                sampleByAmountOfShips = true;
            }
            bool findByRegNumber = false;
            var regNumber = 0;
            if (int.TryParse(EditRegNumber.Text, out regNumber))
            {
                findByRegNumber = true;
            }
            bool findByName = EditName.Text.Length != 0;
            
            carriers = module.GetAllCarriers();
            if (sampleByTraffic && !sampleByAmountOfShips && !findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo);
            }
            else if (!sampleByTraffic && sampleByAmountOfShips && !findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo);
            }
            else if (!sampleByTraffic && !sampleByAmountOfShips && findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.RegistrationNumber == regNumber);
            }
            else if (!sampleByTraffic && !sampleByAmountOfShips && !findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.Name == EditName.Text);
            }
            else if (sampleByTraffic && sampleByAmountOfShips && !findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo);
            }
            else if (sampleByTraffic && !sampleByAmountOfShips && findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.RegistrationNumber == regNumber);
            }
            else if (sampleByTraffic && !sampleByAmountOfShips && !findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.Name == EditName.Text);
            }
            else if (!sampleByTraffic && sampleByAmountOfShips && findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.RegistrationNumber == regNumber);
            }
            else if (!sampleByTraffic && sampleByAmountOfShips && !findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.Name == EditName.Text);
            }
            else if (!sampleByTraffic && !sampleByAmountOfShips && findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.RegistrationNumber == regNumber  && c.Name == EditName.Text);
            }
            else if (sampleByTraffic && sampleByAmountOfShips && findByRegNumber && !findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.RegistrationNumber == regNumber);
            }
            else if (sampleByTraffic && sampleByAmountOfShips && !findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.Name == EditName.Text);
            }
            else if (!sampleByTraffic && sampleByAmountOfShips && findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.RegistrationNumber == regNumber && c.Name == EditName.Text);
            }
            else if (sampleByTraffic && sampleByAmountOfShips && findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.AmountOfShips >= amountOfShipsFrom && c.AmountOfShips <= amountOfShipsTo && c.Name == EditName.Text && c.RegistrationNumber == regNumber);
            }
            else if (sampleByTraffic && !sampleByAmountOfShips && findByRegNumber && findByName)
            {
                carriers = carriers.FindAll(c => c.RegistrationNumber == regNumber && c.Traffic >= trafficFrom && c.Traffic <= trafficTo && c.Name == EditName.Text);
            }


            GridObjects.ItemsSource = carriers;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditObj addEditObj = new AddEditObj(module, AddEditObjMode.Adding);
            addEditObj.ShowDialog();
        }

        private void GridObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedObj = GridObjects.SelectedItem as Carrier;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void SaveChanges()
        {
            if (type != TypeOfUser.Client)
            {
                foreach (var item in carriers)
                {
                    switch (module.ModifyCarrier(item))
                    {
                        case AnswerFromServer.Successfully:
                            break;
                        case AnswerFromServer.Error:
                            {
                                module.CreateCarrier(item);
                                break;
                            }
                        case AnswerFromServer.UnknownCommand:
                            break;
                        default:
                            break;
                    }
                }
                MessageBox.Show("Изменения сохранены");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void GridObjects_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && selectedObj != null)
            {
                carriers.RemoveAll(c => c.Id == selectedObj.Id);
                switch (module.DeleteCarrier(selectedObj.Id))
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
                GridObjects.ItemsSource = new List<Carrier>();
                GridObjects.ItemsSource = carriers;
            }
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("reportFile.txt", false))
            {
                streamWriter.Write(module.GetReportAboutCarriers());
                MessageBox.Show("Отчёт создан!");
            }
        }

        private void ExpertBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpertMethod expertMethod = new ExpertMethod();
            expertMethod.ShowDialog();
        }

        private void UserControlBtn_Click(object sender, RoutedEventArgs e)
        {
            UserControl userControl = new UserControl(module);
            userControl.ShowDialog();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            carriers = module.GetAllCarriers();
            GridObjects.ItemsSource = carriers;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges();
        }
    }
}
