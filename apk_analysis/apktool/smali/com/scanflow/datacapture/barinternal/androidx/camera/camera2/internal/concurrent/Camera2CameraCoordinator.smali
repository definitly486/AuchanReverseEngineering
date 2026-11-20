.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;
.super Ljava/lang/Object;
.source "Camera2CameraCoordinator.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;


# instance fields
.field private mActiveConcurrentCameraInfos:Ljava/util/List;

.field private final mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

.field private mCameraOperatingMode:I

.field private final mConcurrentCameraIdMap:Ljava/util/Map;

.field private mConcurrentCameraIds:Ljava/util/Set;

.field private final mConcurrentCameraModeListeners:Ljava/util/List;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;)V
    .locals 1

    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    .line 59
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    .line 62
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    .line 63
    new-instance p1, Ljava/util/HashMap;

    invoke-direct {p1}, Ljava/util/HashMap;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    .line 64
    new-instance p1, Ljava/util/HashSet;

    invoke-direct {p1}, Ljava/util/HashSet;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIds:Ljava/util/Set;

    .line 65
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraModeListeners:Ljava/util/List;

    .line 66
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mActiveConcurrentCameraInfos:Ljava/util/List;

    .line 67
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->retrieveConcurrentCameraIds()V

    return-void
.end method

.method private retrieveConcurrentCameraIds()V
    .locals 10

    .line 155
    const-string v0, "Camera2CameraCoordinator"

    new-instance v1, Ljava/util/HashSet;

    invoke-direct {v1}, Ljava/util/HashSet;-><init>()V

    .line 157
    :try_start_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;->getConcurrentCameraIds()Ljava/util/Set;

    move-result-object v1
    :try_end_0
    .catch Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraAccessExceptionCompat; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 159
    :catch_0
    const-string v2, "Failed to get concurrent camera ids"

    invoke-static {v0, v2}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    .line 162
    :goto_0
    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_3

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/Set;

    .line 163
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3, v2}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    .line 165
    invoke-interface {v3}, Ljava/util/List;->size()I

    move-result v2

    const/4 v4, 0x2

    if-lt v2, v4, :cond_0

    const/4 v2, 0x0

    .line 166
    invoke-interface {v3, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    const/4 v5, 0x1

    .line 167
    invoke-interface {v3, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 170
    :try_start_1
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    invoke-static {v7, v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraIdUtil;->isBackwardCompatible(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_0

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraManager:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    .line 171
    invoke-static {v7, v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraIdUtil;->isBackwardCompatible(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/lang/String;)Z

    move-result v7
    :try_end_1
    .catch Landroidx/camera/core/InitializationException; {:try_start_1 .. :try_end_1} :catch_1

    if-eqz v7, :cond_0

    .line 179
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIds:Ljava/util/Set;

    new-instance v8, Ljava/util/HashSet;

    filled-new-array {v4, v6}, [Ljava/lang/String;

    move-result-object v9

    invoke-static {v9}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v9

    invoke-direct {v8, v9}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    invoke-interface {v7, v8}, Ljava/util/Set;->add(Ljava/lang/Object;)Z

    .line 180
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v7, v4}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_1

    .line 181
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    invoke-interface {v7, v4, v8}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 183
    :cond_1
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v7, v6}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_2

    .line 184
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    invoke-interface {v7, v6, v8}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 186
    :cond_2
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v7, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v3, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 187
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v4, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v3, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    invoke-interface {v4, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto/16 :goto_1

    .line 173
    :catch_1
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Concurrent camera id pair: ("

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, ", "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, ") is not backward compatible"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_1

    :cond_3
    return-void
.end method


# virtual methods
.method public addListener(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;)V
    .locals 1

    .line 137
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraModeListeners:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public getCameraOperatingMode()I
    .locals 1

    .line 115
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    return v0
.end method

.method public getPairedConcurrentCameraId(Ljava/lang/String;)Ljava/lang/String;
    .locals 4

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return-object v1

    .line 102
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraIdMap:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/List;

    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_1
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 103
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mActiveConcurrentCameraInfos:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_2
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroidx/camera/core/CameraInfo;

    .line 104
    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->from(Landroidx/camera/core/CameraInfo;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;

    move-result-object v3

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2CameraInfo;->getCameraId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_2

    return-object v0

    :cond_3
    return-object v1
.end method

.method public setCameraOperatingMode(I)V
    .locals 3

    .line 120
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    if-eq p1, v0, :cond_0

    .line 121
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mConcurrentCameraModeListeners:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;

    .line 122
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    invoke-interface {v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;->onCameraOperatingModeUpdated(II)V

    goto :goto_0

    .line 128
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_1

    if-eq p1, v1, :cond_1

    .line 130
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mActiveConcurrentCameraInfos:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    .line 132
    :cond_1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/concurrent/Camera2CameraCoordinator;->mCameraOperatingMode:I

    return-void
.end method
