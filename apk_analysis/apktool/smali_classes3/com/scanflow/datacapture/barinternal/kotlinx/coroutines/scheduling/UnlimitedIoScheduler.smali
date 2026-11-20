.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
.source "Dispatcher.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 36
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;-><init>()V

    return-void
.end method


# virtual methods
.method public dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 2

    .line 44
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;

    const/4 v0, 0x1

    const/4 v1, 0x0

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->dispatchWithContext$kotlinx_coroutines_core(Ljava/lang/Runnable;ZZ)V

    return-void
.end method

.method public dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 40
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;

    const/4 v0, 0x1

    invoke-virtual {p1, p2, v0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->dispatchWithContext$kotlinx_coroutines_core(Ljava/lang/Runnable;ZZ)V

    return-void
.end method

.method public limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 48
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->checkParallelism(I)V

    .line 49
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->MAX_POOL_SIZE:I

    if-lt p1, v0, :cond_0

    .line 50
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->namedOrThis(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1

    .line 52
    :cond_0
    invoke-super {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 57
    const-string v0, "Dispatchers.IO"

    return-object v0
.end method
