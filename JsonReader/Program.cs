using JsonReader.Entities;
using JsonReader.Handlers;
using JsonReader.Interfaces;
using JsonReader.Processors;
using JsonReader.Services;

namespace JsonReader;

internal static class Program
{
    private const string FolderName = "DataFiles";
    private const string FileName = "Employees";
    private static IEmployeeService _employeeService = null!;
    
    public static void Main()
    {
        using var fileHandler = TxtFileHandler<Employee>.GetInstance(FolderName, FileName);
        {
            _employeeService = EmployeeService.GetInstance(fileHandler);
            
            var commandProcessor = new EmployeeCommandProcessor(_employeeService);
            commandProcessor.Run();
        }
    }
}