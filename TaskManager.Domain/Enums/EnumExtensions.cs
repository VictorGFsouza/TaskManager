using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class EnumExtensions
{
    public static TAttribute? GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
    {
        var memberInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        return memberInfo?.GetCustomAttribute<TAttribute>();
    }
}
