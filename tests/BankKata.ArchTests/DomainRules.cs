using NetArchTest.Rules;

namespace BankKata.ArchTests;

public class DomainRules
{
    [Fact]
    public void DomainHasNoDependencyOnOtherLayers()
    {
        var outerLayers = new[]
        {
            Namespaces.Api,
            Namespaces.Application,
            Namespaces.Infrastructure
        };

        var result = Types
            .InNamespace(Namespaces.Domain)
            .ShouldNot()
            .HaveDependencyOnAny(outerLayers)
            .GetResult()
            ;

        Assert.True(result.IsSuccessful);
    }
}