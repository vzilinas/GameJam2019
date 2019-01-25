using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public class MethodInvocationModel
    {
        public string MethodName { get; set; }
        public Dictionary<Type, object> Parameters { get; set; }
    }
}
