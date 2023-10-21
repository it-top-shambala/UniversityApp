using UniversityApp.DAL.DB.Model;

namespace UniversityApp.DAL.DB;

public class TablePersons : Table<Person>, ICrud<Person>
{
    public TablePersons(string connectionString) : base(connectionString)
    {
        
    }
    
    
    public bool Insert(Person obj)
    {
        var sql = $"""
                   INSERT INTO table_persons(last_name, first_name, patronymic, date_of_birth)
                   VALUES ('{obj.LastName}', '{obj.FirstName}', '{obj.Patronymic}', '{obj.DateOfBirth:yyyy-MM-dd}')
                   """;
        return ExecuteNonQuery(sql);
    }

    public bool Update(Person obj)
    {
        var sql = $"""
                   UPDATE table_persons
                   SET last_name = '{obj.LastName}', first_name = '{obj.FirstName}', patronymic = '{obj.Patronymic}', date_of_birth = '{obj.DateOfBirth:yyyy-MM-dd}'
                   WHERE id = {obj.Id};
                   """;
        return ExecuteNonQuery(sql);
    }

    public bool Delete(Person obj)
    {
        return false;
    }

    public IEnumerable<Person> GetAll()
    { 
        var sql = "SELECT * FROM table_persons";
        return ExecuteQuery(sql);
    }

    public Person? GetById(int id)
    {
        var sql = $"SELECT * FROM table_persons WHERE id = {id}";
        return ExecuteQuerySingle(sql);
    }
}