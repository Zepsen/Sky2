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
        private Field _lastModified;
        private List<int> fullLine = new List<int>(4) { 1, 2, 3, 4 };

        public static int[] Constrains { get; private set; }

        public Map(List<Field> map)
        {
            _map = map;
        }

        public static void SetConstrains(int[] arr)
        {
            Constrains = arr;
        }

        public IMemento Save()
        {
            return new MapState(_map, _lastModified);
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
                var field = GetField(x, y);
                field.SetValue(val);

                if (CheckConstrains(x, y, val))
                {
                    _lastModified = field;
                    Console.WriteLine($"Set x{x} y{y} - {val}");
                } else
                {
                    Console.WriteLine("Constrains failed");
                    field.SetValue(0);
                }
            }
        }

        private bool CheckConstrains(int x, int y, int val)
        {
            var line = GetLine(x);
            if (HasRowConstrains(x))
            {
                var left = GetLeftRowConstrain(x);
                if (left == 2 && !IsGoodFor2(line))
                {
                    return false;
                }

                var right = GetRightRowConstrain(x);
                if (right == 2 && !IsGoodFor2(line, true))
                {
                    return false;
                }
            }

            return true;
        }

        internal void Default()
        {
            //_constains = arr;
            for (int i = 0; i < Constrains.Length; i++)
            {
                switch (Constrains[i])
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
                        throw new ArgumentOutOfRangeException(Constrains[i].ToString());
                }
            }
        }

        private List<Field> GetLine(int line)
        {
            return _map.Where(_ => _.X == line).OrderBy(_ => _.Y).ToList();
        }

        internal Field FirstNotSet()
        {
            return _map.First(_ => !_.IsSet());
        }

        private List<Field> GetColumn(int col)
        {
            return _map.Where(_ => _.Y == col).OrderBy(_ => _.X).ToList();
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
            if (GetField(x, y).IsSet())
            {
                return false;
            }

            var line = GetLine(x);
            if (line.Any(_ => _.GetValue() == val))
            {
                return false;
            }

            var col = GetColumn(y);
            if (col.Any(_ => _.GetValue() == val))
            {
                return false;
            }




            return true;
        }

        public bool HasRowConstrains(int x)
        {
            if (GetLeftRowConstrain(x) != 0 || GetRightRowConstrain(x) != 0)
            {
                return true;
            }

            return false;
        }

        public int GetLeftRowConstrain(int x)
        {
            return Constrains[15 - x];
        }

        public int GetRightRowConstrain(int x)
        {
            return Constrains[4 + x];
        }

        public bool IsGoodFor2(List<Field> fields, bool fromRight = false)
        {
            var first = fields[0].GetValue();
            var third = fields[2].GetValue();
            var fouth = fields[3].GetValue();
            if (first == 4) return false;
            if ((first == 1 || first == 2) && (third == 4 || fouth == 4)) return false;
            
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

        internal void SetLastIfHave3()
        {
            for (int i = 0; i < _size; i++)
            {
                var line = GetLine(i);
                if (line.Count(_ => _.IsSet()) == 3)
                {
                    var excepted = fullLine.Except(line.Select(i => i.GetValue()).ToList()).Single();
                    line.Single(i => !i.IsSet()).SetValue(excepted);
                    Console.WriteLine($"Have 3 set {excepted}");
                }

                var col = GetColumn(i);
                if (col.Count(_ => _.IsSet()) == 3)
                {
                    var excepted = fullLine.Except(col.Select(i => i.GetValue()).ToList()).Single();
                    col.Single(i => !i.IsSet()).SetValue(excepted); ;
                    Console.WriteLine($"Set {excepted}");
                };
            }
        }

        internal bool IsFinish()
        {
            return _map.All(_ => _.IsSet());
        }

        public bool SetRandom(Field notset, int start)
        {
            var res = false;
            for (int i = start; i < fullLine.Count; i++)
            {
                if (!Check(notset.X, notset.Y, fullLine[i])) continue;

                Set(notset.X, notset.Y, fullLine[i]);
                res = true;
                break;
            }

            return res;
        }

        public Field GetLastModified()
        {
            return _lastModified;
        }
    }
}

