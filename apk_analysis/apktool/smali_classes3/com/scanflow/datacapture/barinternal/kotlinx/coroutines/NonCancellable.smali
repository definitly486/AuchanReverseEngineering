.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;
.super Lkotlin/coroutines/AbstractCoroutineContextElement;
.source "NonCancellable.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonCancellable;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 26
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-direct {p0, v0}, Lkotlin/coroutines/AbstractCoroutineContextElement;-><init>(Lkotlin/coroutines/CoroutineContext$Key;)V

    return-void
.end method


# virtual methods
.method public attachChild(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildJob;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;
    .locals 0

    .line 133
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    return-object p1
.end method

.method public cancel(Ljava/util/concurrent/CancellationException;)V
    .locals 0

    .line 111
    return-void
.end method

.method public getCancellationException()Ljava/util/concurrent/CancellationException;
    .locals 2

    .line 89
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "This job is always active"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public invokeOnCompletion(Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 96
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    return-object p1
.end method

.method public invokeOnCompletion(ZZLkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 104
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    return-object p1
.end method

.method public isActive()Z
    .locals 1

    .line 44
    const/4 v0, 0x1

    return v0
.end method

.method public isCancelled()Z
    .locals 1

    .line 58
    const/4 v0, 0x0

    return v0
.end method

.method public join(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 73
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    const-string v0, "This job is always active"

    invoke-direct {p1, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public start()Z
    .locals 1

    .line 65
    const/4 v0, 0x0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 137
    const-string v0, "NonCancellable"

    return-object v0
.end method
