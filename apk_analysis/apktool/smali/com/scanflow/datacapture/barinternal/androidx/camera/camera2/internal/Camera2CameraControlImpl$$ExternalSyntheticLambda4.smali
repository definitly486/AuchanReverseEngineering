.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

.field public final synthetic f$1:I

.field public final synthetic f$2:I

.field public final synthetic f$3:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;III)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$1:I

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$3:I

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$1:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda4;->f$3:I

    check-cast p1, Ljava/lang/Void;

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->$r8$lambda$Hj4v8ny-9Vp6vtij_X0uaOOivFc(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;IIILjava/lang/Void;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
