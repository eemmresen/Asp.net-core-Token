using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictonary) 
        {

            return dictonary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        
        }
    }
}
