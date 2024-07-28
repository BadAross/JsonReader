using JsonReader.Entities;
using OneOf;

namespace JsonReader.Extensions;

public static class ConsoleHelper
{
    /// <summary>
    /// Конвертирует полученный текст в числовое значение указанного типа данных.
    /// </summary>
    /// <param name="text">Текст для конвертации.</param>
    /// <typeparam name="TValueFormat">Формат дял конвертации.</typeparam>
    /// <returns>Сконвертированное значение в указанном формате, иначе false.</returns>
    public static OneOf<TValueFormat, bool> ConvertToNumber<TValueFormat>(string text)
    {
        try
        {
            return (TValueFormat)Convert.ChangeType(text, typeof(TValueFormat));
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    /// <summary>
    /// Заполнение полей типа строка, если поле не заполнено выходит предупреждение и необходимо повторить попытку.
    /// </summary>
    /// <param name="nameField">Назваине поле.</param>
    /// <returns>Введенный пользователем текст.</returns>
    public static string FillingStringField(string nameField)
    {
        string? field;
        do
        {
            Console.Write($"{nameField}: ");
            field = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(field))
            {
                Console.WriteLine($"\nПредупреждение. {nameField} не может быть пустым. Попробуйте снова.");
            }
        } while (string.IsNullOrWhiteSpace(field));

        return field;
    }

    /// <summary>
    /// Заполение полей числовых типов.
    /// </summary>
    /// <param name="nameField">Назваине поле.</param>
    /// <typeparam name="TValueFormat">Формат данных для конвертации.</typeparam>
    /// <returns>Введенное пользователем числовое значение.</returns>
    public static TValueFormat FillingNumberField<TValueFormat>
        (string nameField)
    {
        OneOf<TValueFormat, bool> convertValue;
        do
        {
            var field = FillingStringField(nameField);
            convertValue = ConvertToNumber<TValueFormat>(field);

            if (convertValue.IsT1)
            {
                Console.WriteLine("\nУказан не верынй формат данных. Повторите попытку.");
            }
        } while (convertValue.IsT1);
        
        return convertValue.AsT0;
    }

    /// <summary>
    /// Форматирование ответа пользователю.
    /// </summary>
    /// <param name="employee">Данные сотрудника.</param>
    /// <param name="message">Сообщение</param>
    /// <returns>Текстовое сообщение.</returns>
    public static string FormatEmployeeMessage(Employee employee, string? message = null)
    {
        var result = message is not null ? $"\n{message}\n " : string.Empty;
    
        result += FormatEmployeeDetails(employee);
    
        return result;
    }
    
    
    /// <summary>
    /// Метод для форматирования деталей сотрудника
    /// </summary>
    /// <param name="employee">Данные сотрудника.</param>
    /// <returns>Детали сотрудника в формате строки</returns>
    private static string FormatEmployeeDetails(Employee employee)
    {
        return $"{nameof(Employee.Id)}: {employee.Id}\n " +
               $"{nameof(Employee.FirstName)}: {employee.FirstName}\n " +
               $"{nameof(Employee.LastName)}: {employee.LastName}\n " +
               $"{nameof(Employee.SalaryPerHour)}: {employee.SalaryPerHour}\n";
    }
}