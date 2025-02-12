using System.Net;
using CourseraAPIProject.Services.Interfaces;

namespace CourseraAPIProject.Middleware {
    public class TrafficTrackerMiddleware {

        private readonly RequestDelegate _next;

        public TrafficTrackerMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task Invoke(HttpContext context){
            ITrafficTracker? trafficTracker = context.RequestServices.GetService<ITrafficTracker>();
            if(trafficTracker != null){
                IPAddress? address = context.Connection.RemoteIpAddress;
                string ip = address?.ToString() ?? "Unknown";
                trafficTracker.IncrementConnection(ip);

            }
            await _next(context);
        }


    }


}