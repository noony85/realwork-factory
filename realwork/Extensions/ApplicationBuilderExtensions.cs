using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace realwork.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication UseAppLocalization(this WebApplication app)
        {
            var supported = new[] { "ko-KR", "ko", "en-US", "en" };
            var supportedCultures = supported.Select(c => new CultureInfo(c)).ToList();

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ko-KR"), // ����� �⺻��
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            // ���ι��̴� ������ �ٲ� ������Ʈ��/��Ű�� �켱�ϵ��� ����
            localizationOptions.RequestCultureProviders = new IRequestCultureProvider[]
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider()
            };

            // �ӽ� �����: ���� �ʿ��� Accept-Language�� ���� ������ �α׷� Ȯ��
            //app.Use(async (context, next) =>
            //{
            //    var al = context.Request.Headers["Accept-Language"].ToString();
            //    Console.WriteLine($"[i18n] Accept-Language: {al}");
            //    await next();
            //    var rqf = context.Features.Get<IRequestCultureFeature>();
            //    Console.WriteLine($"[i18n] Selected Culture: {rqf?.RequestCulture.Culture.Name}, UICulture: {rqf?.RequestCulture.UICulture.Name}");
            //});

            app.UseRequestLocalization(localizationOptions);
            return app;
        }
    }
}