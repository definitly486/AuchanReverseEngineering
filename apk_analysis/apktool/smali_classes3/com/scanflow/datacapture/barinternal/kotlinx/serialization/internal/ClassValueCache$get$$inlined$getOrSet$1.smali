.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;
.super Ljava/lang/Object;
.source "Caching.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function0;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->get(Lkotlin/reflect/KClass;)Lkotlinx/serialization/KSerializer;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic $key$inlined:Lkotlin/reflect/KClass;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;Lkotlin/reflect/KClass;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;->$key$inlined:Lkotlin/reflect/KClass;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final invoke()Ljava/lang/Object;
    .locals 3

    .line 220
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;->getCompute()Lkotlin/jvm/functions/Function1;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache$get$$inlined$getOrSet$1;->$key$inlined:Lkotlin/reflect/KClass;

    invoke-interface {v1, v2}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lkotlinx/serialization/KSerializer;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-object v0
.end method
