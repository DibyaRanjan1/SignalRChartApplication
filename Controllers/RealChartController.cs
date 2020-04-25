using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChartApplication.Models;
using SignalRChartApplication.Storage;
using SignalRChartApplication.TimeManager;

namespace SignalRChartApplication.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Cors.EnableCors()]
    [ApiController]
    public class ChartController :ControllerBase
    {
        private IHubContext<ChartHub> _hubContext;
        public  ChartController(IHubContext<ChartHub> hubContext)
        
        {
            _hubContext = hubContext;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerChart(() => _hubContext.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
