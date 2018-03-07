// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include <vector>

namespace RGGraphCore
{
	class RGAdjacencyMatrix
	{
	public:
		RGAdjacencyMatrix(int InSize);

	public:
		int GetSize() { return Size; }

		void AddDirectedEdge(int From, int To, float Weight);
		void AddUndirectedEdge(int V1, int V2, float Weight);

		float GetEdgeWeight(int X, int Y);

		TArray<int> GetAdjacencyList(int SourceIndex);

	private:
		float* Matrix;
		int Size;
	};
}

