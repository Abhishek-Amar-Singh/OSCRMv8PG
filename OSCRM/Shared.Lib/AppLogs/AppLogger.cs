
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shared.Lib.AppLogs
{
    public class AppLogger : ActionFilterAttribute
    {
        //StartTime | ControllerDomain | ActionName  |  EndTime | TotalTime
        //StartTime | ControllerDomain | ActionName------OnActionExecuting
        //EndTime | TotalTime-------OnActionExecuted
        readonly string logFileName;
        DateTime startTime, endTime;
        TimeSpan totalTime;
        public AppLogger()//current environment where application is running
        {
            logFileName = //"C:/Users/Abhishek/Downloads/logs.txt";
                          //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../Shared.Lib/Logs/logs.txt");
                $"../Shared.Lib/AppLogs/logs{DateTime.Now.ToString("dd-MM-yyyy")}.txt";

        }
        //ActionFilterAttribute----OnActionExecuting,OnActionExecuted
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //base.OnActionExecuting(context);
            startTime = DateTime.Now;
            ControllerBase controllerBase = (ControllerBase)context.Controller;
            ControllerContext controllerContext = controllerBase.ControllerContext;
            string controllerName = controllerContext.ActionDescriptor.ControllerName;//controller name
            string actionName = controllerContext.ActionDescriptor.ActionName;//method name or action name
            using (StreamWriter sw = File.AppendText(logFileName))
            {
                sw.Write($"StartTime::{startTime}, ControllerName::{controllerName}, ActionName::{actionName}");
                sw.Close();
            };
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //base.OnActionExecuted(context);
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            using (StreamWriter sw = File.AppendText(logFileName))
            {
                sw.WriteLine($", EndTime::{endTime}, TotalTimeInSeconds::{totalTime.TotalSeconds}");
                sw.Close();
            }
        }

        //mention in the your Controllers to use CustomeLogger
        //[ServiceFilter(typeof(CustomLogger))] before controller-class
        //register that service in program.cs
        //builder.Services.AddSingleton<CustomLogger>();
    }
}
