using Sky.Memento;
using System.Collections.Generic;

namespace Sky
{
    public class AI
    {
        private Map map;
        private MapHistory history;

        public AI()
        {
            //map = new Map(new int[,] {
            //        { 0, 0, 0, 0 },
            //        { 0, 0, 0, 0 },
            //        { 0, 0, 0, 0 },
            //        { 0, 0, 0, 0 } });

            map = new Map(new List<Field>()
            {
                new Field(0, 0),
                new Field(0, 1),
                new Field(0, 2),
                new Field(0, 3),
                new Field(1, 0),
                new Field(1, 1),
                new Field(1, 2),
                new Field(1, 3),
                new Field(2, 0),
                new Field(2, 1),
                new Field(2, 2),
                new Field(2, 3),
                new Field(3, 0),
                new Field(3, 1),
                new Field(3, 2),
                new Field(3, 3),
            });

            history = new MapHistory(map);
        }

        public void Solve(int[] arr)
        {
            history.Backup();
            
            //Set 100%
            map.Default(arr);
            history.Backup();
            map.Show();

            map.Set(1, 1, 1);
            //map.Have3();
            history.Backup();
            map.Show();

            map.Set(3, 3, 3);
            map.Show();

            history.Restore();
            map.Show();

        }
    }
}
