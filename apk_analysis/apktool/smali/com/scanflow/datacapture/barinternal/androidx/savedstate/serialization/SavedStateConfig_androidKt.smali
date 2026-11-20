.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfig_androidKt;
.super Ljava/lang/Object;
.source "SavedStateConfig.android.kt"


# direct methods
.method public static synthetic $r8$lambda$orfFsZZdVWSKUh60gLG7SsK1BYg(Ljava/util/List;)Lkotlinx/serialization/KSerializer;
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfig_androidKt;->getDefaultSerializersModuleOnPlatform$lambda$1$lambda$0(Ljava/util/List;)Lkotlinx/serialization/KSerializer;

    move-result-object p0

    return-object p0
.end method

.method public static final getDefaultSerializersModuleOnPlatform()Lkotlinx/serialization/modules/SerializersModule;
    .locals 3

    .line 34
    new-instance v0, Lkotlinx/serialization/modules/SerializersModuleBuilder;

    invoke-direct {v0}, Lkotlinx/serialization/modules/SerializersModuleBuilder;-><init>()V

    .line 27
    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeSerializer;

    .line 36
    const-class v2, Landroid/util/Size;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v2

    invoke-virtual {v0, v2, v1}, Lkotlinx/serialization/modules/SerializersModuleBuilder;->contextual(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)V

    .line 28
    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

    .line 37
    const-class v2, Landroid/util/SizeF;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v2

    invoke-virtual {v0, v2, v1}, Lkotlinx/serialization/modules/SerializersModuleBuilder;->contextual(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)V

    .line 29
    const-class v1, Landroid/util/SparseArray;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v1

    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfig_androidKt$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfig_androidKt$$ExternalSyntheticLambda0;-><init>()V

    invoke-virtual {v0, v1, v2}, Lkotlinx/serialization/modules/SerializersModuleBuilder;->contextual(Lkotlin/reflect/KClass;Lkotlin/jvm/functions/Function1;)V

    .line 38
    invoke-virtual {v0}, Lkotlinx/serialization/modules/SerializersModuleBuilder;->build()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object v0

    return-object v0
.end method

.method private static final getDefaultSerializersModuleOnPlatform$lambda$1$lambda$0(Ljava/util/List;)Lkotlinx/serialization/KSerializer;
    .locals 1

    const-string v0, "argSerializers"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 30
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->first(Ljava/util/List;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lkotlinx/serialization/KSerializer;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-object v0
.end method
