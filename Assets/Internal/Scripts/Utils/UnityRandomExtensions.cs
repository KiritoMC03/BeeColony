using System;
using Utils;

namespace Utils
{
    public static class UnityRandomExtensions
    {
        public static int PlusOrMinusOne(this Random random)
        {
            return new Random().Next(0, 2) * 2 - 1;
        }
    }
}