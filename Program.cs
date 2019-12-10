using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
            new AI().Solve(arr);



            var list = new List<Field>()
            {
                new Field(0,0),
                new Field(0,1),
                new Field(0,2),
                new Field(0,3),
                new Field(1,0),
                new Field(1,1)
            };

            var res = list.Where(i => i.X == 1);
            System.Console.WriteLine(res.Count().ToString());
        }
    }
}
