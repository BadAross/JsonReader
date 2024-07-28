using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на получение сотрудника по id.
/// </summary>
/// <param name="employeeService"></param>
public class GetEmployeesCommandFactory(IEmployeeService employeeService) : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new GetEmployeeCommand(employeeService);
}