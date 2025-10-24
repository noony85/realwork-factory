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
                DefaultRequestCulture = new RequestCulture("ko-KR"), // 명시적 기본값
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            // 프로바이더 순서를 바꿔 쿼리스트링/쿠키를 우선하도록 설정
            localizationOptions.RequestCultureProviders = new IRequestCultureProvider[]
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider()
            };

            // 임시 디버그: 서버 쪽에서 Accept-Language와 최종 선택을 로그로 확인
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