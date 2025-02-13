namespace Wiser.Common.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SectionNameAttribute : Attribute
    {
        public SectionNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
