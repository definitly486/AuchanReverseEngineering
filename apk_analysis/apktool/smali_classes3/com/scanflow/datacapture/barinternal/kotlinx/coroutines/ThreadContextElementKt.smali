.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElementKt;
.super Ljava/lang/Object;
.source "ThreadContextElement.kt"


# direct methods
.method public static final asContextElement(Ljava/lang/ThreadLocal;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement;
    .locals 1

    .line 247
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadLocalElement;

    invoke-direct {v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadLocalElement;-><init>(Ljava/lang/Object;Ljava/lang/ThreadLocal;)V

    return-object v0
.end method
