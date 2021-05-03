using System;
using ExRam.Gremlinq.Core;
using ExRam.Gremlinq.Core.AspNet;
using Microsoft.Extensions.DependencyInjection;
using Edge = TestClassLib.Edge;
using Vertex = TestClassLib.Vertex;

namespace GremLinQMinRepo
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGremlinq(setup => setup
                .ConfigureEnvironment(e => e
                    .UseModel(GraphModel.FromBaseTypes<TestClassLib.Vertex, Edge>(x => x.IncludeAssembliesOfBaseTypes())
                        .ConfigureProperties(model =>
                            model.ConfigureElement<Vertex>(config => config.IgnoreOnUpdate(x => x.group ))))
                    .UseCosmosDb(builder => builder
                        .At(new Uri("wss://public-tests.gremlin.cosmos.azure.com:443/"), "graphdb",
                            "gremlinq-tests")
                        .AuthenticateBy(
                            "I13DBY35jCFksC4Knv316J4q6UkvdyVtZ9BMpkq1QRbEWnfq8pmpo9Z1S84AsLemQbX4ghqnRWa3ryS1uLlr9w=="))));
        }
    }
}