using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Iran.SMS.Kavenegar.Core;
using Iran.SMS.Kavenegar.Core.Models;

namespace Kavenegar.Sample
{
    class Program
    {
        static Task Main(string[] args) {
            using IHost host = CreateHostBuilder(args).Build();

            sendMsg(host.Services, "ارسال تستی قیمت 30,000,000");

            return host.RunAsync();
        }

        static void sendMsg(IServiceProvider services, string msg) {
            using IServiceScope scope = services.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;

            var smsService = provider.GetRequiredService<KavenegarService>();
            smsService.ApiKey = "";
            var result = smsService.SendAsync(new SendSmsInput<long> {
                DisplayType = MessageDisplayType.Normal,
                ReceptorMobileNumbers = new List<MobileNumber> {
                    new MobileNumber("09120781451")
                },
                Message = msg,
                SendDate = DateTime.Now,
                SenderLineNumber = "1000596446"
            }).Result;

            var filan = result;
        }


        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<KavenegarService>());
    }
}
