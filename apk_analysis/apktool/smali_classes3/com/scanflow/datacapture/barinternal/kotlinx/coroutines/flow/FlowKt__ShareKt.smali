.class abstract synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/FlowKt__ShareKt;
.super Ljava/lang/Object;
.source "Share.kt"


# direct methods
.method public static final asStateFlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/MutableStateFlow;)Lkotlinx/coroutines/flow/StateFlow;
    .locals 2

    .line 368
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;

    const/4 v1, 0x0

    invoke-direct {v0, p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;-><init>(Lkotlinx/coroutines/flow/StateFlow;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-object v0
.end method
