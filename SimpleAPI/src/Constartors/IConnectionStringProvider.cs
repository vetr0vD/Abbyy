using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Constartors
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
