using System;

namespace Sky
{
    public class Field : ICloneable
    {
        public readonly int X;
        public readonly int Y;
        private int Value;

        public Field(int x, int y)
        {
            X = x;
            Y = y;
            Value = 0;
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y} - VAL {Value}";
        }

        public int GetValue()
        {
            return this.Value;
        }

        public void SetValue(int val)
        {
            Value = val;
        }

        public bool IsSet()
        {
            return Value != 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
