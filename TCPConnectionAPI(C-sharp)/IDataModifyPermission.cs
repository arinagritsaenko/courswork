using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public interface IDataModifyPermission : IDataViewPermision
    {
        int CreateCarrier(Carrier obj);
        bool DeleteCarriersWhere(Func<Carrier, bool> comparer);
        bool UpdateCarrier(Carrier newVersion);
    }
}
