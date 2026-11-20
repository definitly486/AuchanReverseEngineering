.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbstractSharedFlowSlot;
.source "SharedFlow.kt"


# instance fields
.field public cont:Lkotlin/coroutines/Continuation;

.field public index:J


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 294
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbstractSharedFlowSlot;-><init>()V

    const-wide/16 v0, -0x1

    .line 296
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->index:J

    return-void
.end method


# virtual methods
.method public allocateLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;)Z
    .locals 4

    .line 302
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->index:J

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-ltz v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 303
    :cond_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;->updateNewCollectorIndexLocked$kotlinx_coroutines_core()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->index:J

    const/4 p1, 0x1

    return p1
.end method

.method public bridge synthetic allocateLocked(Ljava/lang/Object;)Z
    .locals 0

    .line 294
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->allocateLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;)Z

    move-result p1

    return p1
.end method

.method public freeLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;)[Lkotlin/coroutines/Continuation;
    .locals 4

    .line 309
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->index:J

    const-wide/16 v2, -0x1

    .line 310
    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->index:J

    const/4 v2, 0x0

    .line 311
    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->cont:Lkotlin/coroutines/Continuation;

    .line 312
    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;->updateCollectorIndexLocked$kotlinx_coroutines_core(J)[Lkotlin/coroutines/Continuation;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic freeLocked(Ljava/lang/Object;)[Lkotlin/coroutines/Continuation;
    .locals 0

    .line 294
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowSlot;->freeLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;)[Lkotlin/coroutines/Continuation;

    move-result-object p1

    return-object p1
.end method
