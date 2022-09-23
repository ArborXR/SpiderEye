using System;

namespace SpiderEye.Bridge
{
    internal class JsCallException : Exception
    {
        public JsCallException(string? message)
            : base(message)
        {
        }
    }
}
