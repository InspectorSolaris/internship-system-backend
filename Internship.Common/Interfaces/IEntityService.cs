using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Common.Interfaces
{
    public interface IEntityService
    {
        void Create();

        void Retrieve();

        void Update();

        void Delete();
    }
}
