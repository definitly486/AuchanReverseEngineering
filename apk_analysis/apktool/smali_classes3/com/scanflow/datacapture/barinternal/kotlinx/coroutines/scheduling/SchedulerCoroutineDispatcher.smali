.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;
.source "Dispatcher.kt"


# instance fields
.field private final corePoolSize:I

.field private coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

.field private final idleWorkerKeepAliveNs:J

.field private final maxPoolSize:I

.field private final schedulerName:Ljava/lang/String;


# direct methods
.method public constructor <init>(IIJLjava/lang/String;)V
    .locals 0

    .line 103
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;-><init>()V

    .line 99
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->corePoolSize:I

    .line 100
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->maxPoolSize:I

    .line 101
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->idleWorkerKeepAliveNs:J

    .line 102
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->schedulerName:Ljava/lang/String;

    .line 109
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->createScheduler()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    return-void
.end method

.method private final createScheduler()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;
    .locals 6

    .line 112
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->corePoolSize:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->maxPoolSize:I

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->idleWorkerKeepAliveNs:J

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->schedulerName:Ljava/lang/String;

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;-><init>(IIJLjava/lang/String;)V

    return-object v0
.end method


# virtual methods
.method public dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 6

    .line 114
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    const/4 v4, 0x6

    const/4 v5, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    move-object v1, p2

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;->dispatch$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;Ljava/lang/Runnable;ZZILjava/lang/Object;)V

    return-void
.end method

.method public final dispatchWithContext$kotlinx_coroutines_core(Ljava/lang/Runnable;ZZ)V
    .locals 1

    .line 130
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    invoke-virtual {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;->dispatch(Ljava/lang/Runnable;ZZ)V

    return-void
.end method

.method public dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 6

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    const/4 v4, 0x2

    const/4 v5, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x1

    move-object v1, p2

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;->dispatch$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;Ljava/lang/Runnable;ZZILjava/lang/Object;)V

    return-void
.end method

.method public getExecutor()Ljava/util/concurrent/Executor;
    .locals 1

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerCoroutineDispatcher;->coroutineScheduler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/CoroutineScheduler;

    return-object v0
.end method
