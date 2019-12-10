using Sky.Memento;
using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 0, 0, 4, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 };
            new AI().Solve(arr);           
        }
    }
}
