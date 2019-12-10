using Sky.Memento;
using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {

            var map = new Map(
                new int [,] {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                }); 

            var history = new MapHistory(map);
            history.Backup();
            
            map.SetForAll(2);
            history.Backup();

            map.Set(1, 1, 2);
            history.Backup();

            history.Display();
            

           

        }
    }
}
