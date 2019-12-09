using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Brain();									
			map.RunDefault(new [] { 4,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0});
            
			map.Show();

            map.Back();
            map.Show();
        }
    }
}
