using Sky.Memento;
using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
   //         var map = new Brain();									
			//map.RunDefault(new [] { 4,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0});
            
			//map.Show();

   //         map.Back();
   //         map.Show();
            

            var map = new Map(new int[ ]{ 0,0,0, 0,0,0, 0,0,0 });
            var history = new MapHistory(map);

            map.Display();

            map.Set(1, 2);
            map.Set(2, 3);                                    
            history.Backup();
            map.Display();

            map.Set(0, 8);
            map.Display();            

            history.Restore();
            map.Display();
        }
    }
}
