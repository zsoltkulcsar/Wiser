using Microsoft.Extensions.Configuration;
using Wiser.Common.Extensions.Attributes;

namespace Wiser.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T? GetSection<T>(this IConfiguration configuration)
            where T : class
        {
            string sectionName = GetSectionName(typeof(T));
            var potentialValue = Activator.CreateInstance(typeof(T)) as T;
            configuration.GetSection(sectionName).Bind(potentialValue);
            return potentialValue;
        }

        private static string GetSectionName(Type type)
        {
            var customAttribute = Attribute.GetCustomAttribute(type, typeof(SectionNameAttribute));
            if (customAttribute != null)
            {
                var sectionNameAttribute = (SectionNameAttribute)customAttribute;
                return sectionNameAttribute.Name;
            }
            else
            {
                return type.Name;
            }
        }
    }
}
