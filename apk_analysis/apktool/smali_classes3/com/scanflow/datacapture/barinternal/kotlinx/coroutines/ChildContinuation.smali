.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildContinuation;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "CancellableContinuationImpl.kt"


# instance fields
.field public final child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    .locals 0

    .line 694
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 693
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildContinuation;->child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 695
    const/4 v0, 0x1

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 698
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildContinuation;->child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContinuationCancellationCause(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->parentCancelled$kotlinx_coroutines_core(Ljava/lang/Throwable;)V

    return-void
.end method
