using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Helpers;
using MediatR;

namespace fileExemple.Requests
{
    public class ImportFileRequest : IRequest<HandlerResponse>
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}