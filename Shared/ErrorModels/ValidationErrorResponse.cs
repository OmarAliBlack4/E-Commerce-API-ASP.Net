using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorModels
{
    public class ValidationErrorResponse
    {
        public int StatusCod { get; set; }
        public string ErrorMessage { get; set; }

        public IEnumerable<ValidationErrore> Errors { get; set; }
    }
    public class ValidationErrore
    {
        public string Field { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
