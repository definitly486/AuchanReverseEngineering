.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "JobSupport.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;


# instance fields
.field public final childJob:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;)V
    .locals 0

    .line 1577
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 1576
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;->childJob:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;

    return-void
.end method


# virtual methods
.method public childCancelled(Ljava/lang/Throwable;)Z
    .locals 1

    .line 1581
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->childCancelled(Ljava/lang/Throwable;)Z

    move-result p1

    return p1
.end method

.method public getOnCancelling()Z
    .locals 1

    .line 1579
    const/4 v0, 0x1

    return v0
.end method

.method public getParent()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
    .locals 1

    .line 1578
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    return-object v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 1580
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;->childJob:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    invoke-interface {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;->parentCancelled(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ParentJob;)V

    return-void
.end method
