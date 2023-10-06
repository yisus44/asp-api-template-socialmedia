using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public bool success { get; set; }
        public DateTime TimeStamp = new DateTime();
        public string[] errors { get; set; }
        public ResponseDto(T? Data, bool success=true, params string[] errors) {
            this.errors = errors;
            this.Data = Data;
            this.success=success;
        }
    }
}
