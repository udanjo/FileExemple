using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Helpers;
using fileExemple.Interfaces;
using fileExemple.Models;

namespace fileExemple.Services
{
    public class FileService : IFileService
    {
        private readonly IExcelFileBuilderService _excelFileBuilderService;

        public FileService(IExcelFileBuilderService excelFileBuilderService)
        {
            _excelFileBuilderService = excelFileBuilderService;
        }

        public Byte[] Build(IEnumerable<FileModel> models)
        {
            var builderDto = GetBuilder(models);
            var fileBytes = _excelFileBuilderService.Build(builderDto);

            return fileBytes;
        }

        public ExcelFileBuilderDtoHelper<FileModel> GetBuilder(IEnumerable<FileModel> models)
        {
            var headerTitles = new List<string> { "Mês", "Ano", "Código", "Nome", "CPF", "Email"};

            return new ExcelFileBuilderDtoHelper<FileModel>("Cliente", headerRow: 1, headerStartColumn: 1, headerTitles, itemsStartRow: 2, itemsStartColumn: 1, models);
        }
    }
}