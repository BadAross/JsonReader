using System.Text;
using JsonReader.Extensions;
using JsonReader.Interfaces;

namespace JsonReader.Commands;

/// <summary>
/// Создание всех записей о сотрудниках.
/// </summary>
internal class GetAllEmployeeCommand(IEmployeeService employeeService) : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        var employees = employeeService.GetEmployees();
        if (employees is null || employees.Count == 0)
        {
            return "Сотрудники отсуствуют. Для начала внесите несколько записей.";
        }
        
        var result = new StringBuilder();
        foreach (var employee in employees)
        {
            result.Append(ConsoleHelper.FormatEmployeeMessage(employee));
        }

        return "\n" + result;
    }
}