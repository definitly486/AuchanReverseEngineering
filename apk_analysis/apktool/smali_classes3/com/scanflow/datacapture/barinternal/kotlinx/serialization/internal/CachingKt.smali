.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CachingKt;
.super Ljava/lang/Object;
.source "Caching.kt"


# static fields
.field private static final useClassValue:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 21
    :try_start_0
    const-string v0, "java.lang.ClassValue"

    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 v0, 0x1

    goto :goto_0

    :catchall_0
    const/4 v0, 0x0

    .line 20
    :goto_0
    sput-boolean v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CachingKt;->useClassValue:Z

    return-void
.end method

.method public static final createCache(Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/SerializerCache;
    .locals 1

    const-string v0, "factory"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 34
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CachingKt;->useClassValue:Z

    if-eqz v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueCache;-><init>(Lkotlin/jvm/functions/Function1;)V

    return-object v0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapCache;-><init>(Lkotlin/jvm/functions/Function1;)V

    return-object v0
.end method

.method public static final createParametrizedCache(Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ParametrizedSerializerCache;
    .locals 1

    const-string v0, "factory"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 44
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CachingKt;->useClassValue:Z

    if-eqz v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueParametrizedCache;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueParametrizedCache;-><init>(Lkotlin/jvm/functions/Function2;)V

    return-object v0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ConcurrentHashMapParametrizedCache;-><init>(Lkotlin/jvm/functions/Function2;)V

    return-object v0
.end method
