.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

.field public final synthetic f$1:Landroidx/camera/core/impl/DeferrableSurface;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;Landroidx/camera/core/impl/DeferrableSurface;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$$ExternalSyntheticLambda2;->f$1:Landroidx/camera/core/impl/DeferrableSurface;

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$$ExternalSyntheticLambda2;->f$1:Landroidx/camera/core/impl/DeferrableSurface;

    check-cast p1, Ljava/lang/Void;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;->$r8$lambda$NmONFJs9FWMviAlYErXym9Pk_G8(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;Landroidx/camera/core/impl/DeferrableSurface;Ljava/lang/Void;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
