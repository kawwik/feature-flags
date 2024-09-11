using Microsoft.FeatureManagement;

namespace CanaryRelease;

public record LoginContext(string Login);

public class LoginFeatureFilterParameters
{
    public int HashLessOrEqual { get; set; }
}

[FilterAlias("LoginHash")]
public class LoginHashFeatureFilter : IContextualFeatureFilter<LoginContext>
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, LoginContext appContext)
    {
        var parameters = featureFilterContext.Parameters.Get<LoginFeatureFilterParameters>() 
                         ?? throw new ArgumentException();

        var result = appContext.Login.GetHashCode() % 10 <= parameters.HashLessOrEqual;

        return Task.FromResult(result);
    }
}