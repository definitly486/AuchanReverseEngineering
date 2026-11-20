.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCompletion;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "Job.kt"


# instance fields
.field private final handle:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)V
    .locals 0

    .line 687
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 686
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCompletion;->handle:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 688
    const/4 v0, 0x0

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 0

    .line 690
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCompletion;->handle:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;->dispose()V

    return-void
.end method
