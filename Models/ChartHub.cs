using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChartApplication.Models
{
    public class ChartHub:Hub
    {
        public async Task BroadcastChartData(List<Chart> data) => await Clients.All.SendAsync("broadcastchartdata", data);

        public async void BroadcastTextData(string data)
        {
           await Clients.All.SendAsync("broadcasttextdata", data);
        }
    }
}
