using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на получение всех сотрудников.
/// </summary>
/// <param name="employeeService"></param>
public class GetAllEmployeesCommandFactory(IEmployeeService employeeService) : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new GetAllEmployeeCommand(employeeService);
}