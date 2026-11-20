.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;
.super Ljava/lang/Object;
.source "DefaultExecutor.kt"


# static fields
.field private static final DefaultDelay:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

.field private static final defaultMainDelayOptIn:Z


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 7
    const-string v0, "kotlinx.coroutines.main.delay"

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp(Ljava/lang/String;Z)Z

    move-result v0

    sput-boolean v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->defaultMainDelayOptIn:Z

    .line 10
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->initializeDefaultDelay()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->DefaultDelay:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    return-void
.end method

.method public static final getDefaultDelay()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;
    .locals 1

    .line 9
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->DefaultDelay:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    return-object v0
.end method

.method private static final initializeDefaultDelay()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;
    .locals 2

    .line 14
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->defaultMainDelayOptIn:Z

    if-nez v0, :cond_0

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;

    return-object v0

    .line 15
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getMain()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;

    move-result-object v0

    .line 21
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/MainDispatchersKt;->isMissing(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;)Z

    move-result v1

    if-nez v1, :cond_2

    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    if-nez v1, :cond_1

    goto :goto_0

    :cond_1
    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    return-object v0

    :cond_2
    :goto_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;

    return-object v0
.end method
