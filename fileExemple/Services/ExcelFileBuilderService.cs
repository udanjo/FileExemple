using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using fileExemple.Helpers;
using fileExemple.Interfaces;
using Microsoft.Extensions.Logging;

namespace fileExemple.Services
{
    public class ExcelFileBuilderService : IExcelFileBuilderService
    {
        private readonly ILogger<ExcelFileBuilderService> _logger;

        public ExcelFileBuilderService(ILogger<ExcelFileBuilderService> logger)
        {
            _logger = logger;
        }

        public Byte[] Build<T>(ExcelFileBuilderDtoHelper<T> builderDto)
        {
            try
            {
                using var workbook = new XLWorkbook();
                workbook.Worksheets.Add(builderDto.WorkSheet);

                var workSheet = workbook.Worksheets.FirstOrDefault();

                var headerTitles = new string[][] { builderDto.HeaderTitles.ToArray()};
                workSheet.Cell(builderDto.HeaderRow, builderDto.HeaderStartColumn).InsertData(headerTitles);

                #region Style
                //Exemplo de style caso queira colocar
                var range = workSheet.Range(workSheet.Cell(row: builderDto.HeaderRow, column: builderDto.HeaderStartColumn).Address,
                                            workSheet.Cell(row: builderDto.HeaderRow, column: builderDto.HeaderTitles.Count()).Address);

                range.Style.Fill.SetBackgroundColor(XLColor.Black);
                range.Style.Font.SetFontColor(XLColor.White);
                range.Style.Font.SetBold(true);
                #endregion

                workSheet.Cell(builderDto.ItemsStartRow, builderDto.ItemsStartColumn).InsertData(builderDto.Items);

                var memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);

                return memoryStream.ToArray();

            }
            catch (System.Exception error)
            {
                _logger.LogError(error, "Não foi possível gerar o arquivo.");
                return Array.Empty<byte>();                
            }
        }
    }
}