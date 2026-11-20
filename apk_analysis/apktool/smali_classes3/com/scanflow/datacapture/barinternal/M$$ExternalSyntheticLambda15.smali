.class public final synthetic Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda15;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/android/gms/tasks/OnFailureListener;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda15;->f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    return-void
.end method


# virtual methods
.method public final onFailure(Ljava/lang/Exception;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda15;->f$0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Exception;)V

    return-void
.end method
