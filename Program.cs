using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();									
			map.RunDefault(new [] { 1,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0});		
			map.Show();

            map.Set(0, 0, 1);
            map.Show();

        }
    }
}
