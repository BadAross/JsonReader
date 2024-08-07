﻿using JsonReader.Commands;
using JsonReader.Interfaces;

namespace JsonReader.Factories;

/// <summary>
/// Фаблика команды на удаление сотрудника.
/// </summary>
/// <param name="employeeService"></param>
public class DeleteEmployeesCommandFactory(IEmployeeService employeeService) : EmployeesCommandFactory
{
    public override IEmployeeCommand ExecutingEmployeesCommand()
    => new DeleteEmployeeCommand(employeeService);
}