// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/GameModeBase.h"
#include "RoboGraphGameMode.generated.h"

UCLASS(minimalapi)
class ARoboGraphGameMode : public AGameModeBase
{
	GENERATED_BODY()

	virtual void StartPlay() override;

public:
	ARoboGraphGameMode();
};



