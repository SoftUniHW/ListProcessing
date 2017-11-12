namespace ListProcessing.Global
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;

    public static class ApplicationContext
    {
        public static readonly Assembly ExecutingAssembly;
        public static readonly IEnumerable<Type> AllTypes;
        public static readonly IEnumerable<Type> CommandTypes;
        public static readonly IEnumerable<Type> SupplyTypesForInjection;

        static ApplicationContext()
        {
            ExecutingAssembly = Assembly.GetExecutingAssembly();
            AllTypes = ExecutingAssembly.GetTypes();
            CommandTypes = AllTypes
                            .Where(t => t.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase))
                            .ToArray();
            SupplyTypesForInjection = AllTypes
                                        .Where(t => t.HasCustomAttribute<SupplyAttribute>())
                                        .ToArray();
        }
    }
}
