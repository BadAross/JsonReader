using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на добавление сотрудника.
/// </summary>
/// <param name="employeeService"></param>
public class AddEmployeesCommandFactory(IEmployeeService employeeService) : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new AddEmployeeCommand(employeeService);
}