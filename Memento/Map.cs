using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky.Memento
{
    public class Map
    {
        private int _size = 4;
        private int _max = 3;
        private List<Field> _map;

        public Map(List<Field> map)
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

        public Field GetField(int x, int y)
        {
            return _map.Single(_ => _.X == x && _.Y == y);
        }

        public void Set(int x, int y, int val)
        {
            if (Check(x, y, val))
            {
                GetField(x,y).SetValue(val);
                Console.WriteLine($"Set x{x} y{y} - {val}");                
            }             
        }
        
        internal void Default(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case 0: 
                    case 2: 
                    case 3: 
                        continue;
                    case 1: 
                        SetFor1(i); 
                        break;
                    case 4: 
                        SetForAll(i); 
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException(arr[i].ToString()); 
                }
            }
        }

        internal void Have3()
        {
            for (int i = 0; i < _size; i++)
            {
                //var line = GetLine(i);
                //var column = GetColumn(i);

                //var countX = 0;
                //var countY = 0;

                //for (int j = 0; j < _size; j++)
                //{
                //    if (_map[i, j] > 0) countX++;
                //    if (_map[j, i] > 0) countY++;
                //}

                //if (countX == 3)
                //{
                //    SetLineFor3X(i);
                //}

                //if(countY == 3)
                //{
                //    SetLineFor3Y(i);
                //}
            }
        }

        private void SetLineFor3X(int i)
        {
            Console.WriteLine($"I think this line must have 3 line{i}");
            var line = GetLine(i);
            Console.WriteLine(string.Join(' ', line));
        }

        private void SetLineFor3Y(int i)
        {
            Console.WriteLine($"I think this column must have 3 line{i}");
        }

        private List<Field> GetLine(int line)
        {
            return _map.Where(_ => _.X == line).ToList();
        }

        private List<Field> GetColumn(int col)
        {
            return _map.Where(_ => _.Y == col).ToList();
        }

        public void Show()
        {
            Console.WriteLine(new string('-', 20));
            var i = 0;
            foreach (var item in _map)
            {
                Console.Write(" " + item.GetValue());
                if (i++ == 3)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }
        }

        public bool Check(int x, int y, int val)
        {
            if(GetField(x,y).IsSet())
            {
                Console.WriteLine("Value already set for this");
                return false;
            }

            if(GetLine(x).Any(_ => _.GetValue() == val))
            {
                Console.WriteLine($"Line x{x} contains this value");
            }

            if(GetColumn(y).Any(_ => _.GetValue() == val))
            {
                Console.WriteLine($"Line y{y} contains this value");
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
                        //_map[i, v] = val++;
                        Set(i, v, val++);
                    }
                    break;

                case 1:
                    for (int i = _max; i >= 0; i--)
                    {
                        //_map[v, i] = val++;
                        Set(v, i, val++);
                    }
                    break;

                case 2:
                    for (int i = _max; i >= 0; i--)
                    {
                        //_map[i, _max - v] = val++;
                        Set(i, _max - v, val++);
                    }
                    break;

                case 3:
                    for (int i = 0; i < _size; i++)
                    {
                        //_map[_max - v, i] = val++;
                        Set(_max - v, i, val++);
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
                    //_map[0, v] = _size;
                    Set(0, v, _size);
                    break;

                case 1:
                    //_map[v, _max] = _size;
                    Set(v, _max, _size);
                    break;

                case 2:
                    //_map[_max, _max - v] = _size;
                    Set(_max, _max - v, _size);
                    break;

                case 3:
                    //_map[_max - v, 0] = _size;
                    Set(_max - v, 0, _size);
                    break;

                default:
                    throw new ArgumentException();
            }
        }

    }
}
