using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky
{
    public class AiInLine
    {
        private int _size = 0;
        public AiInLine(int[] arr)
        {
            _size = arr.Length / 4;
            var fields = GenerateFields();
            var lines = GenerateLines(fields, arr);            
        }


        private List<Line> GenerateLines(List<Field> fields, int[] constrains)
        {
            var lines = new List<Line>();
            Line line = null;
            for (int i = 0; i < _size; i++)
            {
                //rows
                line = new Line(
                    fields.Where(f => f.X == i).ToList(), 
                    Vector.X, 
                    constrains[_size * 4 - 1], 
                    constrains[_size * 2 - 1]);
                
                lines.Add(line);
                
                //cols
                line = new Line(fields.Where(f => f.Y == i).ToList(), 
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
    }
}
