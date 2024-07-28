using JsonReader.Entities;

namespace JsonReader.Interfaces;

public interface IEmployeeService
{ 
    /// <summary>
    /// Добавление сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void AddEmployee(Employee employee);

    /// <summary>
    /// Обновление сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void UpdateEmployee(Employee employee);

    /// <summary>
    /// Удаление сотрудника.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника.</param>
    void DeleteEmployee(int id);
    
    /// <summary>
    /// Получение списка сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    List<Employee>? GetEmployees();

    /// <summary>
    /// Получение сотрудника по id.
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника.</param>
    /// <returns></returns>
    Employee? GetByIdEmployee(int employeeId);

    /// <summary>
    /// Определяет наличие сотрудника.
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника.</param>
    /// <returns>true - сотрудник найден, иначе - false.</returns>
    bool EmployeeExists(int employeeId);

    /// <summary>
    /// Получение идентификатора последнего сотрудника.
    /// </summary>
    /// <returns>Идентификатор.</returns>
    int GetLastEmployee();
}