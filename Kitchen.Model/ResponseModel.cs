using System.Collections.Generic;

namespace Kitchen.Model
{
    public class ResponseModel<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
