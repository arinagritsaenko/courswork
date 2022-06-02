using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IExpertAccess : IDataViewAccess, IAuthorizationAccess
    {
        AnswerFromServer RateCarrier(int vehicleId, float expertRate);
    }
}
