.class public final Landroidx/lifecycle/serialization/SavedStateHandleDelegateKt;
.super Ljava/lang/Object;
.source "SavedStateHandleDelegate.kt"


# direct methods
.method public static final synthetic saved(Landroidx/lifecycle/SavedStateHandle;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Landroidx/lifecycle/SavedStateHandle;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;",
            "Lkotlin/jvm/functions/Function0<",
            "+TT;>;)",
            "Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;"
        }
    .end annotation

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "configuration"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "init"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 47
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object v0

    const/4 v1, 0x6

    const-string v2, "T"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->reifiedOperationMarker(ILjava/lang/String;)V

    const-string v1, "kotlinx.serialization.serializer.withModule"

    invoke-static {v1}, Lkotlin/jvm/internal/MagicApiIntrinsics;->voidMagicApiCall(Ljava/lang/Object;)V

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lkotlinx/serialization/SerializersKt;->serializer(Lkotlinx/serialization/modules/SerializersModule;Lkotlin/reflect/KType;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-static {p0, v0, p1, p2, p3}, Landroidx/lifecycle/serialization/SavedStateHandleDelegateKt;->saved(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;

    move-result-object p0

    return-object p0
.end method

.method public static final saved(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Landroidx/lifecycle/SavedStateHandle;",
            "Lkotlinx/serialization/KSerializer<",
            "TT;>;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;",
            "Lkotlin/jvm/functions/Function0<",
            "+TT;>;)",
            "Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;"
        }
    .end annotation

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "serializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "configuration"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "init"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 66
    new-instance v1, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;

    move-object v2, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    move-object v6, p4

    invoke-direct/range {v1 .. v6}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;-><init>(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)V

    return-object v1
.end method

.method public static synthetic saved$default(Landroidx/lifecycle/SavedStateHandle;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;
    .locals 2

    and-int/lit8 p5, p4, 0x1

    const/4 v0, 0x0

    if-eqz p5, :cond_0

    move-object p1, v0

    :cond_0
    and-int/lit8 p4, p4, 0x2

    if-eqz p4, :cond_1

    .line 44
    sget-object p2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 42
    :cond_1
    const-string p4, "<this>"

    invoke-static {p0, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p4, "configuration"

    invoke-static {p2, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p4, "init"

    invoke-static {p3, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 47
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object p4

    const/4 p5, 0x6

    const-string v1, "T"

    invoke-static {p5, v1}, Lkotlin/jvm/internal/Intrinsics;->reifiedOperationMarker(ILjava/lang/String;)V

    const-string p5, "kotlinx.serialization.serializer.withModule"

    invoke-static {p5}, Lkotlin/jvm/internal/MagicApiIntrinsics;->voidMagicApiCall(Ljava/lang/Object;)V

    invoke-static {p4, v0}, Lkotlinx/serialization/SerializersKt;->serializer(Lkotlinx/serialization/modules/SerializersModule;Lkotlin/reflect/KType;)Lkotlinx/serialization/KSerializer;

    move-result-object p4

    invoke-static {p0, p4, p1, p2, p3}, Landroidx/lifecycle/serialization/SavedStateHandleDelegateKt;->saved(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic saved$default(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;
    .locals 0

    and-int/lit8 p6, p5, 0x2

    if-eqz p6, :cond_0

    const/4 p2, 0x0

    :cond_0
    and-int/lit8 p5, p5, 0x4

    if-eqz p5, :cond_1

    .line 64
    sget-object p3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 61
    :cond_1
    invoke-static {p0, p1, p2, p3, p4}, Landroidx/lifecycle/serialization/SavedStateHandleDelegateKt;->saved(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;

    move-result-object p0

    return-object p0
.end method
