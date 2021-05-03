using System;

namespace TestClassLib
{
    public class Vertex
    {
        public string Id { get; set; }
        public string? Label { get; set; }
        public string group { get; set; }
        
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.Now;

    }
}