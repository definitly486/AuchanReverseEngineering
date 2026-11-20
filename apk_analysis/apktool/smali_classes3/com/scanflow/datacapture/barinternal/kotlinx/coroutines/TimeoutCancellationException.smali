.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;
.super Ljava/util/concurrent/CancellationException;
.source "Timeout.kt"


# instance fields
.field public final transient coroutine:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    const/4 v0, 0x0

    .line 175
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Ljava/util/concurrent/CancellationException;-><init>(Ljava/lang/String;)V

    .line 169
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;->coroutine:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    return-void
.end method
