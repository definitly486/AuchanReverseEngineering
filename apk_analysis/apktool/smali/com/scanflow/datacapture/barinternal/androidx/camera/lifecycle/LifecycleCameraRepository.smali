.class final Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;
.super Ljava/lang/Object;
.source "LifecycleCameraRepository.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;
    }
.end annotation


# instance fields
.field private final mActiveLifecycleOwners:Ljava/util/ArrayDeque;

.field mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

.field private final mCameraMap:Ljava/util/Map;

.field private final mLifecycleObserverMap:Ljava/util/Map;

.field private final mLock:Ljava/lang/Object;


# direct methods
.method constructor <init>()V
    .locals 1

    .line 71
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 72
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    .line 74
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    .line 77
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    .line 81
    new-instance v0, Ljava/util/ArrayDeque;

    invoke-direct {v0}, Ljava/util/ArrayDeque;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    return-void
.end method

.method private getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;
    .locals 4

    .line 240
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 241
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v1}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    .line 242
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;->getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;

    move-result-object v3

    invoke-virtual {p1, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 243
    monitor-exit v0

    return-object v2

    :catchall_0
    move-exception p1

    goto :goto_0

    :cond_1
    const/4 p1, 0x0

    .line 247
    monitor-exit v0

    return-object p1

    .line 248
    :goto_0
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method private hasUseCaseBound(Landroidx/lifecycle/LifecycleOwner;)Z
    .locals 4

    .line 440
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 442
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object p1

    const/4 v1, 0x0

    if-nez p1, :cond_0

    .line 445
    monitor-exit v0

    return v1

    :catchall_0
    move-exception p1

    goto :goto_0

    .line 448
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v2, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/Set;

    .line 452
    invoke-interface {p1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_1
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 453
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v3, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getUseCases()Ljava/util/List;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/List;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    const/4 p1, 0x1

    .line 454
    monitor-exit v0

    return p1

    .line 458
    :cond_2
    monitor-exit v0

    return v1

    .line 459
    :goto_0
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method private registerCamera(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;)V
    .locals 6

    .line 175
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 176
    :try_start_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;

    move-result-object v1

    .line 179
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v2

    check-cast v2, Landroidx/camera/core/impl/RestrictedCameraInfo;

    .line 180
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getSecondaryCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v3

    check-cast v3, Landroidx/camera/core/impl/RestrictedCameraInfo;

    .line 178
    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->generateCameraId(Landroidx/camera/core/impl/RestrictedCameraInfo;Landroidx/camera/core/impl/RestrictedCameraInfo;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;

    move-result-object v2

    .line 177
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;->create(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    move-result-object v2

    .line 183
    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object v3

    if-eqz v3, :cond_0

    .line 188
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v4, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/Set;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 190
    :cond_0
    new-instance v4, Ljava/util/HashSet;

    invoke-direct {v4}, Ljava/util/HashSet;-><init>()V

    .line 193
    :goto_0
    invoke-interface {v4, v2}, Ljava/util/Set;->add(Ljava/lang/Object;)Z

    .line 194
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v5, v2, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    if-nez v3, :cond_1

    .line 198
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    invoke-direct {p1, v1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;-><init>(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;)V

    .line 199
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v2, p1, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 200
    invoke-interface {v1}, Landroidx/lifecycle/LifecycleOwner;->getLifecycle()Landroidx/lifecycle/Lifecycle;

    move-result-object v1

    invoke-virtual {v1, p1}, Landroidx/lifecycle/Lifecycle;->addObserver(Landroidx/lifecycle/LifecycleObserver;)V

    .line 202
    :cond_1
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method private suspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 3

    .line 466
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 468
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object p1

    if-nez p1, :cond_0

    .line 476
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 479
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v1, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/Set;

    invoke-interface {p1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 480
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->suspend()V

    goto :goto_0

    .line 482
    :cond_1
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method private unsuspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 3

    .line 491
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 493
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object p1

    .line 495
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v1, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/Set;

    invoke-interface {p1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_0
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 496
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    .line 498
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getUseCases()Ljava/util/List;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/List;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_0

    .line 499
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->unsuspend()V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 502
    :cond_1
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method


# virtual methods
.method bindToLifecycleCamera(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;Landroidx/camera/core/ViewPort;Ljava/util/List;Ljava/util/Collection;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;)V
    .locals 4

    .line 276
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 277
    :try_start_0
    invoke-interface {p4}, Ljava/util/Collection;->isEmpty()Z

    move-result v1

    xor-int/lit8 v1, v1, 0x1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(Z)V

    .line 278
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    .line 279
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;

    move-result-object p5

    .line 283
    invoke-direct {p0, p5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object v1

    if-nez v1, :cond_0

    .line 286
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p1

    goto/16 :goto_1

    .line 288
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {v2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/Set;

    .line 293
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    if-eqz v2, :cond_1

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;->getCameraOperatingMode()I

    move-result v2

    const/4 v3, 0x2

    if-eq v2, v3, :cond_4

    .line 295
    :cond_1
    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_2
    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_4

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 296
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v3, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    .line 297
    invoke-virtual {v2, p1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_2

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getUseCases()Ljava/util/List;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/List;->isEmpty()Z

    move-result v2

    if-eqz v2, :cond_3

    goto :goto_0

    .line 298
    :cond_3
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Multiple LifecycleCameras with use cases are registered to the same LifecycleOwner."

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 306
    :cond_4
    :try_start_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getCameraUseCaseAdapter()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;

    move-result-object v1

    invoke-virtual {v1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->setViewPort(Landroidx/camera/core/ViewPort;)V

    .line 307
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getCameraUseCaseAdapter()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;

    move-result-object p2

    invoke-virtual {p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->setEffects(Ljava/util/List;)V

    .line 308
    invoke-virtual {p1, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->bind(Ljava/util/Collection;)V
    :try_end_1
    .catch Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraException; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 315
    :try_start_2
    invoke-interface {p5}, Landroidx/lifecycle/LifecycleOwner;->getLifecycle()Landroidx/lifecycle/Lifecycle;

    move-result-object p1

    invoke-virtual {p1}, Landroidx/lifecycle/Lifecycle;->getCurrentState()Landroidx/lifecycle/Lifecycle$State;

    move-result-object p1

    sget-object p2, Landroidx/lifecycle/Lifecycle$State;->STARTED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {p1, p2}, Landroidx/lifecycle/Lifecycle$State;->isAtLeast(Landroidx/lifecycle/Lifecycle$State;)Z

    move-result p1

    if-eqz p1, :cond_5

    .line 317
    invoke-virtual {p0, p5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->setActive(Landroidx/lifecycle/LifecycleOwner;)V

    .line 319
    :cond_5
    monitor-exit v0

    return-void

    :catch_0
    move-exception p1

    .line 310
    new-instance p2, Ljava/lang/IllegalArgumentException;

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/Throwable;)V

    throw p2

    .line 319
    :goto_1
    monitor-exit v0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw p1
.end method

.method createLifecycleCamera(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;
    .locals 3

    .line 104
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 105
    :try_start_0
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->getCameraId()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;

    move-result-object v1

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;->create(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    move-result-object v1

    .line 106
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_0

    const/4 v1, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    :goto_0
    const-string v2, "LifecycleCamera already exists for the given LifecycleOwner and set of cameras"

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 111
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;-><init>(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;)V

    .line 113
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->getUseCases()Ljava/util/List;

    move-result-object p2

    invoke-interface {p2}, Ljava/util/List;->isEmpty()Z

    move-result p2

    if-eqz p2, :cond_1

    .line 114
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->suspend()V

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 118
    :cond_1
    :goto_1
    invoke-interface {p1}, Landroidx/lifecycle/LifecycleOwner;->getLifecycle()Landroidx/lifecycle/Lifecycle;

    move-result-object p1

    invoke-virtual {p1}, Landroidx/lifecycle/Lifecycle;->getCurrentState()Landroidx/lifecycle/Lifecycle$State;

    move-result-object p1

    sget-object p2, Landroidx/lifecycle/Lifecycle$State;->DESTROYED:Landroidx/lifecycle/Lifecycle$State;

    if-ne p1, p2, :cond_2

    .line 119
    monitor-exit v0

    return-object v1

    .line 122
    :cond_2
    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->registerCamera(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;)V

    .line 123
    monitor-exit v0

    return-object v1

    :goto_2
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method getLifecycleCamera(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;
    .locals 2

    .line 137
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 138
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;->create(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    move-result-object p1

    invoke-interface {v1, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    monitor-exit v0

    return-object p1

    :catchall_0
    move-exception p1

    .line 139
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method getLifecycleCameras()Ljava/util/Collection;
    .locals 2

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 148
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v1}, Ljava/util/Map;->values()Ljava/util/Collection;

    move-result-object v1

    invoke-static {v1}, Ljava/util/Collections;->unmodifiableCollection(Ljava/util/Collection;)Ljava/util/Collection;

    move-result-object v1

    monitor-exit v0

    return-object v1

    :catchall_0
    move-exception v1

    .line 149
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1
.end method

.method setActive(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 3

    .line 382
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 385
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->hasUseCaseBound(Landroidx/lifecycle/LifecycleOwner;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 386
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 391
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1}, Ljava/util/ArrayDeque;->isEmpty()Z

    move-result v1

    if-eqz v1, :cond_1

    .line 392
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1, p1}, Ljava/util/ArrayDeque;->push(Ljava/lang/Object;)V

    goto :goto_0

    .line 397
    :cond_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraCoordinator:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    if-eqz v1, :cond_2

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;->getCameraOperatingMode()I

    move-result v1

    const/4 v2, 0x2

    if-eq v1, v2, :cond_3

    .line 399
    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1}, Ljava/util/ArrayDeque;->peek()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroidx/lifecycle/LifecycleOwner;

    .line 400
    invoke-virtual {p1, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_3

    .line 401
    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->suspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V

    .line 403
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1, p1}, Ljava/util/ArrayDeque;->remove(Ljava/lang/Object;)Z

    .line 404
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1, p1}, Ljava/util/ArrayDeque;->push(Ljava/lang/Object;)V

    .line 409
    :cond_3
    :goto_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->unsuspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V

    .line 410
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method setInactive(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 2

    .line 422
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 424
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {v1, p1}, Ljava/util/ArrayDeque;->remove(Ljava/lang/Object;)Z

    .line 425
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->suspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V

    .line 429
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {p1}, Ljava/util/ArrayDeque;->isEmpty()Z

    move-result p1

    if-nez p1, :cond_0

    .line 430
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mActiveLifecycleOwners:Ljava/util/ArrayDeque;

    invoke-virtual {p1}, Ljava/util/ArrayDeque;->peek()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/lifecycle/LifecycleOwner;

    .line 431
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->unsuspendUseCases(Landroidx/lifecycle/LifecycleOwner;)V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 433
    :cond_0
    :goto_0
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method unbindAll()V
    .locals 4

    .line 360
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 361
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v1}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 362
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v3, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    .line 363
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->unbindAll()V

    .line 364
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;

    move-result-object v2

    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->setInactive(Landroidx/lifecycle/LifecycleOwner;)V

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_1

    .line 366
    :cond_0
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1
.end method

.method unregisterLifecycle(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 4

    .line 214
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 216
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameraRepositoryObserver(Landroidx/lifecycle/LifecycleOwner;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;

    move-result-object v1

    if-nez v1, :cond_0

    .line 223
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 226
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->setInactive(Landroidx/lifecycle/LifecycleOwner;)V

    .line 228
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {p1, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/Set;

    invoke-interface {p1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$Key;

    .line 229
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mCameraMap:Ljava/util/Map;

    invoke-interface {v3, v2}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    .line 232
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->mLifecycleObserverMap:Ljava/util/Map;

    invoke-interface {p1, v1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 233
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository$LifecycleCameraRepositoryObserver;->getLifecycleOwner()Landroidx/lifecycle/LifecycleOwner;

    move-result-object p1

    invoke-interface {p1}, Landroidx/lifecycle/LifecycleOwner;->getLifecycle()Landroidx/lifecycle/Lifecycle;

    move-result-object p1

    invoke-virtual {p1, v1}, Landroidx/lifecycle/Lifecycle;->removeObserver(Landroidx/lifecycle/LifecycleObserver;)V

    .line 235
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method
