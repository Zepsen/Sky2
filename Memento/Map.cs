using System;

namespace Sky.Memento
{
    public class Map
    {
        private int _size = 4;
        private int _max = 3;
        private int[,] _map;

        public Map(int[,] map)
        {
            _map = map;
        }

        public IMemento Save()
        {
            return new MapState(_map);
        }

        public void Restore(IMemento memento)
        {
            _map = memento.GetState();
        }


        public void Set(int x, int y, int val)
        {
            _map[x, y] = val;
        }

        public void Show()
        {
            Console.WriteLine(new string('-', 20));
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(" " + _map[i, j]);
                }

                Console.WriteLine();
            }
        }

        public bool Check()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_map[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void SetForAll(int n)
        {
            var side = n / _size;
            var v = n % _size;
            var val = 1;

            switch (side)
            {
                case 0:
                    for (int i = 0; i < _size; i++)
                    {
                        _map[i, v] = val++;
                    }
                    break;

                case 1:
                    for (int i = _max; i >= 0; i--)
                    {
                        _map[v, i] = val++;
                    }
                    break;

                case 2:
                    for (int i = _max; i >= 0; i--)
                    {
                        _map[i, _max - v] = val++;
                    }
                    break;

                case 3:
                    for (int i = 0; i < _size; i++)
                    {
                        _map[_max - v, i] = val++;
                    }
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public void SetFor1(int n)
        {
            var side = n / _size;
            var v = n % _size;
            switch (side)
            {
                case 0:
                    _map[0, v] = _size;
                    break;

                case 1:
                    _map[v, _max] = _size;
                    break;

                case 2:
                    _map[_max, _max - v] = _size;
                    break;

                case 3:
                    _map[_max - v, 0] = _size;
                    break;

                default:
                    throw new ArgumentException();
            }
        }

    }
}
