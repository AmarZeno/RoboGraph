// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

namespace RGGraphCore
{
	template <class T>
	class RGVertex
	{
	public:
		RGVertex(T InData);
		FString GetInfo();

	// Member Variables
	public:
		int32 Index;

	private:
		T Data;
	};
}

