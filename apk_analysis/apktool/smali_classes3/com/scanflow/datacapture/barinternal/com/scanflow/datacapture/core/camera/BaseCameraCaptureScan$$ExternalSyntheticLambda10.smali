.class public final synthetic Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda10;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/ImageAnalysis$Analyzer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    return-void
.end method


# virtual methods
.method public final analyze(Landroidx/camera/core/ImageProxy;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroidx/camera/core/ImageProxy;)V

    return-void
.end method
