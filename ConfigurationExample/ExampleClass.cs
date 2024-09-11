using Microsoft.Extensions.Options;

namespace Configuration;

public class ExampleClass
{
    private readonly ExampleClassSettings _settings;

    public ExampleClass(IOptionsMonitor<ExampleClassSettings> settings)
    {
        _settings = settings.CurrentValue;
    }

    public void DoSomething()
    {
        if (_settings.SomeFeature)
        {
            // Выполняем бункционал, закрытый фича-флагом
        }

        // Основной функционал метода
    }
}