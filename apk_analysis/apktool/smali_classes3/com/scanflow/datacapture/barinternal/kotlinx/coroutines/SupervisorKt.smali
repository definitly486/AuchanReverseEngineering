.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/SupervisorKt;
.super Ljava/lang/Object;
.source "Supervisor.kt"


# direct methods
.method public static final SupervisorJob(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 1

    .line 27
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/SupervisorJobImpl;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/SupervisorJobImpl;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-object v0
.end method

.method public static synthetic SupervisorJob$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 0

    and-int/lit8 p1, p1, 0x1

    if-eqz p1, :cond_0

    const/4 p0, 0x0

    .line 26
    :cond_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/SupervisorKt;->SupervisorJob(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;

    move-result-object p0

    return-object p0
.end method
