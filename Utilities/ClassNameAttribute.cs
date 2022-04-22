[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class ClassNameAttribute : Attribute
{
    public string Name { get; private set; }

    public ClassNameAttribute(string name)
    {
        this.Name = name;
    }
}