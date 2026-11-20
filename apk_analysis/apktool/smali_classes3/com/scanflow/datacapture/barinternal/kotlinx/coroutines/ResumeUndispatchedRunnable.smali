.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeUndispatchedRunnable;
.super Ljava/lang/Object;
.source "Executors.kt"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field private final continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

.field private final dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 184
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 185
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeUndispatchedRunnable;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    .line 186
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeUndispatchedRunnable;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .line 189
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeUndispatchedRunnable;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeUndispatchedRunnable;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;->resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V

    return-void
.end method
