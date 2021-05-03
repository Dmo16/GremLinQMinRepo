using System;
using System.Threading.Tasks;
using ExRam.Gremlinq.Core;
using TestClassLib.Edges;

namespace TestClassLib.Logic
{
    public class StepLabelTest
    {
        private IGremlinQuerySource _g;

        public StepLabelTest(IGremlinQuerySource g)
        {
            _g = g;
        }
        
        public async Task<Person> ReturnTuples()
        {
            try
            {
                var result = await _g
                    .V<Person>()
                    .As((__, person) => __
                        .Out<Knows>()
                        .OfType<Person>()
                        .As((__, friend) => __
                            .Select(person, friend)));

                return result[0].Item1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}