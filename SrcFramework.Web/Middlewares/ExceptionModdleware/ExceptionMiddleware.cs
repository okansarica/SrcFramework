using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SafeTube.BusinessLayer.Abstract;
using SafeTube.Entities;
using SrcFramework.Exception;
using System;
using System.Threading.Tasks;


namespace SrcFramework.Web.Middlewares.ExceptionModdleware
{
    //public class ExceptionMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly IHostingEnvironment _hostingEnvironment;
    //    private readonly IServiceScopeFactory _serviceScopeFactory;
    //    //private readonly IStringLocalizer<SharedResources> _localizer;

    //    public ExceptionMiddleware(RequestDelegate next, IHostingEnvironment hostingEnvironment, IServiceScopeFactory serviceScopeFactory
    //        //, IStringLocalizer<SharedResources> localizer
    //        )
    //    {
    //        _next = next;

    //        _hostingEnvironment = hostingEnvironment;
    //        _serviceScopeFactory = serviceScopeFactory;
    //        //_localizer = localizer;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //            if (context.Response.StatusCode == 404)
    //            {
    //                HandleFor404Async(context);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleException(context, ex);
    //        }
    //    }

    //    private void HandleException(HttpContext context, Exception exception)
    //    {
    //        string message = null;
    //        bool isBusinessException = false;
    //        if (exception is BusinessException)
    //        {
    //            message = exception.Message;
    //            isBusinessException = true;
    //        }
    //        else
    //        {
    //            message = "An error occured, please try again later";
    //            var guid = Guid.NewGuid().ToString();
    //            ExceptionLog exceptionLog = new ExceptionLog
    //            {
    //                Date = DateTime.Now,
    //                Guid = guid,
    //                Message = exception.Message
    //            };
    //            try
    //            {
    //                exceptionLog.StackTrace = context.Request.GetDisplayUrl() + Environment.NewLine + JsonConvert.SerializeObject(exception, new JsonSerializerSettings
    //                {
    //                    ReferenceLoopHandling = ReferenceLoopHandling.Error
    //                });
    //            }
    //            catch (Exception ex)
    //            {
    //                using (var scope = _serviceScopeFactory.CreateScope())
    //                {
    //                    var exceptionLogService = scope.ServiceProvider.GetRequiredService<IExceptionLogService>();
    //                    exceptionLogService.Insert(new ExceptionLog
    //                    {
    //                        Date = DateTime.Now,
    //                        Guid = guid,
    //                        Message = "Couldnt serialize exception",
    //                        StackTrace = context.Request.GetDisplayUrl() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace
    //                    });
    //                    exceptionLog.StackTrace = context.Request.GetDisplayUrl() + Environment.NewLine + exception.StackTrace;
    //                    if (exception.InnerException != null)
    //                    {
    //                        exceptionLog.StackTrace += Environment.NewLine + exception.InnerException.Message + Environment.NewLine + exception.InnerException.StackTrace;
    //                    }
    //                }
    //            }
    //            try
    //            {
    //                using (var scope = _serviceScopeFactory.CreateScope())
    //                {
    //                    var exceptionLogService = scope.ServiceProvider.GetRequiredService<IExceptionLogService>();
    //                    exceptionLogService.Insert(exceptionLog);
    //                }
    //            }
    //            catch
    //            {
    //                try
    //                {
    //                    string directory = _hostingEnvironment.WebRootPath + "\\logs";
    //                    if (!Directory.Exists(directory))
    //                    {
    //                        Directory.CreateDirectory(directory);
    //                    }
    //                    File.WriteAllText(directory + "\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".txt", JsonConvert.SerializeObject(exceptionLog));
    //                }
    //                catch
    //                {
    //                    // ignored
    //                }
    //            }
    //        }


    //        context.Response.ContentType = "application/json";
    //        context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseViewModel
    //        {
    //            IsSuccessfull = false,
    //            Message = _localizer[message],
    //            IsBusinessException = isBusinessException
    //        }, new JsonSerializerSettings
    //        {
    //            ContractResolver = new CamelCasePropertyNamesContractResolver()
    //        }));
    //    }

    //    private static void HandleFor404Async(HttpContext context)
    //    {
    //        //if (IsRequestAPI(context))
    //        //{
    //        //    context.Response.ContentType = "application/json";
    //        //    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
    //        //    {
    //        //        State = 404,
    //        //        message = "the address is not find"
    //        //    }));
    //        //}
    //        //else
    //        //{
    //        //    //when request page 
    //        //    context.Response.Redirect("/Home/ErrorFor404");
    //        //}

    //        context.Response.Redirect("/");
    //    }

    //}
}
