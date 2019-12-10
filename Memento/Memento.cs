using System;
using System.Collections.Generic;

namespace Sky.Memento
{
    public interface IMemento
    {
        int[] GetState();
    }

    public class MapState : IMemento
    {
        private readonly int[] _state;
        public MapState(int[] state)
        {
            this._state = (int[])state.Clone();
        }

        public int[] GetState()
        {
            return this._state;
        }
    }

    public class Map
    {
        private int[] map;

        public Map(int[] map)
        {
            this.map = map;
        }

        public IMemento Save()
        {
            return new MapState(this.map);
        }

        internal void Display()
        {
            for (int i = 0; i < this.map.Length; i++)
            {
                Console.Write(this.map[i]);                
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',20));
        }

        public void Restore(IMemento memento)
        {
            this.map = memento.GetState();
        }

        public void Set(int x, int val)
        {
            this.map[x] = val;
        }
    }

    public class MapHistory
    {
        private Stack<IMemento> history = new Stack<IMemento>();
        private Map origin;

        public MapHistory(Map origin)
        {
            this.origin = origin;
        }

        public void Backup()
        {
            history.Push(origin.Save());
        }

        public void Restore()
        {
            var map = history.Pop();
            this.origin.Restore(map);
        }
    }
}
