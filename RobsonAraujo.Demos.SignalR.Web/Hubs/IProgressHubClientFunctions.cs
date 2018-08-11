using System.Threading.Tasks;

namespace RobsonAraujo.Demos.SignalR.Web.Hubs
{
    public interface IProgressHubClientFunctions
    {
         Task SetProgress(int progress);
         Task SetMessage(string message);
    }
}