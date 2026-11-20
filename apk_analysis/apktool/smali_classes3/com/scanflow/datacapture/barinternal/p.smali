.class public final Lcom/scanflow/datacapture/barinternal/p;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public final synthetic a:I

.field public final synthetic b:Lorg/opencv/core/Mat;

.field public final synthetic c:I

.field public final synthetic d:I

.field public final synthetic e:Lorg/opencv/core/Mat;


# direct methods
.method public constructor <init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V
    .locals 0

    .line 1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/p;->a:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/p;->b:Lorg/opencv/core/Mat;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/p;->c:I

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/p;->d:I

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/p;->e:Lorg/opencv/core/Mat;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p4}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 7

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/p;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/p;->a:I

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/p;->b:Lorg/opencv/core/Mat;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/p;->c:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/p;->d:I

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/p;->e:Lorg/opencv/core/Mat;

    move-object v4, p2

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/p;-><init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/p;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/p;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/p;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    const/4 p1, 0x0

    move v0, p1

    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/p;->a:I

    if-ge v0, v1, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/p;->b:Lorg/opencv/core/Mat;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/p;->c:I

    invoke-virtual {v1, v2, v0}, Lorg/opencv/core/Mat;->get(II)[D

    move-result-object v1

    aget-wide v2, v1, p1

    double-to-int v1, v2

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/p;->d:I

    if-ne v1, v2, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/p;->e:Lorg/opencv/core/Mat;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/p;->c:I

    const/4 v3, 0x1

    new-array v3, v3, [D

    const-wide/16 v4, 0x0

    aput-wide v4, v3, p1

    invoke-virtual {v1, v2, v0, v3}, Lorg/opencv/core/Mat;->put(II[D)I

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
