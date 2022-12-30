using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;
using fileExemple.Interfaces;
using fileExemple.Models;

namespace fileExemple.Repositories
{
    public class FileRepository : IFileRepository
    {
        public async Task<IEnumerable<FileModel>> Get(int month, int year)
        {
            var faker = new Faker<FileModel>("pt_BR").StrictMode(true)
                            .RuleFor(r => r.Month, month)
                            .RuleFor(r => r.Year, year)
                            .RuleFor(r => r.CustomerCode, f => f.Random.Number(1, 999))
                            .RuleFor(r => r.CustomerName, f => f.Name.FullName())
                            .RuleFor(r => r.CPF, f => f.Person.Cpf())
                            .RuleFor(r => r.Email, f => f.Internet.Email());

            return faker.Generate(50);
        }
    }
}