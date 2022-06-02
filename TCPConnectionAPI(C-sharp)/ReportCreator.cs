using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPI_C_sharp_
{
    static public class ReportCreator
    {
        public static string CreateReportAboutCarriers()
        {
            using (IDataViewPermision db = new DatabaseContext())
            {
                var carriers = db.FindCarriersWhere(c => c != null);
                string report = "Состояние перевозчиков на " + DateTime.Now + "\n\n";
                foreach (var item in carriers)
                {
                    report += "Название: " + item.Name + "\n";
                    report += "Регистрационный номер: " + item.RegistrationNumber + "\n";
                    report += "Возможный объём перевозок: " + item.Traffic + " контейнеров/год" + "\n";
                    report += "Количество танкеров: " + item.AmountOfShips + "\n";
                    report += '\n';
                }
                return report;
            }
        }
    }
}
