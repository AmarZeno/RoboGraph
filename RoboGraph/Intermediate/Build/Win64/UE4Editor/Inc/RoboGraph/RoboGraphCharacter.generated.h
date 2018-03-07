// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "ObjectMacros.h"
#include "ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
#ifdef ROBOGRAPH_RoboGraphCharacter_generated_h
#error "RoboGraphCharacter.generated.h already included, missing '#pragma once' in RoboGraphCharacter.h"
#endif
#define ROBOGRAPH_RoboGraphCharacter_generated_h

#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_RPC_WRAPPERS
#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_RPC_WRAPPERS_NO_PURE_DECLS
#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesARoboGraphCharacter(); \
	friend ROBOGRAPH_API class UClass* Z_Construct_UClass_ARoboGraphCharacter(); \
public: \
	DECLARE_CLASS(ARoboGraphCharacter, ACharacter, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/RoboGraph"), NO_API) \
	DECLARE_SERIALIZER(ARoboGraphCharacter) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC};


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_INCLASS \
private: \
	static void StaticRegisterNativesARoboGraphCharacter(); \
	friend ROBOGRAPH_API class UClass* Z_Construct_UClass_ARoboGraphCharacter(); \
public: \
	DECLARE_CLASS(ARoboGraphCharacter, ACharacter, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/RoboGraph"), NO_API) \
	DECLARE_SERIALIZER(ARoboGraphCharacter) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC};


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_STANDARD_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API ARoboGraphCharacter(const FObjectInitializer& ObjectInitializer); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(ARoboGraphCharacter) \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, ARoboGraphCharacter); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(ARoboGraphCharacter); \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API ARoboGraphCharacter(ARoboGraphCharacter&&); \
	NO_API ARoboGraphCharacter(const ARoboGraphCharacter&); \
public:


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_ENHANCED_CONSTRUCTORS \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API ARoboGraphCharacter(ARoboGraphCharacter&&); \
	NO_API ARoboGraphCharacter(const ARoboGraphCharacter&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, ARoboGraphCharacter); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(ARoboGraphCharacter); \
	DEFINE_DEFAULT_CONSTRUCTOR_CALL(ARoboGraphCharacter)


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_PRIVATE_PROPERTY_OFFSET \
	FORCEINLINE static uint32 __PPO__CameraBoom() { return STRUCT_OFFSET(ARoboGraphCharacter, CameraBoom); } \
	FORCEINLINE static uint32 __PPO__FollowCamera() { return STRUCT_OFFSET(ARoboGraphCharacter, FollowCamera); }


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_9_PROLOG
#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_GENERATED_BODY_LEGACY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_PRIVATE_PROPERTY_OFFSET \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_RPC_WRAPPERS \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_INCLASS \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_STANDARD_CONSTRUCTORS \
public: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#define RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_PRIVATE_PROPERTY_OFFSET \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_RPC_WRAPPERS_NO_PURE_DECLS \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_INCLASS_NO_PURE_DECLS \
	RoboGraph_Source_RoboGraph_RoboGraphCharacter_h_12_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID RoboGraph_Source_RoboGraph_RoboGraphCharacter_h


PRAGMA_ENABLE_DEPRECATION_WARNINGS
