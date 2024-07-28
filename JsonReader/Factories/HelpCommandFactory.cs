using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на получение справки.
/// </summary>
public class HelpCommandFactory : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new HelpCommand();
}