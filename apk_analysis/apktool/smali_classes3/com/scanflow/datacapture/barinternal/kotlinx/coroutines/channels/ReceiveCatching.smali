.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;
.super Ljava/lang/Object;
.source "BufferedChannel.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;


# instance fields
.field public final cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    .locals 0

    .line 3029
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3030
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-void
.end method


# virtual methods
.method public invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    return-void
.end method
