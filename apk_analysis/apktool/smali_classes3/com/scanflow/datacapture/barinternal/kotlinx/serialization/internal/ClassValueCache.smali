.class final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;
.super Ljava/lang/Object;
.source "Caching.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/SerializerCache;


# instance fields
.field private final classValue:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;

.field private final compute:Lkotlin/jvm/functions/Function1;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function1;)V
    .locals 1

    const-string v0, "compute"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 47
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->compute:Lkotlin/jvm/functions/Function1;

    .line 48
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->classValue:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;

    return-void
.end method


# virtual methods
.method public get(Lkotlin/reflect/KClass;)Lkotlinx/serialization/KSerializer;
    .locals 2

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 51
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->classValue:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;

    .line 52
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object v1

    .line 220
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$$ExternalSyntheticApiModelOutline0;->m(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object v0

    const-string v1, "get(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;

    .line 222
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;->reference:Ljava/lang/ref/SoftReference;

    invoke-virtual {v1}, Ljava/lang/ref/SoftReference;->get()Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_0

    goto :goto_0

    .line 224
    :cond_0
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;Lkotlin/reflect/KClass;)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;->getOrSetWithLock(Lkotlin/jvm/functions/Function0;)Ljava/lang/Object;

    move-result-object v1

    :goto_0
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;

    iget-object p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;->serializer:Lkotlinx/serialization/KSerializer;

    return-object p1
.end method

.method public final getCompute()Lkotlin/jvm/functions/Function1;
    .locals 1

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->compute:Lkotlin/jvm/functions/Function1;

    return-object v0
.end method
