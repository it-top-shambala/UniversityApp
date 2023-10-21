using Dapper;
using Npgsql;

namespace UniversityApp.DAL.DB;

public abstract class Table<T>
{
    private readonly NpgsqlConnection _db;

    protected Table(string connectionString)
    {
        _db = new NpgsqlConnection(connectionString);

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    protected bool ExecuteNonQuery(string sql)
    {
        _db.Open();
        var result = _db.Execute(sql);
        _db.Close();

        return result > 0;
    }

    protected IEnumerable<T> ExecuteQuery(string sql)
    {
        _db.Open();
        var result = _db.Query<T>(sql);
        _db.Close();

        return result;
    }
    
    protected T? ExecuteQuerySingle(string sql)
    {
        _db.Open();
        var result = _db.QuerySingleOrDefault<T>(sql);
        _db.Close();

        return result;
    }
}