.class public final synthetic Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/android/gms/tasks/OnCompleteListener;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic f$1:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    return-void
.end method


# virtual methods
.method public final onComplete(Lcom/google/android/gms/tasks/Task;)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/google/android/gms/tasks/Task;)V

    return-void
.end method
