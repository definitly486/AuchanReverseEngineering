.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;
.super Ljava/lang/Object;
.source "Mutex.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "CancellableContinuationWithOwner"
.end annotation


# instance fields
.field public final cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

.field public final owner:Ljava/lang/Object;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;


# direct methods
.method public static synthetic $r8$lambda$8mPOeXCxubJ5Vazs1GjSQ_mDVg0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->tryResume$lambda$3(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$M-VMGe65kJHV5abnfmk24jVl4vM(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->resume$lambda$6(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;Ljava/lang/Object;)V
    .locals 0

    .line 247
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 248
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    .line 250
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    return-void
.end method

.method private static final resume$lambda$6(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 277
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->unlock(Ljava/lang/Object;)V

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method private static final tryResume$lambda$3(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 260
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->access$getOwner$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    .line 261
    iget-object p3, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    invoke-virtual {p2, p0, p3}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 262
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->unlock(Ljava/lang/Object;)V

    .line 263
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method


# virtual methods
.method public cancel(Ljava/lang/Throwable;)Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->cancel(Ljava/lang/Throwable;)Z

    move-result p1

    return p1
.end method

.method public completeResume(Ljava/lang/Object;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->completeResume(Ljava/lang/Object;)V

    return-void
.end method

.method public getContext()Lkotlin/coroutines/CoroutineContext;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    return-object v0
.end method

.method public invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    return-void
.end method

.method public invokeOnCancellation(Lkotlin/jvm/functions/Function1;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellation(Lkotlin/jvm/functions/Function1;)V

    return-void
.end method

.method public resume(Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V
    .locals 2

    .line 275
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->access$getOwner$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    .line 276
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    invoke-virtual {p2, v0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 277
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner$$ExternalSyntheticLambda1;

    invoke-direct {v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;)V

    invoke-virtual {p2, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resume(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)V

    return-void
.end method

.method public bridge synthetic resume(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V
    .locals 0

    .line 246
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->resume(Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    return-void
.end method

.method public resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V

    return-void
.end method

.method public bridge synthetic resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V
    .locals 0

    .line 246
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;)V

    return-void
.end method

.method public resumeWith(Ljava/lang/Object;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method public tryResume(Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;
    .locals 2

    .line 258
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    .line 259
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner$$ExternalSyntheticLambda0;

    invoke-direct {v1, p3, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;)V

    invoke-virtual {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->tryResume(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;

    move-result-object p1

    if-eqz p1, :cond_0

    .line 265
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->access$getOwner$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    .line 266
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->owner:Ljava/lang/Object;

    invoke-virtual {p2, p3, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    :cond_0
    return-object p1
.end method

.method public bridge synthetic tryResume(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;
    .locals 0

    .line 246
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$CancellableContinuationWithOwner;->tryResume(Lcom/scanflow/datacapture/barinternal/kotlin/Unit;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
