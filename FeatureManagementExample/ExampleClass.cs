using Microsoft.FeatureManagement;

namespace FeatureManagementExample;

public class ExampleClass
{
    private readonly IFeatureManager _featureManager;

    public ExampleClass(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task DoSomething()
    {
        if (await _featureManager.IsEnabledAsync(FeatureFlags.SomeFeature))
        {
            // Выполняем бункционал, закрытый фича-флагом
        }

        // Основной функционал метода
    }
}

