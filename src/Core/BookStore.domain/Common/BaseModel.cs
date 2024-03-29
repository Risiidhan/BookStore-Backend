using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.domain.Common
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}