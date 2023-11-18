using System.Data.Common;
using Npgsql;

namespace UniversityApp.DAL;

public abstract class DbContext
{
    protected DbConnection DbConnection;

    protected DbContext(DbConnection dbConnection)
    {
        DbConnection = dbConnection;
    }

    protected DbContext()
    {
    }
}