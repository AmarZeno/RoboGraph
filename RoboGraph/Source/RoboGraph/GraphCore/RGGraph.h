// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include <vector>


// Forward Declarations
class RGVertex;


namespace RGGraphCore
{
	class RGAdjacencyMatrix;

	template <class T>
	class RGGraph
	{
	public:
		RGGraph();

		//RGGraph(TArray<RGVertex<T> >* Vertices);
	//	Initialize(TArray<RGVertex<T> >* Vertices);

	//	TArray<RGVertex<T>>& GetVertices() { return Vertices; }

	//	void CreateDirectedEdge(int FromIndex, int ToIndex, float Weight = 1);
	//	void CreateDirectedEdge(RGVertex<T> From, RGVertex<T> To, float Weight = 1);
	//	
	//	void CreateUnDirectedEdge(int V1, int V2, float Weight = 1);
	//	void CreateUnDirectedEdge(RGVertex<T> V1, RGVertex<T> V2, float Weight = 1);

	//	TArray<RGVertex<T>> GetAdjacentVertex(int SourceIndex);
	//	TArray<RGVertex<T>> GetAdjacentVertex(RGVertex<T> Source);

	//	float GetEdgeWeight(RGVertex<T> V1, RGVertex<T> V2);

	//	FString GetInfo();

	private:
		std::list<RGVertex<T*> > Vertices;
		RGGraphCore::RGAdjacencyMatrix* AdjacencyMatrix;
	};
}

