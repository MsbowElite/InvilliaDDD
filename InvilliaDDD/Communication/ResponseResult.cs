using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Core.Communication
{
    public class ResponseResult : ValidationResult
    {
        public Guid Id { get; set; }
    }
}
