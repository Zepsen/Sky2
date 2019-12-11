using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky.Memento
{
    public interface IMemento
    {
        List<Field> GetState();
        Field LastModified();
    }

    public class MapState : IMemento
    {
        private readonly List<Field> _state = new List<Field>();
        private Field LastModifiedField = null;

        public MapState(List<Field> state, Field field)
        {
            state.ForEach(_ => _state.Add((Field)_.Clone()));
            LastModifiedField = field;
        }

        public List<Field> GetState()
        {
            return this._state;
        }

        public Field LastModified()
        {
            return this.LastModifiedField;
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

                Console.WriteLine();
                Console.WriteLine($"LM: {item.LastModified()}");
            }
        }

        internal bool Any()
        {
            return history.Count > 1; //Cause 1 is backup for 100%;
        }
    }
}
