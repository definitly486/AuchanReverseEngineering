.class final Landroidx/lifecycle/serialization/SavedStateHandleDelegate;
.super Ljava/lang/Object;
.source "SavedStateHandleDelegate.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;",
        "Lcom/scanflow/datacapture/barinternal/kotlin/properties/ReadWriteProperty;"
    }
.end annotation


# instance fields
.field private final configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

.field private final init:Lkotlin/jvm/functions/Function0;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lkotlin/jvm/functions/Function0<",
            "TT;>;"
        }
    .end annotation
.end field

.field private final key:Ljava/lang/String;

.field private final savedStateHandle:Landroidx/lifecycle/SavedStateHandle;

.field private final serializer:Lkotlinx/serialization/KSerializer;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lkotlinx/serialization/KSerializer<",
            "TT;>;"
        }
    .end annotation
.end field

.field private value:Ljava/lang/Object;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "TT;"
        }
    .end annotation
.end field


# direct methods
.method public static synthetic $r8$lambda$yp67IqnpWWlvkGznUyi-Eo3yF70(Landroidx/lifecycle/serialization/SavedStateHandleDelegate;)Landroid/os/Bundle;
    .locals 0

    .line 0
    invoke-static {p0}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->registerSave$lambda$1(Landroidx/lifecycle/serialization/SavedStateHandleDelegate;)Landroid/os/Bundle;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Landroidx/lifecycle/SavedStateHandle;Lkotlinx/serialization/KSerializer;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlin/jvm/functions/Function0;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/lifecycle/SavedStateHandle;",
            "Lkotlinx/serialization/KSerializer<",
            "TT;>;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;",
            "Lkotlin/jvm/functions/Function0<",
            "+TT;>;)V"
        }
    .end annotation

    const-string v0, "savedStateHandle"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "serializer"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "configuration"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "init"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 69
    iput-object p1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->savedStateHandle:Landroidx/lifecycle/SavedStateHandle;

    .line 70
    iput-object p2, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->serializer:Lkotlinx/serialization/KSerializer;

    .line 71
    iput-object p3, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->key:Ljava/lang/String;

    .line 72
    iput-object p4, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 73
    iput-object p5, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->init:Lkotlin/jvm/functions/Function0;

    return-void
.end method

.method private final createDefaultKey(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;)Ljava/lang/String;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Object;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;",
            ")",
            "Ljava/lang/String;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 94
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-static {p1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object p1

    invoke-static {p1}, Landroidx/lifecycle/internal/CanonicalName_jvmKt;->getCanonicalName(Lkotlin/reflect/KClass;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 p1, 0x2e

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    goto :goto_0

    :cond_0
    const-string p1, ""

    .line 95
    :goto_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {p2}, Lkotlin/reflect/KCallable;->getName()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method private final loadValue(Ljava/lang/String;)Ljava/lang/Object;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")TT;"
        }
    .end annotation

    .line 78
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->savedStateHandle:Landroidx/lifecycle/SavedStateHandle;

    invoke-virtual {v0, p1}, Landroidx/lifecycle/SavedStateHandle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/os/Bundle;

    if-eqz p1, :cond_0

    .line 80
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->serializer:Lkotlinx/serialization/KSerializer;

    check-cast v0, Lkotlinx/serialization/DeserializationStrategy;

    .line 82
    iget-object v1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 79
    invoke-static {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoderKt;->decodeFromSavedState(Lkotlinx/serialization/DeserializationStrategy;Landroid/os/Bundle;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_0
    const/4 p1, 0x0

    return-object p1
.end method

.method private final registerSave(Ljava/lang/String;)V
    .locals 2

    .line 88
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->savedStateHandle:Landroidx/lifecycle/SavedStateHandle;

    new-instance v1, Landroidx/lifecycle/serialization/SavedStateHandleDelegate$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate$$ExternalSyntheticLambda0;-><init>(Landroidx/lifecycle/serialization/SavedStateHandleDelegate;)V

    invoke-virtual {v0, p1, v1}, Landroidx/lifecycle/SavedStateHandle;->setSavedStateProvider(Ljava/lang/String;Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;)V

    return-void
.end method

.method private static final registerSave$lambda$1(Landroidx/lifecycle/serialization/SavedStateHandleDelegate;)Landroid/os/Bundle;
    .locals 2

    .line 89
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->serializer:Lkotlinx/serialization/KSerializer;

    check-cast v0, Lkotlinx/serialization/SerializationStrategy;

    iget-object v1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    if-nez v1, :cond_0

    const-string v1, "value"

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_0
    iget-object p0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    invoke-static {v0, v1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoderKt;->encodeToSavedState(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)Landroid/os/Bundle;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public getValue(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;)Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Object;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;",
            ")TT;"
        }
    .end annotation

    const-string v0, "property"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 99
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    if-nez v0, :cond_2

    .line 100
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->key:Ljava/lang/String;

    if-nez v0, :cond_0

    invoke-direct {p0, p1, p2}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->createDefaultKey(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;)Ljava/lang/String;

    move-result-object v0

    .line 101
    :cond_0
    invoke-direct {p0, v0}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->registerSave(Ljava/lang/String;)V

    .line 102
    invoke-direct {p0, v0}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->loadValue(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    if-nez p1, :cond_1

    iget-object p1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->init:Lkotlin/jvm/functions/Function0;

    invoke-interface {p1}, Lkotlin/jvm/functions/Function0;->invoke()Ljava/lang/Object;

    move-result-object p1

    :cond_1
    iput-object p1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    .line 104
    :cond_2
    iget-object p1, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    if-nez p1, :cond_3

    const-string p1, "value"

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_3
    return-object p1
.end method

.method public setValue(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;Ljava/lang/Object;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Object;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;",
            "TT;)V"
        }
    .end annotation

    const-string v0, "property"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 108
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    if-nez v0, :cond_1

    .line 109
    iget-object v0, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->key:Ljava/lang/String;

    if-nez v0, :cond_0

    invoke-direct {p0, p1, p2}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->createDefaultKey(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/reflect/KProperty;)Ljava/lang/String;

    move-result-object v0

    .line 110
    :cond_0
    invoke-direct {p0, v0}, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->registerSave(Ljava/lang/String;)V

    .line 112
    :cond_1
    iput-object p3, p0, Landroidx/lifecycle/serialization/SavedStateHandleDelegate;->value:Ljava/lang/Object;

    return-void
.end method
