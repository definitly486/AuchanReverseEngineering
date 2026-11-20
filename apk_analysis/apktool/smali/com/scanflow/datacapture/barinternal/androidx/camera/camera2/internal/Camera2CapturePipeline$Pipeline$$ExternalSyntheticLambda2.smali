.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->executePostCapture()V

    return-void
.end method
