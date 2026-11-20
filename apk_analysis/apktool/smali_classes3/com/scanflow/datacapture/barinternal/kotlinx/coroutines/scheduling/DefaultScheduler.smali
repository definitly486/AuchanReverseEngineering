.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;
.source "Dispatcher.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;

    return-void
.end method

.method private constructor <init>()V
    .locals 6

    .line 10
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->CORE_POOL_SIZE:I

    sget v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->MAX_POOL_SIZE:I

    .line 11
    sget-wide v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->IDLE_WORKER_KEEP_ALIVE_NS:J

    sget-object v5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->DEFAULT_SCHEDULER_NAME:Ljava/lang/String;

    move-object v0, p0

    .line 9
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;-><init>(IIJLjava/lang/String;)V

    return-void
.end method


# virtual methods
.method public close()V
    .locals 2

    .line 29
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    const-string v1, "Dispatchers.Default cannot be closed"

    invoke-direct {v0, v1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 15
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->checkParallelism(I)V

    .line 16
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->CORE_POOL_SIZE:I

    if-lt p1, v0, :cond_0

    .line 17
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LimitedDispatcherKt;->namedOrThis(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1

    .line 19
    :cond_0
    invoke-super {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 32
    const-string v0, "Dispatchers.Default"

    return-object v0
.end method
