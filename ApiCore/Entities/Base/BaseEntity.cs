using System;

namespace Entities.Base
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
    }
}