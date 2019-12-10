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

        public void Solve()
        {
            history.Backup();

            map.SetForAll(2);
            history.Backup();

            map.Set(1, 1, 2);
            history.Backup();

            history.Display();
        }
    }
}
