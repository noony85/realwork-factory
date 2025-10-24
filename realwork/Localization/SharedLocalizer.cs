using Microsoft.Extensions.Localization;
using System.Reflection;

namespace realwork.Localization
{
    public class SharedLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedLocalizer(IStringLocalizerFactory factory)
        {
            // 리소스 베이스 이름: SharedResource (Resources/SharedResource(.ko).resx)
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
            _localizer = factory.Create("SharedResource", assemblyName);
        }

        public LocalizedString this[string name] => _localizer[name];

        public string GetString(string name) => _localizer[name];
    }
}