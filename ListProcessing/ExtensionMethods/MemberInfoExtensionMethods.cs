namespace System.Reflection
{
    using System;

    public static class MemberInfoExtensionMethods
    {
        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo) where T : Attribute
        {
            T attribute = memberInfo.GetCustomAttribute<T>();

            return attribute != default(T);
        }
    }
}