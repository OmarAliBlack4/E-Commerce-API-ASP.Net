using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exeptions
{
    public class ProudctNotFoundException : NotFoundException
    {
        public ProudctNotFoundException(int id) 
            :base($"Proudct with Id {id} Not Found")
        {
        }
    }
}
