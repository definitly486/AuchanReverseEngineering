.class Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;
.source "Builders.common.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/CoroutineContext;Z)V
    .locals 1

    const/4 v0, 0x1

    .line 97
    invoke-direct {p0, p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;ZZ)V

    return-void
.end method

.method static synthetic await$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 99
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->awaitInternal(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    return-object p0
.end method


# virtual methods
.method public await(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;->await$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
