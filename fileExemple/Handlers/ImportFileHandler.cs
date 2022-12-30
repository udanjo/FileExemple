using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using fileExemple.Interfaces;
using fileExemple.Requests;
using MediatR;

namespace fileExemple.Handlers
{
    public class ImportFileHandler : IRequestHandler<ImportFileRequest, Byte[]>
    {
        private readonly IFileRepository _repository;
        private readonly IFileService _service;

        public ImportFileHandler(IFileRepository repository, IFileService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<byte[]> Handle(ImportFileRequest request, CancellationToken cancellationToken)
        {   
            var models = await _repository.Get(request.Month, request.Year);
            var file = _service.Build(models);

            return file;
        }

    }
}