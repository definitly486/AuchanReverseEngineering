.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

.field public final synthetic f$1:Landroidx/camera/core/impl/CaptureConfig$Builder;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;Landroidx/camera/core/impl/CaptureConfig$Builder;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda3;->f$1:Landroidx/camera/core/impl/CaptureConfig$Builder;

    return-void
.end method


# virtual methods
.method public final attachCompleter(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline$$ExternalSyntheticLambda3;->f$1:Landroidx/camera/core/impl/CaptureConfig$Builder;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->$r8$lambda$nhzBgYhkPLWt2RGNP9NEzqXOc0o(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;Landroidx/camera/core/impl/CaptureConfig$Builder;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
