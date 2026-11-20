.class final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;
.super Ljava/lang/Object;
.source "BuiltInSerializer.android.kt"


# annotations
.annotation build Landroid/annotation/SuppressLint;
    value = {
        "UnsafeOptInUsageError"
    }
.end annotation

.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "SparseArraySurrogate"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$$serializer;,
        Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation

.annotation runtime Lkotlinx/serialization/Serializable;
.end annotation


# static fields
.field private static final $cachedDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final $childSerializers:[Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;


# instance fields
.field private final keys:Ljava/util/List;

.field private final values:Ljava/util/List;


# direct methods
.method public static synthetic $r8$lambda$Te6tq_6GXP9ROR7MsQbitRJE9jo()Lkotlinx/serialization/KSerializer;
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->_childSerializers$_anonymous_()Lkotlinx/serialization/KSerializer;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 5

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;

    .line 417
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object v0

    const/4 v2, 0x2

    new-array v3, v2, [Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    const/4 v4, 0x0

    aput-object v0, v3, v4

    const/4 v0, 0x1

    aput-object v1, v3, v0

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->$childSerializers:[Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;

    const-string v3, "androidx.savedstate.serialization.serializers.SparseArraySerializer.SparseArraySurrogate"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/GeneratedSerializer;I)V

    const-string v1, "keys"

    invoke-virtual {v0, v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->addElement(Ljava/lang/String;Z)V

    const-string v1, "values"

    invoke-virtual {v0, v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->addElement(Ljava/lang/String;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->$cachedDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method public synthetic constructor <init>(ILjava/util/List;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/SerializationConstructorMarker;)V
    .locals 1

    and-int/lit8 p4, p1, 0x3

    const/4 v0, 0x3

    if-eq v0, p4, :cond_0

    .line 417
    sget-object p4, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->$cachedDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-static {p1, v0, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginExceptionsKt;->throwMissingFieldException(IILkotlinx/serialization/descriptors/SerialDescriptor;)V

    :cond_0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->keys:Ljava/util/List;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->values:Ljava/util/List;

    return-void
.end method

.method public constructor <init>(Ljava/util/List;Ljava/util/List;)V
    .locals 1

    const-string v0, "keys"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "values"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 419
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->keys:Ljava/util/List;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->values:Ljava/util/List;

    return-void
.end method

.method private static final synthetic _childSerializers$_anonymous_()Lkotlinx/serialization/KSerializer;
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ArrayListSerializer;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/IntSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/IntSerializer;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ArrayListSerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-object v0
.end method

.method public static final synthetic access$get$childSerializers$cp()[Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;
    .locals 1

    .line 417
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->$childSerializers:[Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-object v0
.end method

.method public static final synthetic write$Self$savedstate_release(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;Lkotlinx/serialization/encoding/CompositeEncoder;Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlinx/serialization/KSerializer;)V
    .locals 3

    .line 417
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->$childSerializers:[Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    const/4 v1, 0x0

    aget-object v0, v0, v1

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lkotlinx/serialization/SerializationStrategy;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->keys:Ljava/util/List;

    invoke-interface {p1, p2, v1, v0, v2}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeSerializableElement(Lkotlinx/serialization/descriptors/SerialDescriptor;ILkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ArrayListSerializer;

    invoke-direct {v0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ArrayListSerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->values:Ljava/util/List;

    const/4 p3, 0x1

    invoke-interface {p1, p2, p3, v0, p0}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeSerializableElement(Lkotlinx/serialization/descriptors/SerialDescriptor;ILkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V

    return-void
.end method


# virtual methods
.method public final getKeys()Ljava/util/List;
    .locals 1

    .line 419
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->keys:Ljava/util/List;

    return-object v0
.end method

.method public final getValues()Ljava/util/List;
    .locals 1

    .line 419
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->values:Ljava/util/List;

    return-object v0
.end method
