namespace CustomDependencyInjection;

public class Base
{
    private Guid _guid;

    private readonly ILogClass _logClass;
    private readonly DbConnection _dbConnection;

    public Base(
        ILogClass logClass,
        DbConnection dbConnection)
    {
        _logClass = logClass;
        _dbConnection = dbConnection;
        _guid = Guid.NewGuid();
    }

    public void Show()
    {
        Console.WriteLine("Base");
        Console.WriteLine($"Base Guid - {_guid}");
        _logClass.Log();

        _dbConnection.Close();
    }
}
