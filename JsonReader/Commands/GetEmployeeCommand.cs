using JsonReader.Entities;
using JsonReader.Extensions;
using JsonReader.Interfaces;

namespace JsonReader.Commands;

/// <summary>
/// Получение определенной записи о сотруднике.
/// </summary>
internal class GetEmployeeCommand(IEmployeeService employeeService) : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        Console.Write($"\nДля получения информации о сотруднике укажите его {nameof(Employee.Id)}.\n");
        var employeeId = ConsoleHelper.FillingNumberField<int>(nameof(Employee.Id));
        
        var employee = employeeService.GetByIdEmployee(employeeId);
        
        return employee is null ? $"\nСотрудник с {nameof(Employee.Id)}: {employeeId} не найден" :
            ConsoleHelper.FormatEmployeeMessage(employee, message: "Искомый сотрудник:");
    }
}