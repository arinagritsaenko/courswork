using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataModifyAccess : IDataViewAccess   
    {
        AnswerFromServer CreateCarrier(Carrier obj);
        AnswerFromServer ModifyCarrier(Carrier obj);
        AnswerFromServer DeleteCarrier(int id);
        string GetReportAboutCarriers();
    }
}
