
using External.Service.Reniec.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External.Service.Reniec.Interface
{
    public interface IReniec
    {
        Task<ReniecDto> Get(string dni);
    }
}
