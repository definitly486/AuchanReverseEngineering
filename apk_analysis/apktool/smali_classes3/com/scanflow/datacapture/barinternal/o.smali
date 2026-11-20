.class public final Lcom/scanflow/datacapture/barinternal/o;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public synthetic a:Ljava/lang/Object;

.field public final synthetic b:I

.field public final synthetic c:I

.field public final synthetic d:Lorg/opencv/core/Mat;

.field public final synthetic e:I

.field public final synthetic f:Lorg/opencv/core/Mat;


# direct methods
.method public constructor <init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V
    .locals 0

    .line 1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/o;->b:I

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/o;->c:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/o;->d:Lorg/opencv/core/Mat;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/o;->e:I

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/o;->f:Lorg/opencv/core/Mat;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p4}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 7

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/o;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/o;->b:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/o;->c:I

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/o;->d:Lorg/opencv/core/Mat;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/o;->e:I

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/o;->f:Lorg/opencv/core/Mat;

    move-object v4, p2

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/o;-><init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/o;->a:Ljava/lang/Object;

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/o;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/o;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/o;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 8

    .line 1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/o;->a:Ljava/lang/Object;

    move-object v0, p1

    check-cast v0, Lkotlinx/coroutines/CoroutineScope;

    const/4 p1, 0x0

    move v3, p1

    :goto_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/o;->b:I

    if-ge v3, p1, :cond_0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getDefault()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    new-instance v1, Lcom/scanflow/datacapture/barinternal/n;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/o;->c:I

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/o;->d:Lorg/opencv/core/Mat;

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/o;->e:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/o;->f:Lorg/opencv/core/Mat;

    const/4 v5, 0x0

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/n;-><init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    move v6, v3

    const/4 v4, 0x2

    const/4 v2, 0x0

    move-object v3, v1

    move-object v1, p1

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    add-int/lit8 v3, v6, 0x1

    goto :goto_0

    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
