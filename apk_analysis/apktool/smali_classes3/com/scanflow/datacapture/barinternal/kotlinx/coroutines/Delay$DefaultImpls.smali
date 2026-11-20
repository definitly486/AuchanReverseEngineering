.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay$DefaultImpls;
.super Ljava/lang/Object;
.source "Delay.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "DefaultImpls"
.end annotation


# direct methods
.method public static invokeOnTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 53
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->getDefaultDelay()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    move-result-object p0

    invoke-interface {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;->invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method
