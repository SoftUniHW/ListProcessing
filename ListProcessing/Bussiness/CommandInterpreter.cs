namespace ListProcessing.Bussiness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Bussiness.Commands.Interfaces;
    using Bussiness.Interfaces;
    using Global;

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

        public string InterpredCommand(string commandName)
        {
            string cleanCommandName = this.CommandNameCleaner.CleanCommandName(commandName).ToLower();
            Type typeOfCommandToCreate = ApplicationContext.CommandTypes.FirstOrDefault(t => t.Name.ToLower().Contains(cleanCommandName));
            if (typeOfCommandToCreate == default(Type))
            {
                throw new ArgumentException();
            }

            ICommand command = (ICommand)Activator.CreateInstance(typeOfCommandToCreate);
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
