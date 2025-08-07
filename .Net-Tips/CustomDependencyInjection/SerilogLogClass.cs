namespace CustomDependencyInjection;

class SerilogLogClass : ILogClass
{
    private Guid _guid;

    public SerilogLogClass()
    {
        _guid = Guid.NewGuid();
    }

    public void Log()
    {
        Console.WriteLine("SerilogLogClass");

        Console.WriteLine("Show Guid - {0}", _guid);
    }
}
