// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

#include "RoboGraphGameMode.h"
#include "RoboGraphCharacter.h"
#include "UObject/ConstructorHelpers.h"

#include "GraphCore/RGGraphTestCase.h"

void ARoboGraphGameMode::StartPlay()
{
	Super::StartPlay();

	RGGraphCore::RGGraphTestCase* GraphTest = new RGGraphCore::RGGraphTestCase();
	GraphTest->Test();
}

ARoboGraphGameMode::ARoboGraphGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
