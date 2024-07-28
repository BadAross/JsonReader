using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фабричный метод команд для работы с сотрудниками.
/// </summary>
public abstract class EmployeesCommandFactory
{
    public abstract IEmployeeCommand ExecutingEmployeesCommand();
}