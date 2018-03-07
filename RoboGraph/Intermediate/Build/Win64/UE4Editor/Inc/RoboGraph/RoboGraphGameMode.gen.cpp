// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "GeneratedCppIncludes.h"
#include "RoboGraphGameMode.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeRoboGraphGameMode() {}
// Cross Module References
	ROBOGRAPH_API UClass* Z_Construct_UClass_ARoboGraphGameMode_NoRegister();
	ROBOGRAPH_API UClass* Z_Construct_UClass_ARoboGraphGameMode();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_RoboGraph();
// End Cross Module References
	void ARoboGraphGameMode::StaticRegisterNativesARoboGraphGameMode()
	{
	}
	UClass* Z_Construct_UClass_ARoboGraphGameMode_NoRegister()
	{
		return ARoboGraphGameMode::StaticClass();
	}
	UClass* Z_Construct_UClass_ARoboGraphGameMode()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			static UObject* (*const DependentSingletons[])() = {
				(UObject* (*)())Z_Construct_UClass_AGameModeBase,
				(UObject* (*)())Z_Construct_UPackage__Script_RoboGraph,
			};
#if WITH_METADATA
			static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
				{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
				{ "IncludePath", "RoboGraphGameMode.h" },
				{ "ModuleRelativePath", "RoboGraphGameMode.h" },
				{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
			};
#endif
			static const FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
				TCppClassTypeTraits<ARoboGraphGameMode>::IsAbstract,
			};
			static const UE4CodeGen_Private::FClassParams ClassParams = {
				&ARoboGraphGameMode::StaticClass,
				DependentSingletons, ARRAY_COUNT(DependentSingletons),
				0x00880288u,
				nullptr, 0,
				nullptr, 0,
				nullptr,
				&StaticCppClassTypeInfo,
				nullptr, 0,
				METADATA_PARAMS(Class_MetaDataParams, ARRAY_COUNT(Class_MetaDataParams))
			};
			UE4CodeGen_Private::ConstructUClass(OuterClass, ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(ARoboGraphGameMode, 418824028);
	static FCompiledInDefer Z_CompiledInDefer_UClass_ARoboGraphGameMode(Z_Construct_UClass_ARoboGraphGameMode, &ARoboGraphGameMode::StaticClass, TEXT("/Script/RoboGraph"), TEXT("ARoboGraphGameMode"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ARoboGraphGameMode);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
