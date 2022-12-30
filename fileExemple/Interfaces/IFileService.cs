using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Models;

namespace fileExemple.Interfaces
{
    public interface IFileService
    {
        Byte[] Build(IEnumerable<FileModel> models);
    }
}