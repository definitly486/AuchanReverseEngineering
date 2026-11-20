.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
.source "MainCoroutineDispatcher.kt"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 11
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract getImmediate()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;
.end method

.method public limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 0

    .line 53
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->checkParallelism(I)V

    .line 55
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->namedOrThis(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1
.end method

.method protected final toStringInternalImpl()Ljava/lang/String;
    .locals 2

    .line 65
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getMain()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;

    move-result-object v0

    if-ne p0, v0, :cond_0

    .line 66
    const-string v0, "Dispatchers.Main"

    return-object v0

    :cond_0
    const/4 v1, 0x0

    .line 68
    :try_start_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;->getImmediate()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;

    move-result-object v0
    :try_end_0
    .catch Ljava/lang/UnsupportedOperationException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-object v0, v1

    :goto_0
    if-ne p0, v0, :cond_1

    .line 70
    const-string v0, "Dispatchers.Main.immediate"

    return-object v0

    :cond_1
    return-object v1
.end method
