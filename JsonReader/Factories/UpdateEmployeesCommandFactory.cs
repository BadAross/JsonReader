using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на обновление сотрудника.
/// </summary>
/// <param name="employeeService"></param>
public class UpdateEmployeesCommandFactory(IEmployeeService employeeService) : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new UpdateEmployeeCommand(employeeService);
}