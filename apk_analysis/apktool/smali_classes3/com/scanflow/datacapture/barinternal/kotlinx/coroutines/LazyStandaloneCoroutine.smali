.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyStandaloneCoroutine;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/StandaloneCoroutine;
.source "Builders.common.kt"


# instance fields
.field private final continuation:Lkotlin/coroutines/Continuation;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;)V
    .locals 1

    const/4 v0, 0x0

    .line 200
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/StandaloneCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Z)V

    .line 201
    invoke-static {p2, p0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->createCoroutineUnintercepted(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyStandaloneCoroutine;->continuation:Lkotlin/coroutines/Continuation;

    return-void
.end method


# virtual methods
.method protected onStart()V
    .locals 1

    .line 204
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyStandaloneCoroutine;->continuation:Lkotlin/coroutines/Continuation;

    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;->startCoroutineCancellable(Lkotlin/coroutines/Continuation;Lkotlin/coroutines/Continuation;)V

    return-void
.end method
