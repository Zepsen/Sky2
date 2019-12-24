using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sky.Version2
{
    public class Map
    {
        private int _size = 0;
        private readonly List<Line> _lines = new List<Line>();
        private readonly List<Field> _fields = new List<Field>();
        
        public Map(int[] constarains)
        {
            _size = constarains.Length / 4;
            _fields = GenerateFields();
            _lines = GenerateLines(constarains);
        }

        public override string ToString()
        {
            return $"Map length is {_size}";
        }
        #region Behavior

        
        /// <summary>
        /// Set defaults values if exist, for each lines
        /// </summary>
        public void SetDefaultValues()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate if current state is valid
        /// </summary>
        /// <returns>True or False</returns>
        public bool ValidateState()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Builders

        private List<Line> GenerateLines(int[] constrains)
        {
            var lines = new List<Line>();
            Line line = null;
            for (int i = 0; i < _size; i++)
            {
                //add row
                line = new Line(
                    _fields.Where(f => f.X == i).ToList(),
                    Vector.X,
                    constrains[_size * 4 - 1],
                    constrains[_size * 2 - 1]);

                lines.Add(line);

                //add col
                line = new Line(
                    _fields.Where(f => f.Y == i).ToList(),
                    Vector.Y,
                    constrains[_size - 1],
                    constrains[_size * 3 - 1]);

                lines.Add(line);
            }

            return lines;
        }

        private List<Field> GenerateFields()
        {
            return new List<Field>()
            {
                new Field(0, 0),
                new Field(0, 1),
                new Field(0, 2),
                new Field(0, 3),
                new Field(1, 0),
                new Field(1, 1),
                new Field(1, 2),
                new Field(1, 3),
                new Field(2, 0),
                new Field(2, 1),
                new Field(2, 2),
                new Field(2, 3),
                new Field(3, 0),
                new Field(3, 1),
                new Field(3, 2),
                new Field(3, 3),
            };
        }

        #endregion
    }
}
