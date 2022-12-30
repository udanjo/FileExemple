using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Helpers;

namespace fileExemple.Interfaces
{
    public interface IExcelFileBuilderService
    {
        Byte[] Build<T>(ExcelFileBuilderDtoHelper<T> builderDto);
    }
}