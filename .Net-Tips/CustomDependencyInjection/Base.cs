namespace CustomDependencyInjection;

public class Base
{
    private readonly ILogClass _logClass;
    private readonly DbConnection _dbConnection;

    public Base(
        ILogClass logClass,
        DbConnection dbConnection)
    {
        _logClass = logClass;
        _dbConnection = dbConnection;
    }

    public void Show()
    {
        Console.WriteLine("Base");
        _logClass.Log();

        _dbConnection.Close();
    }
}
