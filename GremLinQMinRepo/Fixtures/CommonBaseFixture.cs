using System.Collections.Generic;
using System.Threading.Tasks;
using ExRam.Gremlinq.Core;
using TestClassLib;
using TestClassLib.Edges;

namespace GremLinQMinRepo.Fixtures
{
    public class CommonBaseFixture
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IGremlinQuerySource _g;

        public CommonBaseFixture(IGremlinQuerySource g)
        {
            _g = g;
        }

        public async Task<Person> SeedTestPersonAsync(Person person)
        {
            return await _g
                .AddV<Person>()
                .Property(p => p.Name, person.Name)
                .Property(p => p.City, person.City)
                .Property(p => p.group, person.group)
                .FirstAsync();
        }

        public async Task CreateTestEdge(Person person1, Person person2)
        {
            await _g
                .V<Person>(person1.Id)
                .AddE<Knows>()
                .To(__ => __
                    .V<Person>(person2.Id));
        }
    }
}