.class public final Lcom/scanflow/datacapture/barcode/a;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public a:I

.field public final synthetic b:Lcom/scanflow/datacapture/barcode/b;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/barcode/a;->b:Lcom/scanflow/datacapture/barcode/b;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p2}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 1

    .line 0
    new-instance p1, Lcom/scanflow/datacapture/barcode/a;

    iget-object v0, p0, Lcom/scanflow/datacapture/barcode/a;->b:Lcom/scanflow/datacapture/barcode/b;

    invoke-direct {p1, v0, p2}, Lcom/scanflow/datacapture/barcode/a;-><init>(Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V

    return-object p1
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    new-instance p1, Lcom/scanflow/datacapture/barcode/a;

    iget-object v0, p0, Lcom/scanflow/datacapture/barcode/a;->b:Lcom/scanflow/datacapture/barcode/b;

    invoke-direct {p1, v0, p2}, Lcom/scanflow/datacapture/barcode/a;-><init>(Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V

    .line 2
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barcode/a;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 10

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barcode/a;->a:I

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

    iget-object p1, p0, Lcom/scanflow/datacapture/barcode/a;->b:Lcom/scanflow/datacapture/barcode/b;

    .line 1
    iget-object v1, p1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    .line 3
    const-string v3, "croppedBitmapList"

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object v3

    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineScopeKt;->CoroutineScope(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;

    move-result-object v4

    new-instance v7, Lcom/scanflow/datacapture/barinternal/A;

    const/4 v3, 0x0

    invoke-direct {v7, v1, p1, v3}, Lcom/scanflow/datacapture/barinternal/A;-><init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V

    const/4 v8, 0x3

    const/4 v9, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->async$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;

    move-result-object p1

    .line 4
    iput v2, p0, Lcom/scanflow/datacapture/barcode/a;->a:I

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
