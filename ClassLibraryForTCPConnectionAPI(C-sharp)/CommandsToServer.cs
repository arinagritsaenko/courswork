namespace ClassLibraryForTCPConnectionAPI_C_sharp_
{
    public enum CommandsToServer
    {
        Registration,
        Authorization,
        PreviousRoom,
        //Admin commands
        RegisterNewAdmin,
        RegisterNewClient,
        RegisterNewExpert,
        BanClient,
        BanExpert,
        UnbanClient,
        UnbanExpert,
        DeleteClient,
        DeleteExpert,
        ModifyClient,
        ModifyExpert,
        FindClientByLogin,
        GetAllClients,
        GetAllAdmins,
        FindExpertByLogin,
        GetAllExperts,
        FindAdminByLogin,
        CreateCarrier,
        ModifyCarrier,
        DeleteCarrier,
        CreateReportAboutCarrier,
        //Expert commands
        RateCarrier, 
        //Client commands
        FindCarrierByName,
        FindCarrierByRegistrationNumber,
        FindCarrierByRate,
        FindCarrierByAmountOfShips,
        FindCarrierByTraffic,
        GetAllCarriers,
        
    }
}
