namespace JsonReader.Interfaces;

/// <summary>
/// Интерфейс фабричного метода команд для работы с сотрудниками.
/// </summary>
public interface IEmployeeCommand
{
    /// <summary>
    /// Метод выполнение команды.
    /// </summary>
    /// <returns>Возвращает сообщение о результате выполнения команды.</returns>
    public string ExecutingCommand();
}