using DatabaseEntities;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataViewAccess
    {
        List<Carrier> FindCarriersWithName(string model);
        List<Carrier> FindCarriersWithRegistrationNumber(int code);
        List<Carrier> FindCarriersWithTotalRate(double rate);
        List<Carrier> FindCarriersWithAmountOfShips(int amount);
        List<Carrier> FindCarriersWithTraffic(int amount);
        List<Carrier> GetAllCarriers();
    }
}
