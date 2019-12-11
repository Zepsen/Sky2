using System.Collections.Generic;

namespace Sky
{
    public enum Vector
    {
        X = 1,
        Y = 2
    }

    public class Line
    {
        private readonly List<Field> _fields;
        private readonly Vector _vector;
        private readonly int[] _constrains;
        private readonly int _num;
        public Line(List<Field> fields, int num, Vector vector, int[] constrains)
        {
            _fields = fields;
            _vector = vector;
            _num = num;
            _constrains = constrains;
        }
    }
}
