using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    public class AiInLine
    {
        private int _size = 0;
        private readonly List<Line> _lines = new List<Line>();
        private readonly List<Field> _fields = new List<Field>();

        public AiInLine(int[] arr)
        {
            _size = arr.Length / 4;
            _fields = GenerateFields();
            _lines = GenerateLines(arr);
        }

        /// <summary>
        /// Run
        /// </summary>
        private void Run()
        {            
            SetDefaultValues();

            if (ValidateState())
                SaveState();
            else throw new Exception("Wrong default arfs");

            Resolve();            
        }

        /// <summary>
        /// Main resolver
        /// </summary>
        private void Resolve()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save current state
        /// </summary>
        private void SaveState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate if current state is valid
        /// </summary>
        /// <returns>True or False</returns>
        private bool ValidateState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set defaults values if exist, for each lines
        /// </summary>
        private void SetDefaultValues()
        {
            throw new NotImplementedException();    
        }



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
