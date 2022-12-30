using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace fileExemple.Requests
{
    public class ImportFileRequest : IRequest<Byte[]>
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}