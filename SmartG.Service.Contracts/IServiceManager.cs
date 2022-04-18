using System;
namespace SmartG.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthService AuthenticationService { get; }
    }
}

