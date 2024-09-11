using Microsoft.FeatureManagement;

namespace CanaryRelease;

public record InnContext(string Inn);

public class InnFeatureFilterParameters
{
    public int LastDigitLessOrEqual { get; set; }
}

[FilterAlias("Inn")]
public class InnFeatureFilter : IContextualFeatureFilter<InnContext>
{
    public Task<bool> EvaluateAsync(
        FeatureFilterEvaluationContext featureFilterContext, 
        InnContext appContext)
    {
        var parameters = featureFilterContext.Parameters.Get<InnFeatureFilterParameters>() 
                         ?? throw new ArgumentException();

        var result = (appContext.Inn.Last() - '0') % 10 <= parameters.LastDigitLessOrEqual;

        return Task.FromResult(result);
    }
}


