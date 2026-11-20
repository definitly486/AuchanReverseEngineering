.class public final Lcom/scanflow/datacapture/barinternal/F;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public a:I

.field public final synthetic b:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic c:Landroidx/camera/core/Camera;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/F;->b:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/F;->c:Landroidx/camera/core/Camera;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p3}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 2

    .line 1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/F;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/F;->b:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/F;->c:Landroidx/camera/core/Camera;

    invoke-direct {p1, v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/F;-><init>(Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lkotlin/coroutines/Continuation;)V

    return-object p1
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/F;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/F;->b:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/F;->c:Landroidx/camera/core/Camera;

    invoke-direct {p1, v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/F;-><init>(Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lkotlin/coroutines/Continuation;)V

    .line 2
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/F;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/F;->a:I

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

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/F;->a:I

    const-wide/16 v3, 0x7d0

    invoke-static {v3, v4, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DelayKt;->delay(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    if-ne p1, v0, :cond_2

    return-object v0

    :cond_2
    :goto_0
    const/high16 p1, 0x3f800000    # 1.0f

    move v0, v2

    :goto_1
    const/16 v1, 0xb

    if-ge v0, v1, :cond_5

    const v1, 0x3dcccccd    # 0.1f

    sub-float/2addr p1, v1

    sget-object v1, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-static {p1}, Lkotlin/coroutines/jvm/internal/Boxing;->boxFloat(F)Ljava/lang/Float;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1, v2}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object p1

    const-string v1, "%.2f"

    invoke-static {v1, p1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    const-string v1, "format(...)"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {p1}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result p1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/F;->b:Lcom/scanflow/datacapture/barinternal/M;

    .line 1
    iget v1, v1, Lcom/scanflow/datacapture/barinternal/M;->o:F

    cmpl-float v1, p1, v1

    if-lez v1, :cond_3

    .line 2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/F;->c:Landroidx/camera/core/Camera;

    if-eqz v1, :cond_3

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    if-eqz v1, :cond_3

    invoke-interface {v1, p1}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_3
    const/16 v1, 0xa

    if-ne v0, v1, :cond_4

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/F;->b:Lcom/scanflow/datacapture/barinternal/M;

    const/4 v3, 0x0

    .line 3
    iput-boolean v3, v1, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    :cond_4
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 4
    :cond_5
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
