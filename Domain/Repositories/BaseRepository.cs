using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly UdemyApiWithTokenDBContext context;

        public BaseRepository(UdemyApiWithTokenDBContext context)
        {
            this.context = context;

        }
    }
}
