using BankKata.Application.Shared.Handlers;
using NetArchTest.Rules;

namespace BankKata.ArchTests;

public class ApplicationRules
{
    [Fact]
    public void ApplicationHasNoDependencyOnOuterLayers()
    {
        var outerLayers = new[]
        {
            Namespaces.Api,
            Namespaces.Infrastructure
        };

        var result = Types
            .InNamespace(Namespaces.Application)
            .ShouldNot()
            .HaveDependencyOnAny(outerLayers)
            .GetResult()
            ;

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void QueryHandlersImplementCorrectInterface()
    {
        var result = Types
            .InNamespace(Namespaces.Application)
            .That()
            .HaveNameEndingWith("QueryHandler")
            .Should()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}