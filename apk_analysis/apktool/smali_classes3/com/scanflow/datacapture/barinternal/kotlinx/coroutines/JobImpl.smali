.class public Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;
.source "JobSupport.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;


# instance fields
.field private final handlesException:Z


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 1

    const/4 v0, 0x1

    .line 1425
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;-><init>(Z)V

    .line 1426
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->initParentJob(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    .line 1438
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;->handlesException()Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;->handlesException:Z

    return-void
.end method

.method private final handlesException()Z
    .locals 4

    .line 1445
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->getParentHandle$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;

    move-result-object v0

    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    goto :goto_0

    :cond_0
    move-object v0, v2

    :goto_0
    const/4 v1, 0x0

    if-eqz v0, :cond_4

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    if-nez v0, :cond_1

    goto :goto_2

    .line 1447
    :cond_1
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->getHandlesException$kotlinx_coroutines_core()Z

    move-result v3

    if-eqz v3, :cond_2

    const/4 v0, 0x1

    return v0

    .line 1448
    :cond_2
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->getParentHandle$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;

    move-result-object v0

    instance-of v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    if-eqz v3, :cond_3

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    goto :goto_1

    :cond_3
    move-object v0, v2

    :goto_1
    if-eqz v0, :cond_4

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getJob()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    move-result-object v0

    if-nez v0, :cond_1

    :cond_4
    :goto_2
    return v1
.end method


# virtual methods
.method public getHandlesException$kotlinx_coroutines_core()Z
    .locals 1

    .line 1438
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;->handlesException:Z

    return v0
.end method

.method public getOnCancelComplete$kotlinx_coroutines_core()Z
    .locals 1

    .line 1427
    const/4 v0, 0x1

    return v0
.end method
