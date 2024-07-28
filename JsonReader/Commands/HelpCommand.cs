using JsonReader.Entities;
using JsonReader.Interfaces;
using static JsonReader.Сonstants.CommandConstants;

namespace JsonReader.Commands;

/// <summary>
/// Создание записи о сотруднике.
/// </summary>
internal class HelpCommand : IEmployeeCommand
{
    /// <inheritdoc />
    public string ExecutingCommand()
    {
        var result = 
            @$"Для работы с данными сотрудников можно использовать следующие методы:
                1.{Add} - метод добавления сотрудника. Необходимо указать запрашиваемую информацию;
                2.{Update} - метод изменения информации о сотруднике. Будет необходимо указать поля, 
                 которые подвергунтся изменению;
                3.{Delete} - метод удаления сотрудника. Будет необходимо указать 
                 идентификатор сотрудника;
                4.{Get} - метод получение информации о определенном сотруднике. Будет необходимо 
                 указать идентификатор сотрудника;
                5.{GetAll} - метод получение информации о всех сотрудниках;
                6.{Exist} - прекращение работы программы.

            Информация о сотруднике:
                1.{nameof(Employee.Id)} - идентификатор пользователя
                2.{nameof(Employee.FirstName)} - имя пользователя
                3.{nameof(Employee.LastName)} - фамилия пользователя
                4.{nameof(Employee.SalaryPerHour)} - почасовая оплата;{Environment.NewLine}";

        return result;
    }
}