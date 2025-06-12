using System;

namespace Lunaris;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ServiceAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class SettingAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class DependsOnAttribute : Attribute
{
    public Type DependencyType { get; }

    public DependsOnAttribute(Type dependencyType)
    {
        DependencyType = dependencyType;
    }
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class MessageAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class CommandAttribute : MessageAttribute
{
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class NotificationAttribute : MessageAttribute
{
}
