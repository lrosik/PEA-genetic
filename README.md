# PEA-genetic

Genetic algorithm made to solve Travelling Salesman Problem. Project was made for studies. Used C# for implementation.

Algorithm can be run with following edge weight types:
* EUC_2D for TSP
* FULL_MATRIX for ATSP

TSP problem instances can be downloaded from: http://comopt.ifi.uni-heidelberg.de/software/TSPLIB95/tsp/

ATSP problem instances can be downloaded form: http://comopt.ifi.uni-heidelberg.de/software/TSPLIB95/atsp/

## Crossover used in algorithm:
* Order Crossover (OX)

## Types od mutation used in algorithm:
* Swap - swaps 2 random cities in path of a child
* Invert - inverts path between 2 random cities, including those cities, in path of a child
