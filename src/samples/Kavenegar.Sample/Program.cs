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
        const string __API_KEY = "4D454459647357333874436344456D384131367965486C2F2F50462B386C31766A4735705A533934704C513D";
        const string __LINE_NUM = "10006060600";

        static Task Main(string[] args) {
            using IHost host = CreateHostBuilder(args).Build();

            sendMsg(host.Services, "ارسال تستی قیمت 30,000,000");

            return host.RunAsync();
        }

        static void sendMsg(IServiceProvider services, string msg) {
            using IServiceScope scope = services.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;

            var smsService = provider.GetRequiredService<IKavenegarService>();
            //smsService.ApiKey = __API_KEY;
            //var result = smsService.SendAsync(new SendSmsInput<long> {
            //    DisplayType = MessageDisplayType.Normal,
            //    ReceptorMobileNumbers = new List<MobileNumber> {
            //        new MobileNumber("09120781451")
            //    },
            //    Message = msg,
            //    SendDate = DateTime.UtcNow,
            //    SenderLineNumber = __LINE_NUM
            //}).Result;

            //var result = smsService.VerifyAsync(new VerifySmsInput {
            //    Receptor = "989120781451",
            //    Template = "otp",
            //    Token = "سلام",
            //    Token2 = "213232"
            //}).Result;

            var result = smsService.SendAsync<int>(new SendSmsInput<int>
            {
                DisplayType = MessageDisplayType.News,
                HideInWebConsole = true,
                Message = "تست ارسال پیام از کاوه نگار",
                ReceptorMobileNumbers = new List<MobileNumber>
                {
                    new MobileNumber("989120781451")
                }
            }).GetAwaiter().GetResult();

            var filan = result;
        }


        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddKavenegarSmsService(apiKey: __API_KEY));
    }
}
