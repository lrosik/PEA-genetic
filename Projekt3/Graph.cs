using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TabuSearch
{
    public class Graph
    {
        public List<List<double>> Matrix { get; set; }
        public double SolutionDistance { get; set; }
        public List<int> SolutionVertices { get; set; }
        public List<List<int>> Population { get; set; }
        
        public List<int> FindGreedyPath()
        {
            var verticesList = new List<int>();         // lista wierzchołków należących do ścieżki
            var visitedVertices = new List<int>(Matrix.Count);    // lista odwiedzonych wierzchołków, 1 oznacza odwiedzony, 0 nie

            for (int i = 0; i < Matrix.Count; i++)
            {
                visitedVertices.Add(0);
            }

            verticesList.Add(0);    // dodanie punktu startowego
            visitedVertices[0] = 1; // oznaczenie punktu startowego jako odwiedzony

            var index = 0;

            for (int i = 0; i < Matrix.Count-1; i++)    // wyznaczenie minimum w danym wierszu
            {
                var row = Matrix[index];
                double min = int.MaxValue;

                for (int j = 0; j < row.Count; j++)
                {
                    var item = row[j];

                    if (visitedVertices[j] == 0 && item < min && j != index)
                    {
                        min = item;
                        index = j;
                    }
                }

                verticesList.Add(index);
                visitedVertices[index] = 1;
            }

            verticesList.Add(0); // dodanie punktu początkowego jako powrót

            return verticesList;
        }

        public List<int> Shuffle(List<int> list)
        {
            var random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                var indexA = random.Next(0, list.Count);
                var indexB = random.Next(0, list.Count);

                var temp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = temp;
            }

            return list;
        }

        public double CalculateDistance(List<int> list)
        {
            var sum = 0.0;

            for (int i = 0; i < Matrix.Count; i++)
            {
                sum += Matrix[list[i]][list[i + 1]];
            }

            return sum;
        }

        public string WritePath(List<int> list)
        {
            var path = "";
            foreach (var vertex in list)
            {
                path += vertex + " ";
            }
            return path + Environment.NewLine;
        }
    }
}
