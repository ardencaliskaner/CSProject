using CSProject.Dto.Base;
using System.Collections.Generic;

namespace CSProject.Dto.Model
{
    public class DtoResponseModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
