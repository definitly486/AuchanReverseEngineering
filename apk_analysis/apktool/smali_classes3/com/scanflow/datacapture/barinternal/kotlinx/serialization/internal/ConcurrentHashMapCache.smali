.class final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;
.super Ljava/lang/Object;
.source "Caching.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/SerializerCache;


# instance fields
.field private final cache:Ljava/util/concurrent/ConcurrentHashMap;

.field private final compute:Lkotlin/jvm/functions/Function1;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function1;)V
    .locals 1

    const-string v0, "compute"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 138
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;->compute:Lkotlin/jvm/functions/Function1;

    .line 139
    new-instance p1, Ljava/util/concurrent/ConcurrentHashMap;

    invoke-direct {p1}, Ljava/util/concurrent/ConcurrentHashMap;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;->cache:Ljava/util/concurrent/ConcurrentHashMap;

    return-void
.end method


# virtual methods
.method public get(Lkotlin/reflect/KClass;)Lkotlinx/serialization/KSerializer;
    .locals 4

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 142
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;->cache:Ljava/util/concurrent/ConcurrentHashMap;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object v1

    .line 220
    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    if-nez v2, :cond_1

    .line 143
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;->compute:Lkotlin/jvm/functions/Function1;

    invoke-interface {v3, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lkotlinx/serialization/KSerializer;

    invoke-direct {v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;-><init>(Lkotlinx/serialization/KSerializer;)V

    .line 221
    invoke-interface {v0, v1, v2}, Ljava/util/concurrent/ConcurrentMap;->putIfAbsent(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    if-nez p1, :cond_0

    goto :goto_0

    :cond_0
    move-object v2, p1

    .line 220
    :cond_1
    :goto_0
    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;

    iget-object p1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;->serializer:Lkotlinx/serialization/KSerializer;

    return-object p1
.end method
