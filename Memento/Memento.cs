using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky.Memento
{
    public interface IMemento
    {
        int[,] GetState();
    }

    public class MapState : IMemento
    {
        private readonly int[,] _state = new int[,] { };
        public MapState(int[,] state)
        {
            _state = (int[,])state.Clone();
        }

        public int[,] GetState()
        {
            return this._state;
        }
    }

    /// <summary>
    /// Caretaker for memento
    /// </summary>
    public class MapHistory
    {
        private readonly Stack<IMemento> history = new Stack<IMemento>();
        private readonly Map origin;

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

        public void Display()
        {
            var arr = history.ToList();
            foreach (var item in arr)
            {
                var state = new Map(item.GetState());
                state.Show();
            }
        }
    }
}
