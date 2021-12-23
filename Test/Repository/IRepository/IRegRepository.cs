using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Repository.IRepository
{
    public interface IRegRepository
    {
        int AddUser(RegestrationModel reg);
    }
}
