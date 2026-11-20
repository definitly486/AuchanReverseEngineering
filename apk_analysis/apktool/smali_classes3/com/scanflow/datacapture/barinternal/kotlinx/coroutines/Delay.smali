.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;
.super Ljava/lang/Object;
.source "Delay.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay$DefaultImpls;
    }
.end annotation


# virtual methods
.method public abstract invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
.end method

.method public abstract scheduleResumeAfterDelay(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
.end method
