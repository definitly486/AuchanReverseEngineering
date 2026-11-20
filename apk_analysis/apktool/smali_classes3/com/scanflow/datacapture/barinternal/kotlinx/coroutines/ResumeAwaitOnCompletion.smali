.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeAwaitOnCompletion;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "JobSupport.kt"


# instance fields
.field private final continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    .locals 0

    .line 1546
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 1545
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeAwaitOnCompletion;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 1547
    const/4 v0, 0x0

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 2

    .line 1549
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object p1

    .line 1551
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v0, :cond_0

    .line 1553
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeAwaitOnCompletion;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {v0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void

    .line 1557
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeAwaitOnCompletion;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->unboxState(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {v0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method
