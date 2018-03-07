// Fill out your copyright notice in the Description page of Project Settings.

#include "RGGraphTestCase.h"

#include "RGGraphVertex.h"
#include "RGGraph.h"

void RGGraphCore::RGGraphTestCase::Test()
{
	RGVertex<FString> V1("V1");
	RGVertex<FString> V2("V1");
	RGVertex<FString> V3("V1");
	RGVertex<FString> V4("V1");

	TArray<RGVertex<FString>> Vertices;// = new TArray<RGVertex<FString>>{ V1, V2, V3, V4 };

	RGGraphCore::RGGraph<FString>* Graph(Vertices);
}
