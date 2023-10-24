using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBShrarp2
{
    internal class IbitsT
    {
        public interface IBits
        {
            bool GetBit(int i);
            void SetBit(bool bit, int index);
        }


        public class Bits : IBits
        {
            public Bits(byte b)
            {
                this.v = b;
                MaxBitsCount = sizeof(byte) * 8;
            }

            public Bits(short b)
            {
                this.v = b;
                MaxBitsCount = sizeof(short) * 8;
            }

            public Bits(int b)
            {
                this.v = b;
                MaxBitsCount = sizeof(int) * 8;
            }

            public Bits(long b)
            {
                this.v = b;
                MaxBitsCount = sizeof(long) * 8;
            }

            public long v { get; set; } = 0;
            private int MaxBitsCount { get; set; }



            public bool GetBit(int index)
            {
                if (index > MaxBitsCount || index < 0)
                {
                    Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                    return false;
                }

                return ((v >> index) & 1) == 1;
            }

            public void SetBit(bool bit, int index)
            {
                if (index > MaxBitsCount || index < 0)
                {
                    Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                    return;
                }
                if (bit == true)
                    v = v | (1 << index);
                else
                {
                    var mask = 1 << index;
                    mask = 0xff ^ mask;
                    v &= v & mask;
                }
            }

            public static implicit operator Bits(int v)
            {
                try
                {
                    int a = v;
                    return new Bits(v);
                }
                catch (StackOverflowException e) { throw new NotImplementedException(); } 
            }
            public static implicit operator Bits(long v)
            {
                try
                {
                    long a = v;
                    return new Bits(v);
                }
                catch (StackOverflowException e) { throw new NotImplementedException(); }
            }
            public static implicit operator Bits(byte v)
            {
                try
                {
                    byte a = v;
                    return new Bits(v);
                }
                catch (StackOverflowException e) { throw new NotImplementedException(); }
            }
        }
    }
}
