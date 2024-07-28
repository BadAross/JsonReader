using JsonReader.Entities;
using JsonReader.Extensions;
using JsonReader.Interfaces;

namespace JsonReader.Commands;

/// <summary>
/// Удаление записи о сотруднике.
/// </summary>
internal class DeleteEmployeeCommand(IEmployeeService employeeService) : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        Console.Write($"\nДля удаления сотрудника укажите его {nameof(Employee.Id)}.\n");
        
        var employeeId = ConsoleHelper.FillingNumberField<int>(nameof(Employee.Id));
        
        if (!employeeService.EmployeeExists(employeeId))
        {
            return $"\nСотрудник с id: {employeeId} не найден.";
        }
            
        employeeService.DeleteEmployee(employeeId);
        return $"\nСотрудник с id: {employeeId} удален.";
    }
}