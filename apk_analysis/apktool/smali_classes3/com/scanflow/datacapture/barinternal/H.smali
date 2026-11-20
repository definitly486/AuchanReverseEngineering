.class public final Lcom/scanflow/datacapture/barinternal/H;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public a:I

.field public final synthetic b:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic c:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/H;->b:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/H;->c:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p3}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 2

    .line 1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/H;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/H;->b:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/H;->c:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    invoke-direct {p1, v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/H;-><init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    return-object p1
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/H;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/H;->b:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/H;->c:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    invoke-direct {p1, v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/H;-><init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    .line 2
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/H;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 11

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/H;->a:I

    const/4 v2, 0x1

    if-eqz v1, :cond_1

    if-ne v1, v2, :cond_0

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    goto :goto_0

    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "call to \'resume\' before \'invoke\' with coroutine"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/H;->b:Lcom/scanflow/datacapture/barinternal/M;

    .line 1
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/M;->Q:Ljava/util/ArrayList;

    .line 2
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/H;->c:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    .line 3
    const-string v4, "croppedBitmapList"

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v4, "listener"

    invoke-static {v3, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineScopeKt;->CoroutineScope(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;

    move-result-object v5

    new-instance v8, Lcom/scanflow/datacapture/barinternal/K;

    const/4 v4, 0x0

    invoke-direct {v8, v1, p1, v3, v4}, Lcom/scanflow/datacapture/barinternal/K;-><init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    const/4 v9, 0x3

    const/4 v10, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    invoke-static/range {v5 .. v10}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->async$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;

    move-result-object p1

    .line 4
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/H;->a:I

    invoke-interface {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;->await(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    if-ne p1, v0, :cond_2

    return-object v0

    :cond_2
    :goto_0
    check-cast p1, Ljava/util/ArrayList;

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    invoke-virtual {p1}, Ljava/util/ArrayList;->size()I

    move-result p1

    invoke-static {p1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object p1

    const-string v1, "resultOne"

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
