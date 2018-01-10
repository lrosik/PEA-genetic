﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Projekt3
{
    public class Graph
    {
        public List<List<double>> Matrix { get; set; }
        public double SolutionDistance { get; set; }
        public List<int> SolutionVertices { get; set; }
        public List<List<int>> Population { get; set; } = new List<List<int>>();
        public List<int> PopulationIndexes { get; set; }
        
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

        public List<int> RunGeneticAlgorithm(int populationSize, int time)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var bestPath = new List<int>(SolutionVertices);
            var bestDistance = CalculateDistance(bestPath);
            var distances = new List<int>();

            // tworzenie populacji początkowej
            for (int i = 0; i < populationSize; i++)
            {
                PopulationIndexes.Add(i);
                Population.Add(Shuffle(SolutionVertices));
                var currentDistance = Convert.ToInt32(CalculateDistance(Population[i]));
                distances.Add(currentDistance);

                if (currentDistance < bestDistance)
                {
                    bestDistance = currentDistance;
                    bestPath = new List<int>(Population[i]);
                }
            }


            var stoppingCondition = false;

            while (!stoppingCondition)
            {
                var breedingCandidates = new List<int>(ChooseBreedingCandidates(PopulationIndexes));
                var availableParents = new short[PopulationIndexes.Count];
                Array.Clear(availableParents, 0, availableParents.Length);
                var children = new List<List<int>>();

                for (int i = 0; i < Population.Count; i++)
                {
                    if(availableParents[i] == 1)
                        continue;
                    children.Add(OxCrossover(Population[i], Population[breedingCandidates[i]]));
                    children.Add(OxCrossover(Population[breedingCandidates[i]], Population[i]));
                    availableParents[i] = 1;
                    availableParents[breedingCandidates[i]] = 1;
                }

                if (stopwatch.ElapsedMilliseconds / 1000 >= time)
                    stoppingCondition = true;
            }

            SolutionVertices = new List<int>(bestPath);
            SolutionDistance = CalculateDistance(SolutionVertices);

            return distances;
        }

        public List<int> OxCrossover(List<int> parentA, List<int> parentB)
        {
            var random = new Random();
            var indexA = random.Next(0, parentA.Count - 2);
            var indexB = random.Next(indexA, parentB.Count);

            var child = new List<int>(parentA.Count);

            for (int i = 0; i < child.Capacity; i++)
            {
                child.Add(-1);
            }

            for (int i = indexA; i <= indexB; i++)
            {
                child[i] = parentB[i];
            }

            var indexOfChild = indexB + 1;
            var indexOfParent = indexB + 1;

            while (child.Contains(-1))
            {
                if (indexOfParent >= child.Count)
                    indexOfParent = 0;

                if (indexOfChild >= child.Count)
                    indexOfChild = 0;
                
                if (!child.Contains(parentA[indexOfParent]))
                {
                    child[indexOfChild] = parentA[indexOfParent];
                    indexOfChild++;
                }
                
                indexOfParent++;
            }

            return child;
        }

        public void SwapMutate(List<int> list)
        {
            var random = new Random();
            var indexA = random.Next(0, list.Count);
            var indexB = random.Next(0, list.Count);

            Swap(list, indexA, indexB);
        }

        public List<int> Shuffle(List<int> list)
        {
            var shuffledList = new List<int>(list);
            var random = new Random();
            for (var i = 0; i < list.Count; i++)
            {
                var indexA = random.Next(0, list.Count);
                var indexB = random.Next(0, list.Count);

                Swap(shuffledList, indexA, indexB);
            }

            return shuffledList;
        }

        public void Swap(List<int> list, int indexA, int indexB)
        {
            var temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        public List<int> ChooseBreedingCandidates(List<int> list)
        {
            var random = new Random();
            var breedingList = new List<int>(Shuffle(list));
            var i = 0;
            do
            {
                if (i != breedingList[i])
                {
                    i++;
                }
                else
                {
                    var index = random.Next(0, breedingList.Count);
                    Swap(breedingList, breedingList[i], index);
                }
            } while (i < breedingList.Count);

            return breedingList;
        }

        public short CheckNumberOfZeroes(short[] array)
        {
            short numberOfZeroes = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    numberOfZeroes++;
            }
            return numberOfZeroes;
        }

        public double CalculateDistance(List<int> list)
        {
            var sum = 0.0;

            for (int i = 0; i < Matrix.Count - 1; i++)
            {
                sum += Matrix[list[i]][list[i + 1]];
            }

            sum += Matrix[list[list.Count - 1]][list[0]];

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
