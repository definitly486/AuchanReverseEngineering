.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;
.super Ljava/lang/Object;
.source "CameraRequest.java"


# instance fields
.field private final mCallback:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;

.field private final mCaptureConfigs:Ljava/util/List;


# direct methods
.method public constructor <init>(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;)V
    .locals 0

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 34
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;->mCaptureConfigs:Ljava/util/List;

    .line 35
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;->mCallback:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;

    return-void
.end method


# virtual methods
.method getCaptureConfigs()Ljava/util/List;
    .locals 1

    .line 40
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;->mCaptureConfigs:Ljava/util/List;

    return-object v0
.end method

.method isAborted()Z
    .locals 1

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;->mCallback:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;->isAborted()Z

    move-result v0

    return v0
.end method
