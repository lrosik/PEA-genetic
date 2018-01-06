using System;
using System.Collections.Generic;
using TspLibNet.TSP;
using TspLibNet.TSP.Defines;

namespace TabuSearch
{
    public class Parser
    {
        private TspFile _tspFile;
        public int Dimension { get; set; }

        public void LoadFile(string filePath)
        {
            _tspFile = TspFile.Load(filePath);
            Dimension = _tspFile.Dimension;
        }

        public List<List<double>> MakeMatrix()
        {
            var matrix = new List<List<double>>();
            
            if (_tspFile.Type == FileType.TSP)
            {
                for (int i = 0; i < Dimension; i++)
                {
                    matrix.Add(new List<double>());

                    for (int j = 0; j < Dimension; j++)
                    {
                        const int x = 1;
                        const int y = 2;

                        var dist = Math.Sqrt(
                            Math.Pow((double) _tspFile.Nodes[j][x] - (double) _tspFile.Nodes[i][x], 2) +
                            Math.Pow((double) _tspFile.Nodes[j][y] - (double) _tspFile.Nodes[i][y], 2));

                        matrix[i].Add(dist);
                    }
                }
            }
            else if (_tspFile.Type == FileType.ATSP)
            {
                for (int i = 0; i < Dimension; i++)
                {
                    matrix.Add(new List<double>());

                    for (int j = 0; j < Dimension; j++)
                    {
                        matrix[i].Add((int)_tspFile.EdgeWeights[(i * Dimension) + j]);
                    }

                    matrix[i][i] = 0;
                }
            }

            return matrix;
        }
    }
}
