.class final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;
.super Ljava/lang/Object;
.source "Caching.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedSerializerCache;


# instance fields
.field private final cache:Ljava/util/concurrent/ConcurrentHashMap;

.field private final compute:Lkotlin/jvm/functions/Function2;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function2;)V
    .locals 1

    const-string v0, "compute"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 153
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;->compute:Lkotlin/jvm/functions/Function2;

    .line 155
    new-instance p1, Ljava/util/concurrent/ConcurrentHashMap;

    invoke-direct {p1}, Ljava/util/concurrent/ConcurrentHashMap;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;->cache:Ljava/util/concurrent/ConcurrentHashMap;

    return-void
.end method


# virtual methods
.method public get-gIAlu-s(Lkotlin/reflect/KClass;Ljava/util/List;)Ljava/lang/Object;
    .locals 5

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "types"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 158
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;->cache:Ljava/util/concurrent/ConcurrentHashMap;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object v1

    .line 220
    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    if-nez v2, :cond_1

    .line 158
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedCacheEntry;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedCacheEntry;-><init>()V

    .line 221
    invoke-interface {v0, v1, v2}, Ljava/util/concurrent/ConcurrentMap;->putIfAbsent(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    move-object v2, v0

    .line 220
    :cond_1
    :goto_0
    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedCacheEntry;

    .line 223
    move-object v0, p2

    check-cast v0, Ljava/lang/Iterable;

    .line 224
    new-instance v1, Ljava/util/ArrayList;

    const/16 v3, 0xa

    invoke-static {v0, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->collectionSizeOrDefault(Ljava/lang/Iterable;I)I

    move-result v3

    invoke-direct {v1, v3}, Ljava/util/ArrayList;-><init>(I)V

    .line 225
    invoke-interface {v0}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_1
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_2

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    .line 226
    check-cast v3, Lkotlin/reflect/KType;

    .line 223
    new-instance v4, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/KTypeWrapper;

    invoke-direct {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/KTypeWrapper;-><init>(Lkotlin/reflect/KType;)V

    .line 226
    invoke-interface {v1, v4}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    goto :goto_1

    .line 228
    :cond_2
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedCacheEntry;->access$getSerializers$p(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedCacheEntry;)Ljava/util/concurrent/ConcurrentHashMap;

    move-result-object v0

    .line 229
    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    if-nez v2, :cond_4

    .line 231
    :try_start_0
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    .line 159
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;->compute:Lkotlin/jvm/functions/Function2;

    invoke-interface {v2, p1, p2}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lkotlinx/serialization/KSerializer;

    .line 231
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_2

    :catchall_0
    move-exception p1

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    :goto_2
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Result;

    move-result-object p1

    .line 230
    invoke-interface {v0, v1, p1}, Ljava/util/concurrent/ConcurrentMap;->putIfAbsent(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    if-nez p2, :cond_3

    move-object v2, p1

    goto :goto_3

    :cond_3
    move-object v2, p2

    .line 228
    :cond_4
    :goto_3
    const-string p1, "getOrPut(...)"

    invoke-static {v2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->unbox-impl()Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
