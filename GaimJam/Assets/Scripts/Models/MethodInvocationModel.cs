using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public class MethodInvocationModel
    {
        public IEnumerator Method { get; set; }
        public object[] Parameters { get; set; }
        public float Delay { get; set; }
    }
}
