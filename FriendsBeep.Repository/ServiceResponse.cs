using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBeep.Repository
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Operation Successful";
        public T Data { get; set; }

    }
}
