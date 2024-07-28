using JsonReader.Entities;
using JsonReader.Extensions;
using JsonReader.Interfaces;

namespace JsonReader.Commands;

/// <summary>
/// Изменение записи о сотруднике.
/// </summary>
internal class UpdateEmployeeCommand(IEmployeeService employeeService) : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        Console.Write($"\nДля обновления информации о сотруднике укажите его {nameof(Employee.Id)}\n");
        var employeeId = ConsoleHelper.FillingNumberField<int>(nameof(Employee.Id));
        var employee = employeeService.GetByIdEmployee(employeeId);
    
        if (employee is null)
        {
            return $"\nСотрудник с {nameof(Employee.Id)}: {employeeId} не найден";
        }
    
        Console.Write("\nУкажите поля для изменения через запятую.\n");
        var fieldsChange = ConsoleHelper.FillingStringField("Список полей для изменений");
        var listFields = fieldsChange.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var field in listFields)
        {
            UpdateEmployeeField(employee, field.Trim());
        }
    
        employeeService.UpdateEmployee(employee);

        return ConsoleHelper.FormatEmployeeMessage(employee, message: $"Новые данные сотрудника с {nameof(Employee.Id)}: {employee.Id}.");
    }

    /// <summary>
    /// Обновление данных пользователя по полю.
    /// </summary>
    /// <param name="employee">Редактируемый пользователь.</param>
    /// <param name="field">Название поля.</param>
    private void UpdateEmployeeField(Employee employee, string field)
    {
        switch (field)
        {
            case nameof(Employee.FirstName):
                employee.FirstName = ConsoleHelper.FillingStringField(nameof(Employee.FirstName));
                break;
            
            case nameof(Employee.LastName):
                employee.LastName = ConsoleHelper.FillingStringField(nameof(Employee.LastName));
                break;
            
            case nameof(Employee.SalaryPerHour):
                employee.SalaryPerHour = ConsoleHelper.FillingNumberField<decimal>(nameof(Employee.SalaryPerHour));
                break;

            default:
                Console.WriteLine($"Поле '{field}' не распознано, изменения не будут внесены.");
                break;
        }
    }
}