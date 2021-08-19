using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.AutoFac
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _logger;
        private Stopwatch _stopwatch;
        private IHttpContextAccessor _httpContext;
        private string msgTemplate = @"{ActionName} completed by {ActionBy} at {ActionDate}  in {ActionTotalSeconds} seconds";
        public LogAspect(Type loggerService)
        {
            _httpContext = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }
            _logger = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var message = GetLogDetail(invocation);
            _logger.Information(msgTemplate, message.ActionName, message.ActionBy, message.ActionDate, message.ActionTotalSeconds);
        }
        protected override void OnException(IInvocation invocation, Exception ex)
        {
            var message = GetLogDetail(invocation);

            _logger.Error(msgTemplate, ex, message.ActionName, message.ActionBy, message.ActionDate, message.ActionTotalSeconds);
        }

        private Log GetLogDetail(IInvocation invocation)
        {
            string actonName = string.Format("{0}.{1}({2})",
                invocation.Method.ReflectedType.Name,
                invocation.Method.Name, string.Join(",",
                invocation.GetConcreteMethod().GetParameters().Select(x => x != null ? x.Name.ToString() : "<Null>")));
            var logDetail = new Log
            {

                ActionName = actonName,
                ActionBy = _httpContext.HttpContext.User.Identity.Name,
                ActionDate = DateTime.Now,
                ActionTotalSeconds = _stopwatch.Elapsed.TotalSeconds
            };
            return logDetail;
        }
    }
}