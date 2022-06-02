using DatabaseEntities;
using System;
using System.Collections.Generic;


namespace TCPConnectionAPI_C_sharp_
{
    public class ExpertAbilityProtocol : IExpertAbilityProtocol
    {
        public IExpertMethod expertMethod { get; set; }

        public IDataModifyPermission DBconnection;

        public bool Rate(Carrier entity, Expert expert, float rate)
        {
            var ratedObj = expertMethod.Rate(entity, expert, rate) as Carrier;
            return DBconnection.UpdateCarrier(ratedObj);
        }

        public void Dispose()
        {
            DBconnection.Dispose();
        }

        public List<Carrier> FindCarriersWhere(Func<Carrier, bool> comparer)
        {
            return DBconnection.FindCarriersWhere(comparer);
        }

        public ExpertAbilityProtocol()
        {
            DBconnection = new DatabaseContext();
        }

    }
}
