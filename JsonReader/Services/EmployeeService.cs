using JsonReader.Entities;
using JsonReader.Handlers;
using JsonReader.Interfaces;

namespace JsonReader.Services;

/// <summary>
/// Сервис сотрудников
/// </summary>
public class EmployeeService : IEmployeeService
{
    private static  EmployeeService? _instance;
    private readonly TxtFileHandler<Employee> _fileHandler;
    private List<Employee> Employees { get; set; }
    
    /// <summary>
    /// Конструктор <inheritdoc cref="EmployeeService"/>.
    /// </summary>
    private EmployeeService(TxtFileHandler<Employee> fileHandler)
    {
        _fileHandler =  fileHandler;
        Employees = _fileHandler.ReadFile() ?? new();
    }
 
    /// <summary>
    /// Возвращает экземпляр класса <inheritdoc cref="EmployeeService"/>.
    /// </summary>
    /// <returns>Экземпляр класса <inheritdoc cref="EmployeeService"/>.</returns>
    public static EmployeeService GetInstance(TxtFileHandler<Employee> fileHandler) => 
        _instance ??= new EmployeeService(fileHandler);
    
    /// <inheritdoc />
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
        _fileHandler.WriteFile(Employees);
    }

    /// <inheritdoc />
    public void UpdateEmployee(Employee employee)
    {
        var employeeToUpdate = Employees.FirstOrDefault(e => e.Id == employee.Id);
        if (employeeToUpdate != null)
        {
            Employees.Remove(employeeToUpdate);
            Employees.Add(employee);
            Employees = Employees.OrderBy(e => e.Id).ToList();
            _fileHandler.WriteFile(Employees);
        }
        else
        {
            Console.WriteLine($"Сотрубник с {nameof(Employee.Id)}: {employee.Id} не найден.");
        }
    }

    /// <inheritdoc />
    public void DeleteEmployee(int id)
    {
        var employeeToRemove = GetByIdEmployee(id);
        if (employeeToRemove != null)
        {
            Employees.Remove(employeeToRemove);
            _fileHandler.WriteFile(Employees);
        }
        else
        {
            Console.WriteLine($"Сотрубник с {nameof(Employee.Id)}: {id} не найден.");
        }
    }

    /// <inheritdoc />
    public List<Employee>? GetEmployees() => Employees;

    /// <inheritdoc />
    public Employee? GetByIdEmployee(int employeeId) => 
        Employees.FirstOrDefault(e => e.Id == employeeId);

    /// <inheritdoc />
    public bool EmployeeExists(int employeeId) => 
        Employees.Any(e => e.Id == employeeId);
    
    /// <inheritdoc />
    public int GetLastEmployee() => 
        Employees.Count == 0? 0 :  Employees.Max(e => e.Id) + 1;
}