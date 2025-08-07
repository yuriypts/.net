namespace CustomDependencyInjection;

public class DbConnection
{
    private Guid _guid;

    private readonly ILogClass _logClass;

    public DbConnection(ILogClass logClass)
    {
        _logClass = logClass;
        _guid = Guid.NewGuid();
    }

    public void Close()
    {
        Console.WriteLine("DB Close");
        Console.WriteLine($"DB Guid - {_guid}");
        _logClass.Log();
    }

    public void ShowGuid()
    {
        Console.WriteLine($"DB Guid - {_guid}");
    }
}
