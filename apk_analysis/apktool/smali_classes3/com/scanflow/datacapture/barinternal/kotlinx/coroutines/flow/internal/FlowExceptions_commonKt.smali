.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/FlowExceptions_commonKt;
.super Ljava/lang/Object;
.source "FlowExceptions.common.kt"


# direct methods
.method public static final checkOwnership(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbortFlowException;Ljava/lang/Object;)V
    .locals 1

    .line 18
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbortFlowException;->owner:Ljava/lang/Object;

    if-ne v0, p1, :cond_0

    return-void

    :cond_0
    throw p0
.end method
