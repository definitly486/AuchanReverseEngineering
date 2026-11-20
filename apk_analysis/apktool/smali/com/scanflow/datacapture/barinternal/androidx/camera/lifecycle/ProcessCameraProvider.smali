.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
.super Ljava/lang/Object;
.source "ProcessCameraProvider.kt"

# interfaces
.implements Landroidx/camera/core/CameraProvider;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;

.field private static final sAppInstance:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;


# instance fields
.field private final mCameraInfoMap:Ljava/util/Map;

.field private mCameraX:Landroidx/camera/core/CameraX;

.field private mCameraXConfigProvider:Landroidx/camera/core/CameraXConfig$Provider;

.field private mCameraXInitializeFuture:Lcom/google/common/util/concurrent/ListenableFuture;

.field private mCameraXShutdownFuture:Lcom/google/common/util/concurrent/ListenableFuture;

.field private mContext:Landroid/content/Context;

.field private final mLifecycleCameraRepository:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

.field private final mLock:Ljava/lang/Object;


# direct methods
.method public static synthetic $r8$lambda$4cDi3AAzKeyJxm5RcPVvEasZ0OY(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getOrCreateCameraXInstance$lambda$18$lambda$17$lambda$16$lambda$15(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$_rcqWHl69wN3lvwkykRzEOONbC0(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getOrCreateCameraXInstance$lambda$18$lambda$17(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;

    .line 910
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->sAppInstance:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    return-void
.end method

.method private constructor <init>()V
    .locals 2

    .line 88
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 89
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLock:Ljava/lang/Object;

    const/4 v0, 0x0

    .line 95
    invoke-static {v0}, Landroidx/camera/core/impl/utils/futures/Futures;->immediateFuture(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    const-string v1, "immediateFuture<Void>(null)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraXShutdownFuture:Lcom/google/common/util/concurrent/ListenableFuture;

    .line 97
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLifecycleCameraRepository:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    .line 103
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraInfoMap:Ljava/util/Map;

    return-void
.end method

.method public static final synthetic access$getCameraConfig(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/impl/CameraConfig;
    .locals 0

    .line 88
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getCameraConfig(Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/impl/CameraConfig;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getCameraOperatingMode(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)I
    .locals 0

    .line 88
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getCameraOperatingMode()I

    move-result p0

    return p0
.end method

.method public static final synthetic access$getMCameraInfoMap$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Ljava/util/Map;
    .locals 0

    .line 88
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraInfoMap:Ljava/util/Map;

    return-object p0
.end method

.method public static final synthetic access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;
    .locals 0

    .line 88
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraX:Landroidx/camera/core/CameraX;

    return-object p0
.end method

.method public static final synthetic access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;
    .locals 0

    .line 88
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLifecycleCameraRepository:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    return-object p0
.end method

.method public static final synthetic access$getMLock$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Ljava/lang/Object;
    .locals 0

    .line 88
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLock:Ljava/lang/Object;

    return-object p0
.end method

.method public static final synthetic access$getOrCreateCameraXInstance(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 0

    .line 88
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getOrCreateCameraXInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getSAppInstance$cp()Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
    .locals 1

    .line 88
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->sAppInstance:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    return-object v0
.end method

.method public static final synthetic access$setCameraOperatingMode(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;I)V
    .locals 0

    .line 88
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->setCameraOperatingMode(I)V

    return-void
.end method

.method public static final synthetic access$setCameraX(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;)V
    .locals 0

    .line 88
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->setCameraX(Landroidx/camera/core/CameraX;)V

    return-void
.end method

.method public static final synthetic access$setContext(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroid/content/Context;)V
    .locals 0

    .line 88
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->setContext(Landroid/content/Context;)V

    return-void
.end method

.method private final getCameraConfig(Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/impl/CameraConfig;
    .locals 4

    .line 847
    invoke-virtual {p1}, Landroidx/camera/core/CameraSelector;->getCameraFilterSet()Ljava/util/LinkedHashSet;

    move-result-object p1

    invoke-virtual {p1}, Ljava/util/AbstractCollection;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const/4 v0, 0x0

    :cond_0
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_3

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    const-string v2, "cameraSelector.cameraFilterSet"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Landroidx/camera/core/CameraFilter;

    .line 848
    invoke-interface {v1}, Landroidx/camera/core/CameraFilter;->getIdentifier()Landroidx/camera/core/impl/Identifier;

    move-result-object v2

    sget-object v3, Landroidx/camera/core/CameraFilter;->DEFAULT_ID:Landroidx/camera/core/impl/Identifier;

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 850
    invoke-interface {v1}, Landroidx/camera/core/CameraFilter;->getIdentifier()Landroidx/camera/core/impl/Identifier;

    move-result-object v1

    invoke-static {v1}, Landroidx/camera/core/impl/ExtendedCameraConfigProviderStore;->getConfigProvider(Ljava/lang/Object;)Landroidx/camera/core/impl/CameraConfigProvider;

    move-result-object v1

    .line 851
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mContext:Landroid/content/Context;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v1, p2, v2}, Landroidx/camera/core/impl/CameraConfigProvider;->getConfig(Landroidx/camera/core/CameraInfo;Landroid/content/Context;)Landroidx/camera/core/impl/CameraConfig;

    move-result-object v1

    if-nez v1, :cond_1

    goto :goto_0

    :cond_1
    if-nez v0, :cond_2

    move-object v0, v1

    goto :goto_0

    .line 858
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    .line 859
    const-string p2, "Cannot apply multiple extended camera configs at the same time."

    .line 858
    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_3
    if-nez v0, :cond_4

    .line 867
    invoke-static {}, Landroidx/camera/core/impl/CameraConfigs;->defaultConfig()Landroidx/camera/core/impl/CameraConfig;

    move-result-object p1

    return-object p1

    :cond_4
    return-object v0
.end method

.method private final getCameraOperatingMode()I
    .locals 1

    .line 883
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraX:Landroidx/camera/core/CameraX;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return v0

    .line 886
    :cond_0
    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroidx/camera/core/CameraX;->getCameraFactory()Landroidx/camera/core/impl/CameraFactory;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/impl/CameraFactory;->getCameraCoordinator()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    move-result-object v0

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;->getCameraOperatingMode()I

    move-result v0

    return v0
.end method

.method private final getOrCreateCameraXInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 3

    .line 792
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 793
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraXInitializeFuture:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz v1, :cond_0

    .line 794
    const-string p1, "null cannot be cast to non-null type com.google.common.util.concurrent.ListenableFuture<androidx.camera.core.CameraX>"

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v0

    return-object v1

    :catchall_0
    move-exception p1

    goto :goto_0

    .line 796
    :cond_0
    :try_start_1
    new-instance v1, Landroidx/camera/core/CameraX;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraXConfigProvider:Landroidx/camera/core/CameraXConfig$Provider;

    invoke-direct {v1, p1, v2}, Landroidx/camera/core/CameraX;-><init>(Landroid/content/Context;Landroidx/camera/core/CameraXConfig$Provider;)V

    .line 799
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$$ExternalSyntheticLambda0;

    invoke-direct {p1, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;)V

    invoke-static {p1}, Landroidx/concurrent/futures/CallbackToFutureAdapter;->getFuture(Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    .line 798
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraXInitializeFuture:Lcom/google/common/util/concurrent/ListenableFuture;

    .line 825
    const-string v1, "null cannot be cast to non-null type com.google.common.util.concurrent.ListenableFuture<androidx.camera.core.CameraX>"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit v0

    return-object p1

    :goto_0
    monitor-exit v0

    throw p1
.end method

.method private static final getOrCreateCameraXInstance$lambda$18$lambda$17(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 3

    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "$cameraX"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "completer"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 800
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 802
    :try_start_0
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraXShutdownFuture:Lcom/google/common/util/concurrent/ListenableFuture;

    invoke-static {p0}, Landroidx/camera/core/impl/utils/futures/FutureChain;->from(Lcom/google/common/util/concurrent/ListenableFuture;)Landroidx/camera/core/impl/utils/futures/FutureChain;

    move-result-object p0

    .line 803
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$future$1;

    invoke-direct {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$future$1;-><init>(Landroidx/camera/core/CameraX;)V

    .line 804
    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$$ExternalSyntheticLambda1;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$$ExternalSyntheticLambda1;-><init>(Lkotlin/jvm/functions/Function1;)V

    .line 805
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->directExecutor()Ljava/util/concurrent/Executor;

    move-result-object v1

    .line 803
    invoke-virtual {p0, v2, v1}, Landroidx/camera/core/impl/utils/futures/FutureChain;->transformAsync(Landroidx/camera/core/impl/utils/futures/AsyncFunction;Ljava/util/concurrent/Executor;)Landroidx/camera/core/impl/utils/futures/FutureChain;

    move-result-object p0

    .line 804
    const-string v1, "cameraX = CameraX(contex\u2026                        )"

    invoke-static {p0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 809
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;

    invoke-direct {v1, p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;-><init>(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Landroidx/camera/core/CameraX;)V

    .line 818
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->directExecutor()Ljava/util/concurrent/Executor;

    move-result-object p1

    .line 807
    invoke-static {p0, v1, p1}, Landroidx/camera/core/impl/utils/futures/Futures;->addCallback(Lcom/google/common/util/concurrent/ListenableFuture;Landroidx/camera/core/impl/utils/futures/FutureCallback;Ljava/util/concurrent/Executor;)V

    .line 820
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 800
    monitor-exit v0

    .line 822
    const-string p0, "ProcessCameraProvider-initializeCameraX"

    return-object p0

    :catchall_0
    move-exception p0

    .line 800
    monitor-exit v0

    throw p0
.end method

.method private static final getOrCreateCameraXInstance$lambda$18$lambda$17$lambda$16$lambda$15(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 1

    const-string v0, "$tmp0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 804
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lcom/google/common/util/concurrent/ListenableFuture;

    return-object p0
.end method

.method private final setCameraOperatingMode(I)V
    .locals 1

    .line 889
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraX:Landroidx/camera/core/CameraX;

    if-nez v0, :cond_0

    return-void

    .line 892
    :cond_0
    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroidx/camera/core/CameraX;->getCameraFactory()Landroidx/camera/core/impl/CameraFactory;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/impl/CameraFactory;->getCameraCoordinator()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;->setCameraOperatingMode(I)V

    return-void
.end method

.method private final setCameraX(Landroidx/camera/core/CameraX;)V
    .locals 0

    .line 873
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mCameraX:Landroidx/camera/core/CameraX;

    return-void
.end method

.method private final setContext(Landroid/content/Context;)V
    .locals 0

    .line 877
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->mContext:Landroid/content/Context;

    return-void
.end method


# virtual methods
.method public final bindToLifecycle(Landroidx/lifecycle/LifecycleOwner;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/UseCaseGroup;)Landroidx/camera/core/Camera;
    .locals 11

    const-string v0, "DEFAULT"

    const-string v1, "lifecycleOwner"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "cameraSelector"

    invoke-static {p2, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "useCaseGroup"

    invoke-static {p3, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 244
    const-string v1, "CX:bindToLifecycle-UseCaseGroup"

    .line 1001
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->beginSection(Ljava/lang/String;)V

    .line 245
    :try_start_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getCameraOperatingMode(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)I

    move-result v1

    const/4 v2, 0x2

    if-eq v1, v2, :cond_0

    const/4 v1, 0x1

    .line 251
    invoke-static {p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$setCameraOperatingMode(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;I)V

    .line 257
    sget-object v6, Landroidx/camera/core/LayoutSettings;->DEFAULT:Landroidx/camera/core/LayoutSettings;

    invoke-static {v6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 258
    invoke-static {v6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 259
    invoke-virtual {p3}, Landroidx/camera/core/UseCaseGroup;->getViewPort()Landroidx/camera/core/ViewPort;

    move-result-object v8

    .line 260
    invoke-virtual {p3}, Landroidx/camera/core/UseCaseGroup;->getEffects()Ljava/util/List;

    move-result-object v9

    const-string v0, "useCaseGroup.effects"

    invoke-static {v9, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 261
    invoke-virtual {p3}, Landroidx/camera/core/UseCaseGroup;->getUseCases()Ljava/util/List;

    move-result-object p3

    const-string v0, "useCaseGroup.useCases"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p3, Ljava/util/Collection;

    const/4 v0, 0x0

    .line 1005
    new-array v0, v0, [Landroidx/camera/core/UseCase;

    invoke-interface {p3, v0}, Ljava/util/Collection;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p3

    .line 261
    check-cast p3, [Landroidx/camera/core/UseCase;

    array-length v0, p3

    invoke-static {p3, v0}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object p3

    move-object v10, p3

    check-cast v10, [Landroidx/camera/core/UseCase;

    const/4 v5, 0x0

    move-object v7, v6

    move-object v2, p0

    move-object v3, p1

    move-object v4, p2

    .line 253
    invoke-virtual/range {v2 .. v10}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->bindToLifecycle$camera_lifecycle_release(Landroidx/lifecycle/LifecycleOwner;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/ViewPort;Ljava/util/List;[Landroidx/camera/core/UseCase;)Landroidx/camera/core/Camera;

    move-result-object p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 1006
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    return-object p1

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_0

    .line 246
    :cond_0
    :try_start_1
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    .line 247
    const-string p2, "bindToLifecycle for single camera is not supported in concurrent camera mode, call unbindAll() first."

    .line 246
    invoke-direct {p1, p2}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 1006
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    throw p1
.end method

.method public final varargs bindToLifecycle$camera_lifecycle_release(Landroidx/lifecycle/LifecycleOwner;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/ViewPort;Ljava/util/List;[Landroidx/camera/core/UseCase;)Landroidx/camera/core/Camera;
    .locals 17

    move-object/from16 v1, p0

    move-object/from16 v0, p1

    move-object/from16 v2, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p8

    const-string v5, "null cannot be cast to non-null type androidx.camera.core.impl.RestrictedCameraInfo"

    const-string v6, "lifecycleOwner"

    invoke-static {v0, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "primaryCameraSelector"

    invoke-static {v2, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "primaryLayoutSettings"

    move-object/from16 v12, p4

    invoke-static {v12, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "secondaryLayoutSettings"

    move-object/from16 v13, p5

    invoke-static {v13, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "effects"

    move-object/from16 v7, p7

    invoke-static {v7, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "useCases"

    invoke-static {v4, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 557
    const-string v6, "CX:bindToLifecycle-internal"

    .line 1017
    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->beginSection(Ljava/lang/String;)V

    .line 558
    :try_start_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 563
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v6

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v6}, Landroidx/camera/core/CameraX;->getCameraRepository()Landroidx/camera/core/impl/CameraRepository;

    move-result-object v6

    invoke-virtual {v6}, Landroidx/camera/core/impl/CameraRepository;->getCameras()Ljava/util/LinkedHashSet;

    move-result-object v6

    invoke-virtual {v2, v6}, Landroidx/camera/core/CameraSelector;->select(Ljava/util/LinkedHashSet;)Landroidx/camera/core/impl/CameraInternal;

    move-result-object v8

    const-string v6, "primaryCameraSelector.se\u2026cameraRepository.cameras)"

    invoke-static {v8, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v6, 0x1

    .line 564
    invoke-interface {v8, v6}, Landroidx/camera/core/impl/CameraInternal;->setPrimary(Z)V

    .line 566
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getCameraInfo(Landroidx/camera/core/CameraSelector;)Landroidx/camera/core/CameraInfo;

    move-result-object v2

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v10, v2

    check-cast v10, Landroidx/camera/core/impl/RestrictedCameraInfo;

    if-eqz v3, :cond_0

    .line 572
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v2}, Landroidx/camera/core/CameraX;->getCameraRepository()Landroidx/camera/core/impl/CameraRepository;

    move-result-object v2

    invoke-virtual {v2}, Landroidx/camera/core/impl/CameraRepository;->getCameras()Ljava/util/LinkedHashSet;

    move-result-object v2

    invoke-virtual {v3, v2}, Landroidx/camera/core/CameraSelector;->select(Ljava/util/LinkedHashSet;)Landroidx/camera/core/impl/CameraInternal;

    move-result-object v2

    const/4 v9, 0x0

    .line 573
    invoke-interface {v2, v9}, Landroidx/camera/core/impl/CameraInternal;->setPrimary(Z)V

    .line 575
    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getCameraInfo(Landroidx/camera/core/CameraSelector;)Landroidx/camera/core/CameraInfo;

    move-result-object v3

    invoke-static {v3, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v3, Landroidx/camera/core/impl/RestrictedCameraInfo;

    move-object v9, v2

    move-object v11, v3

    goto :goto_0

    :catchall_0
    move-exception v0

    goto/16 :goto_4

    :cond_0
    const/4 v2, 0x0

    move-object v9, v2

    move-object v11, v9

    .line 579
    :goto_0
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    move-result-object v2

    .line 581
    invoke-static {v10, v11}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;->generateCameraId(Landroidx/camera/core/impl/RestrictedCameraInfo;Landroidx/camera/core/impl/RestrictedCameraInfo;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;

    move-result-object v3

    .line 579
    invoke-virtual {v2, v0, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCamera(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    move-result-object v2

    .line 588
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    move-result-object v3

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->getLifecycleCameras()Ljava/util/Collection;

    move-result-object v3

    .line 589
    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->filterNotNull([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v5

    check-cast v5, Ljava/lang/Iterable;

    .line 1020
    invoke-interface {v5}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :goto_1
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v14

    if-eqz v14, :cond_4

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v14

    check-cast v14, Landroidx/camera/core/UseCase;

    .line 590
    invoke-interface {v3}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v15

    :goto_2
    invoke-interface {v15}, Ljava/util/Iterator;->hasNext()Z

    move-result v16

    if-eqz v16, :cond_3

    invoke-interface {v15}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v6

    const-string v1, "lifecycleCameras"

    invoke-static {v6, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v6, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    .line 592
    invoke-virtual {v6, v14}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;->isBound(Landroidx/camera/core/UseCase;)Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-static {v6, v2}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    :cond_1
    const/4 v6, 0x1

    move-object/from16 v1, p0

    goto :goto_2

    .line 594
    :cond_2
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 595
    sget-object v1, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    .line 596
    const-string v1, "Use case %s already bound to a different lifecycle."

    .line 597
    filled-new-array {v14}, [Ljava/lang/Object;

    move-result-object v2

    const/4 v6, 0x1

    .line 595
    invoke-static {v2, v6}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v2

    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "format(format, *args)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 594
    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_3
    move-object/from16 v1, p0

    goto :goto_1

    :cond_4
    if-nez v2, :cond_5

    .line 607
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    move-result-object v1

    .line 609
    new-instance v7, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;

    .line 616
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v2}, Landroidx/camera/core/CameraX;->getCameraFactory()Landroidx/camera/core/impl/CameraFactory;

    move-result-object v2

    invoke-interface {v2}, Landroidx/camera/core/impl/CameraFactory;->getCameraCoordinator()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    move-result-object v14

    .line 617
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v2}, Landroidx/camera/core/CameraX;->getCameraDeviceSurfaceManager()Landroidx/camera/core/impl/CameraDeviceSurfaceManager;

    move-result-object v15

    .line 618
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v2}, Landroidx/camera/core/CameraX;->getDefaultConfigFactory()Landroidx/camera/core/impl/UseCaseConfigFactory;

    move-result-object v16

    .line 609
    invoke-direct/range {v7 .. v16}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;-><init>(Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/RestrictedCameraInfo;Landroidx/camera/core/impl/RestrictedCameraInfo;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/LayoutSettings;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;Landroidx/camera/core/impl/CameraDeviceSurfaceManager;Landroidx/camera/core/impl/UseCaseConfigFactory;)V

    .line 607
    invoke-virtual {v1, v0, v7}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->createLifecycleCamera(Landroidx/lifecycle/LifecycleOwner;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;

    move-result-object v2

    :cond_5
    move-object v8, v2

    .line 623
    array-length v0, v4

    if-nez v0, :cond_6

    .line 624
    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    goto :goto_3

    .line 627
    :cond_6
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    move-result-object v7

    .line 628
    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 631
    array-length v0, v4

    invoke-static {v4, v0}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->listOf([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    move-object v11, v0

    check-cast v11, Ljava/util/Collection;

    .line 632
    invoke-static/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroidx/camera/core/CameraX;->getCameraFactory()Landroidx/camera/core/impl/CameraFactory;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/impl/CameraFactory;->getCameraCoordinator()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;

    move-result-object v12

    move-object/from16 v9, p6

    move-object/from16 v10, p7

    .line 627
    invoke-virtual/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->bindToLifecycleCamera(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCamera;Landroidx/camera/core/ViewPort;Ljava/util/List;Ljava/util/Collection;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 1022
    :goto_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    return-object v8

    :goto_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    throw v0
.end method

.method public getCameraInfo(Landroidx/camera/core/CameraSelector;)Landroidx/camera/core/CameraInfo;
    .locals 4

    const-string v0, "cameraSelector"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 761
    const-string v0, "CX:getCameraInfo"

    .line 1048
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->beginSection(Ljava/lang/String;)V

    .line 763
    :try_start_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Landroidx/camera/core/CameraX;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroidx/camera/core/CameraX;->getCameraRepository()Landroidx/camera/core/impl/CameraRepository;

    move-result-object v0

    invoke-virtual {v0}, Landroidx/camera/core/impl/CameraRepository;->getCameras()Ljava/util/LinkedHashSet;

    move-result-object v0

    invoke-virtual {p1, v0}, Landroidx/camera/core/CameraSelector;->select(Ljava/util/LinkedHashSet;)Landroidx/camera/core/impl/CameraInternal;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/impl/CameraInternal;->getCameraInfoInternal()Landroidx/camera/core/impl/CameraInfoInternal;

    move-result-object v0

    const-string v1, "cameraSelector.select(mC\u2026meras).cameraInfoInternal"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 764
    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getCameraConfig(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/impl/CameraConfig;

    move-result-object p1

    .line 768
    invoke-interface {v0}, Landroidx/camera/core/impl/CameraInfoInternal;->getCameraId()Ljava/lang/String;

    move-result-object v1

    .line 769
    invoke-interface {p1}, Landroidx/camera/core/impl/CameraConfig;->getCompatibilityId()Landroidx/camera/core/impl/Identifier;

    move-result-object v2

    .line 767
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;->create(Ljava/lang/String;Landroidx/camera/core/impl/Identifier;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/CameraUseCaseAdapter$CameraId;

    move-result-object v1

    const-string v2, "create(\n                \u2026ilityId\n                )"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 772
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLock$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Ljava/lang/Object;

    move-result-object v2

    monitor-enter v2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    .line 773
    :try_start_1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraInfoMap$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Ljava/util/Map;

    move-result-object v3

    invoke-interface {v3, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    if-nez v3, :cond_0

    .line 775
    new-instance v3, Landroidx/camera/core/impl/RestrictedCameraInfo;

    invoke-direct {v3, v0, p1}, Landroidx/camera/core/impl/RestrictedCameraInfo;-><init>(Landroidx/camera/core/impl/CameraInfoInternal;Landroidx/camera/core/impl/CameraConfig;)V

    .line 776
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMCameraInfoMap$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Ljava/util/Map;

    move-result-object p1

    invoke-interface {p1, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 778
    :cond_0
    :goto_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 772
    :try_start_2
    monitor-exit v2

    .line 780
    check-cast v3, Landroidx/camera/core/impl/RestrictedCameraInfo;
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    .line 1052
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    return-object v3

    :catchall_1
    move-exception p1

    goto :goto_2

    .line 772
    :goto_1
    :try_start_3
    monitor-exit v2

    throw p1
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_1

    .line 1052
    :goto_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    throw p1
.end method

.method public unbindAll()V
    .locals 1

    .line 679
    const-string v0, "CX:unbindAll"

    .line 1028
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->beginSection(Ljava/lang/String;)V

    .line 680
    :try_start_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    const/4 v0, 0x0

    .line 681
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$setCameraOperatingMode(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;I)V

    .line 682
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getMLifecycleCameraRepository$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/LifecycleCameraRepository;->unbindAll()V

    .line 683
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 1032
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    return-void

    :catchall_0
    move-exception v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/tracing/Trace;->endSection()V

    throw v0
.end method
