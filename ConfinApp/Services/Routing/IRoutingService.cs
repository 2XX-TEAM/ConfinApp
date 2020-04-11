using System.Threading.Tasks;

namespace ConfinApp.Services.Routing
{
    public interface IRoutingService
    {
        Task GoBack();
        Task GoBackModal();
        Task NavigateTo(string route);
    }
}
