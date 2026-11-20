.class public final Lcom/scanflow/datacapture/barinternal/w;
.super Lcom/scanflow/ui/ar/ArObjectTracker;
.source "SourceFile"


# instance fields
.field public final a:J

.field public final b:J

.field public final c:Landroid/os/Handler;

.field public d:Lcom/scanflow/ui/ar/ArObject;

.field public e:Landroid/graphics/RectF;

.field public f:Landroid/animation/ObjectAnimator;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 1
    invoke-direct {p0}, Lcom/scanflow/ui/ar/ArObjectTracker;-><init>()V

    const-wide/16 v0, 0x7d0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/w;->a:J

    const-wide/16 v0, 0x64

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/w;->b:J

    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/w;->c:Landroid/os/Handler;

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/w;Landroid/animation/ValueAnimator;)V
    .locals 1

    .line 2
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "it"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/animation/ValueAnimator;->getAnimatedValue()Ljava/lang/Object;

    move-result-object p1

    const-string v0, "null cannot be cast to non-null type kotlin.FloatArray"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, [F

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/w;->a([F)V

    return-void
.end method


# virtual methods
.method public final a()V
    .locals 1

    const/4 v0, 0x0

    .line 1
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/w;->d:Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/w;->a([F)V

    return-void
.end method

.method public final a([F)V
    .locals 9

    const/4 v0, 0x0

    if-eqz p1, :cond_0

    .line 3
    new-instance v1, Landroid/graphics/RectF;

    invoke-direct {v1}, Landroid/graphics/RectF;-><init>()V

    const/4 v2, 0x0

    aget v2, p1, v2

    iput v2, v1, Landroid/graphics/RectF;->left:F

    const/4 v2, 0x1

    aget v2, p1, v2

    iput v2, v1, Landroid/graphics/RectF;->top:F

    const/4 v2, 0x2

    aget v2, p1, v2

    iput v2, v1, Landroid/graphics/RectF;->right:F

    const/4 v2, 0x3

    aget p1, p1, v2

    iput p1, v1, Landroid/graphics/RectF;->bottom:F

    goto :goto_0

    :cond_0
    move-object v1, v0

    .line 4
    :goto_0
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/w;->e:Landroid/graphics/RectF;

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->d:Lcom/scanflow/ui/ar/ArObject;

    if-eqz p1, :cond_2

    new-instance v1, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component1()Ljava/lang/String;

    move-result-object v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/w;->e:Landroid/graphics/RectF;

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component3()Landroid/util/Size;

    move-result-object v4

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component4()I

    move-result v5

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component5()I

    move-result v6

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component6()Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    move-result-object v7

    const/4 v8, 0x1

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->e:Landroid/graphics/RectF;

    if-eqz p1, :cond_1

    move-object v0, v1

    :cond_1
    invoke-virtual {p0, v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->publish(Lcom/scanflow/ui/ar/ArObject;)V

    :cond_2
    return-void
.end method

.method public final processObject(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 5

    if-nez p1, :cond_1

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->e:Landroid/graphics/RectF;

    if-eqz p1, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->c:Landroid/os/Handler;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/w;)V

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/w;->a:J

    invoke-virtual {p1, v0, v1, v2}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    :cond_0
    return-void

    .line 0
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/w;->c:Landroid/os/Handler;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/w;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->removeCallbacks(Ljava/lang/Runnable;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/w;->e:Landroid/graphics/RectF;

    if-eqz v0, :cond_2

    .line 1
    iget v1, v0, Landroid/graphics/RectF;->left:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    iget v2, v0, Landroid/graphics/RectF;->top:F

    invoke-static {v2}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v2

    iget v3, v0, Landroid/graphics/RectF;->right:F

    invoke-static {v3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v3

    iget v0, v0, Landroid/graphics/RectF;->bottom:F

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    filled-new-array {v1, v2, v3, v0}, [Ljava/lang/Float;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->toFloatArray([Ljava/lang/Float;)[F

    move-result-object v0

    if-nez v0, :cond_3

    .line 2
    :cond_2
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v0

    .line 3
    iget v1, v0, Landroid/graphics/RectF;->left:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    iget v2, v0, Landroid/graphics/RectF;->top:F

    invoke-static {v2}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v2

    iget v3, v0, Landroid/graphics/RectF;->right:F

    invoke-static {v3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v3

    iget v0, v0, Landroid/graphics/RectF;->bottom:F

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    filled-new-array {v1, v2, v3, v0}, [Ljava/lang/Float;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->toFloatArray([Ljava/lang/Float;)[F

    move-result-object v0

    .line 4
    :cond_3
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v1

    .line 5
    iget v2, v1, Landroid/graphics/RectF;->left:F

    invoke-static {v2}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v2

    iget v3, v1, Landroid/graphics/RectF;->top:F

    invoke-static {v3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v3

    iget v4, v1, Landroid/graphics/RectF;->right:F

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    iget v1, v1, Landroid/graphics/RectF;->bottom:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    filled-new-array {v2, v3, v4, v1}, [Ljava/lang/Float;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->toFloatArray([Ljava/lang/Float;)[F

    move-result-object v1

    .line 6
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->d:Lcom/scanflow/ui/ar/ArObject;

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->f:Landroid/animation/ObjectAnimator;

    if-eqz p1, :cond_4

    invoke-virtual {p1}, Landroid/animation/Animator;->cancel()V

    :cond_4
    filled-new-array {v0, v1}, [[F

    move-result-object p1

    const-string v0, "boundingBox"

    invoke-static {p0, v0, p1}, Landroid/animation/ObjectAnimator;->ofMultiFloat(Ljava/lang/Object;Ljava/lang/String;[[F)Landroid/animation/ObjectAnimator;

    move-result-object p1

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/w;->b:J

    invoke-virtual {p1, v0, v1}, Landroid/animation/ObjectAnimator;->setDuration(J)Landroid/animation/ObjectAnimator;

    new-instance v0, Landroid/view/animation/LinearInterpolator;

    invoke-direct {v0}, Landroid/view/animation/LinearInterpolator;-><init>()V

    invoke-virtual {p1, v0}, Landroid/animation/Animator;->setInterpolator(Landroid/animation/TimeInterpolator;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/w$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/w;)V

    invoke-virtual {p1, v0}, Landroid/animation/ValueAnimator;->addUpdateListener(Landroid/animation/ValueAnimator$AnimatorUpdateListener;)V

    invoke-virtual {p1}, Landroid/animation/ObjectAnimator;->start()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/w;->f:Landroid/animation/ObjectAnimator;

    return-void
.end method
