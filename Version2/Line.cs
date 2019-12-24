using System.Collections.Generic;

namespace Sky.Version2
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

        public bool HasConstrains()
        {
            return _leftConstraint > 0 || _rightConstraint > 0;
        }

        public bool CheckLine()
        {
            if (!HasConstrains()) return true;

            //if cons = 1 check correct position of first field

            //if cons = 2 check that i can't see more than 2

            //if cons = 3 

            //if cons = 4 check if can see all

            return false;
        }
    }
}
