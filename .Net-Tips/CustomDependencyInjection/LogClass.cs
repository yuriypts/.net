namespace CustomDependencyInjection;

public class LogClass : ILogClass
{
    private Guid _guid;

    public LogClass()
    {
        _guid = Guid.NewGuid();
    }

    public void Log()
    {
        Console.WriteLine("Log");

        Console.WriteLine("Show Guid - {0}", _guid);
    }
}
