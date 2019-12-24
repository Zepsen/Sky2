using Sky.Version2;
using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 };
            //new AI(arr).Solve();

            new AiInLine(arr).Run();
        }
    }
}
