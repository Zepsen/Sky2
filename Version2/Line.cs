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
        private readonly int _leftConstraint;
        private readonly int _rightConstraint;
        //private readonly int _num;

        public Line(List<Field> fields, Vector vector, int leftConstrain = 0, int rightConstraint = 0)
        {
            _fields = fields;
            _vector = vector;
            //_num = num;
            _leftConstraint = leftConstrain;
            _rightConstraint = rightConstraint;
        }


    }
}
