using Entities.Base;
using System;

namespace Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}