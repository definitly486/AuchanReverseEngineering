.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;
.super Ljava/lang/Object;
.source "Camera2CameraFactory.java"

# interfaces
.implements Landroidx/camera/core/impl/CameraFactory;


# instance fields
.field private final mAvailableCameraIds:Ljava/util/List;

.field private final mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

.field private final mCameraInfos:Ljava/util/Map;

.field private final mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

.field private final mCameraOpenRetryMaxTimeoutInMs:J

.field private final mCameraStateRegistry:Landroidx/camera/core/impl/CameraStateRegistry;

.field private final mContext:Landroid/content/Context;

.field private final mDisplayInfoManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;

.field private final mThreadConfig:Landroidx/camera/core/impl/CameraThreadConfig;


# direct methods
.method public constructor <init>(Landroid/content/Context;Landroidx/camera/core/impl/CameraThreadConfig;Landroidx/camera/core/CameraSelector;J)V
    .locals 1

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 62
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraInfos:Ljava/util/Map;

    .line 69
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mContext:Landroid/content/Context;

    .line 70
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mThreadConfig:Landroidx/camera/core/impl/CameraThreadConfig;

    .line 71
    invoke-virtual {p2}, Landroidx/camera/core/impl/CameraThreadConfig;->getSchedulerHandler()Landroid/os/Handler;

    move-result-object p2

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;->from(Landroid/content/Context;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    .line 72
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;->getInstance(Landroid/content/Context;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mDisplayInfoManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;

    .line 74
    invoke-static {p0, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraSelectionOptimizer;->getSelectedAvailableCameraIds(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;Landroidx/camera/core/CameraSelector;)Ljava/util/List;

    move-result-object p1

    .line 76
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->getBackwardCompatibleCameraIds(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mAvailableCameraIds:Ljava/util/List;

    .line 77
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    .line 78
    new-instance p2, Landroidx/camera/core/impl/CameraStateRegistry;

    const/4 p3, 0x1

    invoke-direct {p2, p1, p3}, Landroidx/camera/core/impl/CameraStateRegistry;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;I)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraStateRegistry:Landroidx/camera/core/impl/CameraStateRegistry;

    .line 80
    invoke-interface {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;->addListener(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;)V

    .line 81
    iput-wide p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraOpenRetryMaxTimeoutInMs:J

    return-void
.end method

.method private getBackwardCompatibleCameraIds(Ljava/util/List;)Ljava/util/List;
    .locals 4

    .line 137
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 139
    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_3

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 142
    const-string v2, "0"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_2

    const-string v2, "1"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    goto :goto_1

    .line 145
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraIdUtil;->isBackwardCompatible(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 146
    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 148
    :cond_1
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Camera "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " is filtered out because its capabilities do not contain REQUEST_AVAILABLE_CAPABILITIES_BACKWARD_COMPATIBLE."

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "Camera2CameraFactory"

    invoke-static {v2, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 143
    :cond_2
    :goto_1
    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_3
    return-object v0
.end method


# virtual methods
.method public getAvailableCameraIds()Ljava/util/Set;
    .locals 2

    .line 120
    new-instance v0, Ljava/util/LinkedHashSet;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mAvailableCameraIds:Ljava/util/List;

    invoke-direct {v0, v1}, Ljava/util/LinkedHashSet;-><init>(Ljava/util/Collection;)V

    return-object v0
.end method

.method public getCamera(Ljava/lang/String;)Landroidx/camera/core/impl/CameraInternal;
    .locals 13

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mAvailableCameraIds:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 91
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mContext:Landroid/content/Context;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    .line 93
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->getCameraInfo(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    move-result-object v5

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraStateRegistry:Landroidx/camera/core/impl/CameraStateRegistry;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mThreadConfig:Landroidx/camera/core/impl/CameraThreadConfig;

    .line 96
    invoke-virtual {v0}, Landroidx/camera/core/impl/CameraThreadConfig;->getCameraExecutor()Ljava/util/concurrent/Executor;

    move-result-object v8

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mThreadConfig:Landroidx/camera/core/impl/CameraThreadConfig;

    .line 97
    invoke-virtual {v0}, Landroidx/camera/core/impl/CameraThreadConfig;->getSchedulerHandler()Landroid/os/Handler;

    move-result-object v9

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mDisplayInfoManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;

    iget-wide v11, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraOpenRetryMaxTimeoutInMs:J

    move-object v4, p1

    invoke-direct/range {v1 .. v12}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;-><init>(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;Landroidx/camera/core/impl/CameraStateRegistry;Ljava/util/concurrent/Executor;Landroid/os/Handler;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;J)V

    return-object v1

    .line 88
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "The given camera id is not on the available camera id list."

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public getCameraCoordinator()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;
    .locals 1

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    return-object v0
.end method

.method getCameraInfo(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;
    .locals 2

    .line 105
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraInfos:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    if-nez v0, :cond_0

    .line 107
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    invoke-direct {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;)V

    .line 109
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraInfos:Ljava/util/Map;

    invoke-interface {v1, p1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraAccessExceptionCompat; {:try_start_0 .. :try_end_0} :catch_0

    return-object v0

    :catch_0
    move-exception p1

    goto :goto_0

    :cond_0
    return-object v0

    .line 113
    :goto_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraUnavailableExceptionHelper;->createFrom(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraAccessExceptionCompat;)Landroidx/camera/core/CameraUnavailableException;

    move-result-object p1

    throw p1
.end method

.method public getCameraManager()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;
    .locals 1

    .line 132
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    return-object v0
.end method

.method public bridge synthetic getCameraManager()Ljava/lang/Object;
    .locals 1

    .line 48
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraFactory;->getCameraManager()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    move-result-object v0

    return-object v0
.end method
