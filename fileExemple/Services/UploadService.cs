using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Helpers;
using fileExemple.Interfaces;
using fileExemple.Models;
using Microsoft.AspNetCore.Http;

namespace fileExemple.Services
{
    public class UploadService : IUploadService
    {
        public async Task<HandlerResponse> Upload(IFormFile file)
        {
            IList<FileModel> models = new List<FileModel>();
            string line = string.Empty;

            Console.WriteLine("Chegou no método");

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                _ = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    var row = Parse(line.AsSpan());
                    models.Add(row);
                }

                var result = Save(models);

                return HandlerResponse.CreateSuccessResponse().WithData(true);
            }
        }

        private FileModel Parse(ReadOnlySpan<char> span)
        {
            var scanned = -1;
            var position = 0;

            var month = SpliceInformationHelper.slice(ref span, ref scanned, ref position);
            var year = SpliceInformationHelper.slice(ref span, ref scanned, ref position);
            var customerCode = SpliceInformationHelper.slice(ref span, ref scanned, ref position);
            var customerName = SpliceInformationHelper.slice(ref span, ref scanned, ref position);
            var cpf = SpliceInformationHelper.slice(ref span, ref scanned, ref position);
            var email = SpliceInformationHelper.slice(ref span, ref scanned, ref position);

            return new FileModel
            {
                Month = Convert.ToInt32(month.ToString()),
                Year = Convert.ToInt32(year.ToString()),
                CustomerCode = Convert.ToInt32(customerCode.ToString()),
                CustomerName = customerName.ToString(),
                CPF = cpf.ToString(),
                Email = email.ToString()
            };
        }

        private bool Save(IEnumerable<FileModel> files) 
        {
            // Grava no banco de dados e bla bla bla
            return true;
        }
    }
}