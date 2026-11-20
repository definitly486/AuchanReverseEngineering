.class public final synthetic Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/android/gms/tasks/OnCompleteListener;


# instance fields
.field public final synthetic f$0:Z

.field public final synthetic f$1:Landroid/graphics/Bitmap;

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic f$3:Ljava/lang/String;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/b;

.field public final synthetic f$5:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

.field public final synthetic f$6:I


# direct methods
.method public synthetic constructor <init>(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/M;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$0:Z

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$1:Landroid/graphics/Bitmap;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$2:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$3:Ljava/lang/String;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$4:Lcom/scanflow/datacapture/barinternal/b;

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$5:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$6:I

    return-void
.end method


# virtual methods
.method public final onComplete(Lcom/google/android/gms/tasks/Task;)V
    .locals 8

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$0:Z

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$1:Landroid/graphics/Bitmap;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$2:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$3:Ljava/lang/String;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$4:Lcom/scanflow/datacapture/barinternal/b;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$5:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;->f$6:I

    move-object v7, p1

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/M;->a(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/M;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;ILcom/google/android/gms/tasks/Task;)V

    return-void
.end method
