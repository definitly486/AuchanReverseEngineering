.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;
.source "Dispatcher.kt"

# interfaces
.implements Ljava/util/concurrent/Executor;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;

.field private static final default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;


# direct methods
.method static constructor <clinit>()V
    .locals 9

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;

    .line 64
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;

    const/16 v1, 0x40

    .line 67
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->getAVAILABLE_PROCESSORS()I

    move-result v2

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtLeast(II)I

    move-result v4

    const/16 v7, 0xc

    const/4 v8, 0x0

    .line 65
    const-string v3, "kotlinx.coroutines.io.parallelism"

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp$default(Ljava/lang/String;IIIILjava/lang/Object;)I

    move-result v1

    const/4 v2, 0x0

    const/4 v3, 0x2

    .line 64
    invoke-static {v0, v1, v2, v3, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->limitedParallelism$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;ILjava/lang/String;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 62
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;-><init>()V

    return-void
.end method


# virtual methods
.method public close()V
    .locals 2

    new-instance v0, Ljava/lang/IllegalStateException;

    .line 91
    const-string v1, "Cannot be invoked on Dispatchers.IO"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 82
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 87
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public execute(Ljava/lang/Runnable;)V
    .locals 1

    .line 74
    sget-object v0, Lkotlin/coroutines/EmptyCoroutineContext;->INSTANCE:Lkotlin/coroutines/EmptyCoroutineContext;

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public getExecutor()Ljava/util/concurrent/Executor;
    .locals 0

    .line 72
    return-object p0
.end method

.method public limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 78
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/UnlimitedIoScheduler;->limitedParallelism(ILjava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 94
    const-string v0, "Dispatchers.IO"

    return-object v0
.end method
