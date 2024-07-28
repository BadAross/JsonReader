namespace JsonReader.Entities;

/// <summary>
/// ДТО сотрудника.
/// </summary>
public class Employee
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { set; get; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string? FirstName { set; get; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? LastName { set; get; }
    
    /// <summary>
    /// Зарплата.
    /// </summary>
    public decimal SalaryPerHour { set; get; }
}