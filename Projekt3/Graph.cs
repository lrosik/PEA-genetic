using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Projekt3
{
    public class Graph
    {
        private Random random = new Random();
        private double lastBestSolution;
        public FormMain FormMain { get; set; }
        public double CrossoverProbability { get; set; }
        public double MutationProbability { get; set; }
        public List<List<double>> Matrix { get; set; }
        public double SolutionDistance { get; set; }
        public List<int> SolutionVertices { get; set; }
        public List<List<int>> Population { get; set; } = new List<List<int>>();
        public int PopulationSize { get; set; }
        public List<double> VarianceList { get; set; } = new List<double>();
        
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

            //verticesList.Add(0); // dodanie punktu początkowego jako powrót

            return verticesList;
        }

        public void RunGeneticAlgorithm(int populationSize, int time, int mutationType)
        {
            Population.Clear();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // tworzenie populacji początkowej
            for (int i = 0; i < populationSize-1; i++)
            {
                Population.Add(Shuffle(SolutionVertices));
            }
            Population.Add(FindGreedyPath());

            // sortowanie populacji względem odległości
            Population = (from n in Population
                orderby CalculateDistance(n)
                select n).ToList();

            lastBestSolution = CalculateDistance(Population[0]);

            var stoppingCondition = false;
            var generation = 0;

            while (!stoppingCondition)
            {
                var parentsA = new List<List<int>>();
                var parentsB = new List<List<int>>();
                var tempPopulation = new List<List<int>>(Population);

                // wybór par rodziców
                while (tempPopulation.Count > 0)
                {
                    var listOfProbabilities = CalculateProbabilityOfPopulation(tempPopulation);
                    var probabilitiesSum = listOfProbabilities.Sum();

                    var x = random.Next(0, probabilitiesSum);
                    var parentIndex = 0;

                    while (x > listOfProbabilities[parentIndex])
                    {
                        x -= listOfProbabilities[parentIndex];
                        parentIndex++;
                    }

                    if (parentsA.Count > parentsB.Count)
                    {
                        parentsB.Add(tempPopulation[parentIndex]);
                    }
                    else
                    {
                        parentsA.Add(tempPopulation[parentIndex]);
                    }

                    tempPopulation.RemoveAt(parentIndex);
                }

                var newPopulation = new List<List<int>>();

                // krzyżowanie
                for (int i = 0; i < parentsA.Count; i++)
                {
                    // prawdopodobieństwo krzyżowania
                    if (random.NextDouble() <= CrossoverProbability)
                    {
                        var childA = OxCrossover(parentsA[i], parentsB[i]);
                        var childB = OxCrossover(parentsB[i], parentsA[i]);
                        // prawdopodobieństwo mutacji
                        if (random.NextDouble() <= MutationProbability)
                        {
                            if (mutationType == 0)
                            {
                                InvertMutate(childA);
                                InvertMutate(childB);
                            }
                            else if (mutationType == 1)
                            {
                                SwapMutate(childA);
                                SwapMutate(childB);
                            }
                        }
                        newPopulation.Add(childA);
                        newPopulation.Add(childB);
                    }
                }

                // dodanie nowych osobników do populacji
                Population.AddRange(newPopulation);

                // sortowanie populacji po odległościach ścieżki rosnąco
                Population = (from n in Population
                    orderby CalculateDistance(n)
                    select n).ToList();

                // usuwanie nadmiarowych osobników w populacji
                while (Population.Count > PopulationSize)
                {
                    Population.RemoveAt(Population.Count - 1);
                }

                var currentBest = CalculateDistance(Population[0]);
                if (currentBest < lastBestSolution)
                {
                    MutationProbability = 0.01;
                    lastBestSolution = currentBest;
                }
                else
                {
                    MutationProbability += 0.1;
                }

                FormMain.AddToListBox(currentBest, generation, mutationType);

                // sprawdzenie warunku końca
                if (stopwatch.ElapsedMilliseconds / 1000 >= time)
                    stoppingCondition = true;

                generation++;
            }
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
            var indexA = random.Next(0, list.Count);
            var indexB = random.Next(0, list.Count);

            Swap(list, indexA, indexB);
        }

        public void InvertMutate(List<int> list)
        {
            var indexA = 0;
            var indexB = 0;

            do
            {
                indexA = random.Next(0, list.Count);
                indexB = random.Next(indexA, list.Count);
            } while (indexA == indexB);

            list.Reverse(indexA, indexB - indexA + 1);
        }

        public List<int> Shuffle(List<int> list)
        {
            var shuffledList = new List<int>(list);
            
            for (var i = 0; i < list.Count; i++)
            {
                var indexA = random.Next(0, list.Count);
                var indexB = random.Next(0, list.Count);

                Swap(shuffledList, indexA, indexB);

                //MessageBox.Show(indexA + Environment.NewLine + indexB);
            }

            return shuffledList;
        }

        public void Swap(List<int> list, int indexA, int indexB)
        {
            var temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        public List<double> CalculateProbabilityToDie(List<List<int>> pop)
        {
            var sum = CalculateSumOfDistnaces(pop);

            var listOfProbabilities = new List<double>();
            foreach (var item in pop)
            {
                listOfProbabilities.Add(CalculateDistance(item) / sum);
            }

            return listOfProbabilities;
        }

        public double CalculateSumOfDistnaces(List<List<int>> pop)
        {
            var sum = 0.0;

            foreach (var item in pop)
            {
                sum += CalculateDistance(item);
            }

            return sum;
        }

        public List<int> CalculateProbabilityOfPopulation(List<List<int>> pop)
        {
            var listOfProbabilities = new List<int>();
            var sum = 0.0;

            foreach (var item in pop)
            {
                sum += CalculateDistance(item);
                //listOfProbabilities.Add(CalculateProbabilityOfOne(item));
            }

            foreach (var item in pop)
            {
                listOfProbabilities.Add(Convert.ToInt32((sum / CalculateDistance(item))*100));
            }

            return listOfProbabilities;
        }

        public double CalculateProbabilityOfOne(List<int> list)
        {
            return 1/CalculateDistance(list)*100000;
        }

        public bool ArePathsEqual(List<int> listA, List<int> listB)
        {
            var areEqual = true;

            for (int i = 0; i < listA.Count; i++)
            {
                if (listA[i] != listB[i])
                    areEqual = false;
            }

            return areEqual;
        }

        public double CalculateVariance(List<List<int>> list)
        {
            var distances = new List<double>();

            foreach (var path in list)
            {
                distances.Add(CalculateDistance(path));
            }

            var average = distances.Sum() / list.Count;
            var tempList = new List<double>();

            foreach (var distance in distances)
            {
                tempList.Add(Math.Pow(distance - average, 2));
            }

            var variance = distances.Sum() / list.Count;

            return variance;
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

        public string WriteP(short[] list)
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
