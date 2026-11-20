.class public final synthetic Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic f$2:Z

.field public final synthetic f$3:Landroid/graphics/RectF;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/b;

.field public final synthetic f$5:Landroid/graphics/Bitmap;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/M;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$1:Lcom/scanflow/datacapture/barinternal/M;

    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$2:Z

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$3:Landroid/graphics/RectF;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$4:Lcom/scanflow/datacapture/barinternal/b;

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$5:Landroid/graphics/Bitmap;

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 7

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$1:Lcom/scanflow/datacapture/barinternal/M;

    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$2:Z

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$3:Landroid/graphics/RectF;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$4:Lcom/scanflow/datacapture/barinternal/b;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;->f$5:Landroid/graphics/Bitmap;

    move-object v6, p1

    check-cast v6, Lcom/google/mlkit/vision/text/Text;

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/M;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Landroid/graphics/Bitmap;Lcom/google/mlkit/vision/text/Text;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p1

    return-object p1
.end method
