using Entities.Base;
using System;

namespace Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}