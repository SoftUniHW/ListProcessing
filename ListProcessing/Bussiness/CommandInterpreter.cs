namespace ListProcessing.Bussiness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Bussiness.Interfaces;
    using Global;
    using ListProcessing.Bussiness.Commands;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICommandNameCleaner commandNameCleaner;

        public CommandInterpreter(ICommandNameCleaner commandNameCleaner)
        {
            this.commandNameCleaner = commandNameCleaner;
        }

        private ICommandNameCleaner CommandNameCleaner
        {
            get
            {
                return this.commandNameCleaner;
            }

            set
            {
                this.commandNameCleaner = value ??
                                          throw new ArgumentNullException();
            }
        }

        public string InterpredCommand(string commandName, List<string> items, string[] data)
        {
            object[] parameters = new object[]
            {
                data,
                items
            };

            string cleanCommandName = this.CommandNameCleaner.CleanCommandName(commandName).ToLower();
            Type typeOfCommandToCreate = ApplicationContext.CommandTypes.FirstOrDefault(t => t.Name.ToLower().Contains(cleanCommandName));
            if (typeOfCommandToCreate == default(Type))
            {
                throw new ArgumentException();
            }

            Command command = (Command)Activator.CreateInstance(typeOfCommandToCreate, parameters);
            IEnumerable<FieldInfo> fieldsToInject = typeOfCommandToCreate
                                                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                    .Where(f => f.HasCustomAttribute<InjectAttribute>());
            foreach (FieldInfo fieldInfo in fieldsToInject)
            {
                Type fieldType = fieldInfo.FieldType;

                Type correspondingSupplyType = ApplicationContext.SupplyTypesForInjection
                                                                 .FirstOrDefault(t => fieldType.IsAssignableFrom(t));
                object activatedSupplyType = Activator.CreateInstance(correspondingSupplyType);

                fieldInfo.SetValue(command, activatedSupplyType);
            }

            return command.Execute();
        }
    }
}