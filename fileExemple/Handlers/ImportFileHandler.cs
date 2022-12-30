using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using fileExemple.Helpers;
using fileExemple.Interfaces;
using fileExemple.Requests;
using MediatR;

namespace fileExemple.Handlers
{
    public class ImportFileHandler : IRequestHandler<ImportFileRequest, HandlerResponse>
    {
        private readonly IFileRepository _repository;
        private readonly IFileService _service;

        public ImportFileHandler(IFileRepository repository, IFileService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<HandlerResponse> Handle(ImportFileRequest request, CancellationToken cancellationToken)
        {   
            var models = await _repository.Get(request.Month, request.Year);
            var file = _service.Build(models);

            return HandlerResponse.CreateFileResponse().WithFileData(
                                        file, 
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                                        string.Format("cliente_{0}_{1}.xlsx", request.Month, request.Year));
        }

    }
}