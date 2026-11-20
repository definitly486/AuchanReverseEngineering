.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;

.field public final synthetic f$1:Lcom/google/common/util/concurrent/ListenableFuture;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;Lcom/google/common/util/concurrent/ListenableFuture;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda4;->f$1:Lcom/google/common/util/concurrent/ListenableFuture;

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda4;->f$1:Lcom/google/common/util/concurrent/ListenableFuture;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;->$r8$lambda$zXnUL6AjwlQEroqup7I2UDP8g6o(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;Lcom/google/common/util/concurrent/ListenableFuture;Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
