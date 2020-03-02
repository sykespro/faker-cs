﻿using System;
using System.Security.Cryptography;

namespace Faker
{
    /// <summary>
    ///     Provide access to random number generator.
    /// </summary>
    public static class RandomNumber
    {
        private static readonly RandomNumberGenerator Rnd = RandomNumberGenerator.Create();

        private static int Next(this RandomNumberGenerator generator, int min, int max)
        {
            // match Next of Random
            // where max is exclusive
            max = max - 1;

            var bytes = new byte[sizeof(int)]; // 4 bytes
            generator.GetNonZeroBytes(bytes);
            var val = BitConverter.ToInt32(bytes, 0);
            // constrain our values to between our min and max
            // https://stackoverflow.com/a/3057867/86411C:\Work\GitHub\faker-cs\src\Faker\RandomNumber.cs
            var result = ((val - min) % (max - min + 1) + (max - min) + 1) % (max - min + 1) + min;
            return result;
        }

        public static int Next()
        {
            return Rnd.Next(0, int.MaxValue);
        }

        public static int Next(int max)
        {
            return Rnd.Next(0, max);
        }

        public static int Next(int min, int max)
        {
            return Rnd.Next(min, max);
        }
    }
}