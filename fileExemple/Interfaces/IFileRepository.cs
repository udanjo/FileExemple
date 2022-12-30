using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Models;

namespace fileExemple.Interfaces
{
    public interface IFileRepository
    {
        Task<IEnumerable<FileModel>> Get(int month, int year);
    }
}