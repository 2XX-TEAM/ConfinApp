using System;
using System.Threading.Tasks;

namespace ConfinApp.Services.Identity
{
    class IdentityServiceStub : IIdentityService
    {
        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyRegistration()
        {
            await Task.Delay(1337);
            return false;
        }
    }
}
