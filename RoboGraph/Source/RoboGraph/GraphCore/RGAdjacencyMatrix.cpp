// Fill out your copyright notice in the Description page of Project Settings.

#include "RGAdjacencyMatrix.h"

RGGraphCore::RGAdjacencyMatrix::RGAdjacencyMatrix(int InSize)
{
	Matrix = new float[InSize * InSize]; // Light weight solution to implement 2d arrays
	Size = InSize;
}

void RGGraphCore::RGAdjacencyMatrix::AddDirectedEdge(int From, int To, float Weight)
{
	Matrix[From * Size + To] = Weight;
}

void RGGraphCore::RGAdjacencyMatrix::AddUndirectedEdge(int V1, int V2, float Weight)
{
	Matrix[V1 * Size + V2] = Weight;
	Matrix[V2 * Size + V1] = Weight;
}

float RGGraphCore::RGAdjacencyMatrix::GetEdgeWeight(int X, int Y)
{
	return Matrix[X * Size + Y];
}

TArray<int> RGGraphCore::RGAdjacencyMatrix::GetAdjacencyList(int SourceIndex)
{
	TArray<int> AdjacencyList;
	for (int ListIndex = 0; ListIndex < Size; ListIndex++)
	{
		if (Matrix[SourceIndex * Size + ListIndex] != 0)
		{
			AdjacencyList.Add(ListIndex);
		}
	}

	return AdjacencyList;
}
