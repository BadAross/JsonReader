using JsonReader.Factories;
using JsonReader.Interfaces;
using static JsonReader.Сonstants.CommandConstants;
using static JsonReader.Сonstants.ErrorsAndWarningsMessagesConstants;

namespace JsonReader.Processors;

public class EmployeeCommandProcessor(IEmployeeService employeeService)
{
    public void Run()
    {
        var command = string.Empty;
        do
        {
            command = GetCommandFromUser();

            if (command == Exist)
            {
                continue;
            }

            if (IsCommandInvalid(command))
            {
                Console.WriteLine(NotFoundMessage);
                continue;
            }

            var employeeCommand = GetCommandFactory(command);
            if (employeeCommand == null)
            {
                Console.WriteLine(NotFoundMessage);
                continue;
            }

            var result = ExecuteEmployeeCommand(employeeCommand);
            Console.WriteLine(result);
            Console.ReadLine();

        } while (command != Exist);
    }

    /// <summary>
    /// Метод получения команд от пользователя
    /// </summary>
    /// <returns>Команда</returns>
    private static string? GetCommandFromUser()
    {
        Console.Write("Введите команду: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Метод для проверки валидности команды
    /// </summary>
    /// <param name="command">Команда пользователя</param>
    /// <returns>true - команда состоит из пробелов или равна null, иначе - false</returns>
    private static bool IsCommandInvalid(string? command) =>
         string.IsNullOrWhiteSpace(command);

    /// <summary>
    /// Метод для выполнения команды
    /// </summary>
    /// <param name="employeeCommand">Команда</param>
    /// <returns>Результат выполнения команды</returns>
    private static string ExecuteEmployeeCommand(EmployeesCommandFactory employeeCommand) =>
        employeeCommand.ExecutingEmployeesCommand().ExecutingCommand();

    /// <summary>
    /// Возвращает фабрику получений команды
    /// </summary>
    /// <param name="command">Команда</param>
    /// <returns>Фабрика команды</returns>
    private EmployeesCommandFactory? GetCommandFactory(string command)
    {
        command = command.ToLower();
        switch (command)
        {
            case Add:
                return new AddEmployeesCommandFactory(employeeService);
            case Update:
                return new UpdateEmployeesCommandFactory(employeeService);
            case Delete:
                return new DeleteEmployeesCommandFactory(employeeService);
            case Get:
                return new GetEmployeesCommandFactory(employeeService);
            case GetAll:
                return new GetAllEmployeesCommandFactory(employeeService);
            case Help:
                return new HelpCommandFactory();
            case Exist:
                return new HelpCommandFactory();
            default:
                return null;
        }
    }
}