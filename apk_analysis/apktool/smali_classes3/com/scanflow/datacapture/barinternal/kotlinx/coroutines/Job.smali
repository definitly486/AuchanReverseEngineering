.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
.super Ljava/lang/Object;
.source "Job.kt"

# interfaces
.implements Lkotlin/coroutines/CoroutineContext$Element;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$DefaultImpls;,
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;
    }
.end annotation


# static fields
.field public static final Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;->$$INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    return-void
.end method


# virtual methods
.method public abstract attachChild(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;
.end method

.method public abstract cancel(Ljava/util/concurrent/CancellationException;)V
.end method

.method public abstract getCancellationException()Ljava/util/concurrent/CancellationException;
.end method

.method public abstract invokeOnCompletion(Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
.end method

.method public abstract invokeOnCompletion(ZZLkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
.end method

.method public abstract isActive()Z
.end method

.method public abstract isCancelled()Z
.end method

.method public abstract isCompleted()Z
.end method

.method public abstract join(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
.end method

.method public abstract start()Z
.end method
