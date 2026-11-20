.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;
.super Ljava/lang/Object;
.source "LifecycleCameraRepository.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "Key"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 510
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static create(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;
    .locals 1

    .line 513
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/AutoValue_LifecycleCameraRepository_Key;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/AutoValue_LifecycleCameraRepository_Key;-><init>(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)V

    return-object v0
.end method


# virtual methods
.method public abstract getCameraId()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;
.end method

.method public abstract getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;
.end method
