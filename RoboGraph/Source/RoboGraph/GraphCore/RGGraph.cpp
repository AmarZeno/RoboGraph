// Fill out your copyright notice in the Description page of Project Settings.

#include "RGGraph.h"

#include "RGGraphVertex.h"

template <class T>
RGGraphCore::RGGraph<T>::RGGraph()
{

}
//
//template <class T>
//RGGraphCore::RGGraph<T>::RGGraph(TArray<RGVertex<T> >* InVertices)
//{
//
//}
//
//template <class T>
//RGGraphCore::RGGraph<T>::Initialize(TArray<RGVertex<T> >* Vertices)
//{
//	Vertices = *InVertices;
//
//	for (int VerticeIndex = 0; VerticeIndex < Vertices.Num(); VerticeIndex++)
//	{
//		Vertices[VerticeIndex].Index = VerticeIndex;
//	}
//
//	AdjacencyMatrix = new RGAdjacencyMatrix[Vertices.Num()];
//}
//
//template <class T>
//void RGGraphCore::RGGraph<T>::CreateDirectedEdge(int FromIndex, int ToIndex, float Weight /*= 1*/)
//{
//	AdjacencyMatrix.AddDirectedEdge(FromIndex, ToIndex, Weight);
//}
//
//template <class T>
//void RGGraphCore::RGGraph<T>::CreateDirectedEdge(RGVertex<T> From, RGVertex<T> To, float Weight /*= 1*/)
//{
//	this->CreateDirectedEdge(From.Index, To.Index, Weight);
//}
//
//template <class T>
//void RGGraphCore::RGGraph<T>::CreateUnDirectedEdge(int V1, int V2, float Weight /*= 1*/)
//{
//	AdjacencyMatrix.AddUndirectedEdge(V1, V2, Weight);
//}
//
//template <class T>
//void RGGraphCore::RGGraph<T>::CreateUnDirectedEdge(RGVertex<T> V1, RGVertex<T> V2, float Weight /*= 1*/)
//{
//	this->CreateUnDirectedEdge(V1.Index, V2.Index, Weight);
//}
//
//template <class T>
//TArray<RGGraphCore::RGVertex<T>> RGGraphCore::RGGraph<T>::GetAdjacentVertex(int SourceIndex)
//{
//	TArray<int> AdjacentIndices = AdjacencyMatrix.GetAdjacencyList(SourceIndex);
//	TArray<RGVertex<T>> AdjacentVertices; // = new TArray<RGVertex<T>>();
//	for (int VertexIndex : AdjacentIndices)
//	{
//		AdjacentVertices.Add(Vertices[VertexIndex]);
//	}
//
//	return AdjacentVertices;
//}
//
//template <class T>
//TArray<RGGraphCore::RGVertex<T>> RGGraphCore::RGGraph<T>::GetAdjacentVertex(RGVertex<T> Source)
//{
//	return GetAdjacentVertex(Source.Index);
//}
//
//template <class T>
//float RGGraphCore::RGGraph<T>::GetEdgeWeight(RGVertex<T> V1, RGVertex<T> V2)
//{
//	return AdjacencyMatrix.GetEdgeWeight(V1.Index, V2.Index);
//}
//
//template <class T>
//FString RGGraphCore::RGGraph<T>::GetInfo()
//{
//	FString InfoString;
//
//	InfoString.Append(TEXT("Graph:"));
//
//	for (RGVertex<T> Vertex : Vertices)
//	{
//		InfoString.Append(Vertex.Data.GetInfo());
//		InfoString.Append("\t");
//
//		TArray<RGVertex<T>> AdjacentVertices = GetAdjacentVertex(Vertex);
//		if (AdjacentVertices.Num() > 0)
//		{
//			InfoString.Append(TEXT("Edge to: "));
//			for (RGVertex<T> AdjVertex : AdjacentVertices)
//			{
//				InfoString.Append(AdjVertex.Data.GetInfo());
//				InfoString.Append("(w=");
//				InfoString.Append(GetEdgeWeight(Vertex, AdjVertex));
//				InfoString.Append(") ");
//			}
//		}
//		else
//		{
//			InfoString.Append("No outgoing edges");
//		}
//		InfoString.Append("\n");
//	}
//
//	return InfoString;
//}