.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;
.super Ljava/lang/Object;
.source "StateFlow.kt"


# static fields
.field private static final NONE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final PENDING:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 241
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "NONE"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->NONE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 243
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "PENDING"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->PENDING:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-void
.end method

.method public static final MutableStateFlow(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/MutableStateFlow;
    .locals 1

    .line 187
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;

    if-nez p0, :cond_0

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/NullSurrogateKt;->NULL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    :cond_0
    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;-><init>(Ljava/lang/Object;)V

    return-object v0
.end method

.method public static final synthetic access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->NONE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getPENDING$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->PENDING:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final fuseStateFlow(Lkotlinx/coroutines/flow/StateFlow;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;
    .locals 1

    if-ltz p2, :cond_0

    const/4 v0, 0x2

    if-ge p2, v0, :cond_0

    goto :goto_0

    :cond_0
    const/4 v0, -0x2

    if-ne p2, v0, :cond_1

    .line 428
    :goto_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_OLDEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    if-ne p3, v0, :cond_1

    return-object p0

    .line 431
    :cond_1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowKt;->fuseSharedFlow(Lkotlinx/coroutines/flow/SharedFlow;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;

    move-result-object p0

    return-object p0
.end method
