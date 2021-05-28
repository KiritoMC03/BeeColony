using System;

namespace Utils
{
    public static class BooleanExtensions
    {
        public static void Invert(this ref bool boolean)
        {
            boolean = !boolean;
        }
    }
}