using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain.Repositories;

namespace WebApplication2.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyApiWithTokenDBContext context;
        public UnitOfWork(UdemyApiWithTokenDBContext context) 
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
