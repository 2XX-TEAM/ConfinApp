using System.Threading.Tasks;

namespace ConfinApp.Services.Identity
{
    interface IIdentityService
    {
        Task<bool> VerifyRegistration();
        Task Authenticate();
    }
}
