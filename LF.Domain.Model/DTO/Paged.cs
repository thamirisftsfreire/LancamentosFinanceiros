using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.DTO
{
    public class Paged<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
