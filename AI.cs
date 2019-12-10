using Sky.Memento;

namespace Sky
{
    public class AI
    {
        private Map map;
        private MapHistory history;

        public AI()
        {
            map = new Map(new int[,] {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 } });

            history = new MapHistory(map);
        }

        public void Solve(int[] arr)
        {
            history.Backup();
            
            //Set 100%
            map.Default(arr);
            history.Backup();
            map.Show();      
            

        }
    }
}
