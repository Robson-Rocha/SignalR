using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RobsonAraujo.Demos.SignalR.Web.Hubs
{
    public class ProgressHub : Hub<IProgressHubClientFunctions>
    {
        public async Task<int> SubscribeForNotifications(string operationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, operationId);
            return LongRunningOperation.GetCurrentProgress(operationId);
        }

        public Task CancelProcessing(string operationId)
        {
            Clients.Group(operationId).SetMessage("Cancellation requested...");
            LongRunningOperation.CancelProcessing(operationId);
            return Task.CompletedTask;
        }
    }
}