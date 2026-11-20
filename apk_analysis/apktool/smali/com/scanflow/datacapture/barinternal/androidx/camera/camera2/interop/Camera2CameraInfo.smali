.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;
.super Ljava/lang/Object;
.source "Camera2CameraInfo.java"


# instance fields
.field private mCamera2CameraInfoImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

.field private mCamera2PhysicalCameraInfo:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;)V
    .locals 0

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 55
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->mCamera2CameraInfoImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;)V
    .locals 0

    .line 62
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 63
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->mCamera2PhysicalCameraInfo:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;

    return-void
.end method

.method public static from(Landroidx/camera/core/CameraInfo;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;
    .locals 2

    .line 77
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;

    if-eqz v0, :cond_0

    .line 78
    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;->getCamera2CameraInfo()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;

    move-result-object p0

    return-object p0

    .line 81
    :cond_0
    check-cast p0, Landroidx/camera/core/impl/CameraInfoInternal;

    .line 82
    invoke-interface {p0}, Landroidx/camera/core/impl/CameraInfoInternal;->getImplementation()Landroidx/camera/core/impl/CameraInfoInternal;

    move-result-object p0

    .line 83
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    const-string v1, "CameraInfo doesn\'t contain Camera2 implementation."

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 85
    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;->getCamera2CameraInfo()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public getCameraId()Ljava/lang/String;
    .locals 1

    .line 107
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->mCamera2PhysicalCameraInfo:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;

    if-eqz v0, :cond_0

    .line 108
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2PhysicalCameraInfoImpl;->getCameraId()Ljava/lang/String;

    move-result-object v0

    return-object v0

    .line 110
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->mCamera2CameraInfoImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;->getCameraId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
