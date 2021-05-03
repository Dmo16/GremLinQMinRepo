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
                        .At(YOUR_CONNECTION_HERE)
                        .AuthenticateBy(
                            YOUR_KEY_HERE))));
        }
    }
}
