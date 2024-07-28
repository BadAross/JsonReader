using JsonReader.Entities;
using JsonReader.Extensions;
using JsonReader.Interfaces;

namespace JsonReader.Commands;

/// <summary>
/// Создание записи о сотруднике.
/// </summary>
internal class AddEmployeeCommand(IEmployeeService employeeService) : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        var employee = new Employee();
        Console.WriteLine("\nДля добавления сотрудника заполните следующие поля:");

        employee.FirstName = ConsoleHelper.FillingStringField(nameof(Employee.FirstName));
        
        employee.LastName = ConsoleHelper.FillingStringField(nameof(Employee.LastName));

        employee.SalaryPerHour = ConsoleHelper.FillingNumberField<decimal>(nameof(Employee.SalaryPerHour));

        employee.Id = employeeService.GetLastEmployee() + 1;
        employeeService.AddEmployee(employee);

        return ConsoleHelper.FormatEmployeeMessage(employee, message: "Добавленный пользователь:");
    }
}