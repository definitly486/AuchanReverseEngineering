.class public final Lcom/scanflow/datacapture/barinternal/G;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public a:I

.field public final synthetic b:Lkotlin/jvm/internal/Ref$FloatRef;

.field public final synthetic c:Ljava/lang/Float;

.field public final synthetic d:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic e:Landroidx/camera/core/Camera;

.field public final synthetic f:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# direct methods
.method public constructor <init>(Lkotlin/jvm/internal/Ref$FloatRef;Ljava/lang/Float;Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/G;->b:Lkotlin/jvm/internal/Ref$FloatRef;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/G;->c:Ljava/lang/Float;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/G;->d:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/G;->e:Landroidx/camera/core/Camera;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/G;->f:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p6}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 7

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/G;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/G;->b:Lkotlin/jvm/internal/Ref$FloatRef;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/G;->c:Ljava/lang/Float;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/G;->d:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/G;->e:Landroidx/camera/core/Camera;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/G;->f:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    move-object v6, p2

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/G;-><init>(Lkotlin/jvm/internal/Ref$FloatRef;Ljava/lang/Float;Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/G;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/G;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/G;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/G;->a:I

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

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/G;->a:I

    const-wide/16 v3, 0x1388

    invoke-static {v3, v4, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DelayKt;->delay(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    if-ne p1, v0, :cond_2

    return-object v0

    :cond_2
    :goto_0
    move p1, v2

    :goto_1
    const/16 v0, 0x65

    if-ge p1, v0, :cond_5

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/G;->b:Lkotlin/jvm/internal/Ref$FloatRef;

    iget v1, v0, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    const v3, 0x3c23d70a    # 0.01f

    sub-float/2addr v1, v3

    iput v1, v0, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    sget-object v0, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/G;->c:Ljava/lang/Float;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/G;->b:Lkotlin/jvm/internal/Ref$FloatRef;

    iget v1, v1, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    add-float/2addr v0, v1

    invoke-static {v0}, Lkotlin/coroutines/jvm/internal/Boxing;->boxFloat(F)Ljava/lang/Float;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0, v2}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    const-string v1, "%.2f"

    invoke-static {v1, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "format(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/G;->d:Lcom/scanflow/datacapture/barinternal/M;

    .line 1
    iget v1, v1, Lcom/scanflow/datacapture/barinternal/M;->o:F

    cmpl-float v1, v0, v1

    if-lez v1, :cond_3

    .line 2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/G;->e:Landroidx/camera/core/Camera;

    if-eqz v1, :cond_3

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    if-eqz v1, :cond_3

    invoke-interface {v1, v0}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_3
    const/16 v0, 0x64

    if-ne p1, v0, :cond_4

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/G;->d:Lcom/scanflow/datacapture/barinternal/M;

    const/4 v1, 0x0

    .line 3
    iput-boolean v1, v0, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    .line 4
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/G;->f:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    if-eqz v0, :cond_4

    invoke-interface {v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->OnOneTouchCallbackCompleted()V

    :cond_4
    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    :cond_5
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
