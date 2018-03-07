// Fill out your copyright notice in the Description page of Project Settings.

#include "RGGraphVertex.h"

template <class T>
RGGraphCore::RGVertex<T>::RGVertex(T InData)
{
	Data = InData;
	Index = -1;
}

template <class T>
FString RGGraphCore::RGVertex<T>::GetInfo()
{
	return FString("{Vertex}" + Data);
}