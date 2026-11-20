.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;
.super Ljava/lang/Object;
.source "Camera2DeviceSurfaceManager.java"

# interfaces
.implements Landroidx/camera/core/impl/CameraDeviceSurfaceManager;


# instance fields
.field private final mCamcorderProfileHelper:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;

.field private final mCameraSupportedSurfaceCombinationMap:Ljava/util/Map;


# direct methods
.method constructor <init>(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;Ljava/lang/Object;Ljava/util/Set;)V
    .locals 1

    .line 85
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 56
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCameraSupportedSurfaceCombinationMap:Ljava/util/Map;

    .line 86
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 87
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCamcorderProfileHelper:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;

    .line 90
    instance-of p2, p3, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    if-eqz p2, :cond_0

    .line 91
    check-cast p3, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    goto :goto_0

    .line 93
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;->from(Landroid/content/Context;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;

    move-result-object p3

    .line 95
    :goto_0
    invoke-direct {p0, p1, p3, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->init(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/util/Set;)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Ljava/lang/Object;Ljava/util/Set;)V
    .locals 1

    .line 67
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager$1;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager$1;-><init>()V

    invoke-direct {p0, p1, v0, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;-><init>(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;Ljava/lang/Object;Ljava/util/Set;)V

    return-void
.end method

.method private init(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/util/Set;)V
    .locals 4

    .line 104
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 106
    invoke-interface {p3}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p3

    :goto_0
    invoke-interface {p3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {p3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 107
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCameraSupportedSurfaceCombinationMap:Ljava/util/Map;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCamcorderProfileHelper:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;

    invoke-direct {v2, p1, v0, p2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;-><init>(Landroid/content/Context;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;)V

    invoke-interface {v1, v0, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :cond_0
    return-void
.end method


# virtual methods
.method public getSuggestedStreamSpecs(ILjava/lang/String;Ljava/util/List;Ljava/util/Map;ZZ)Landroid/util/Pair;
    .locals 7

    .line 177
    invoke-interface {p4}, Ljava/util/Map;->isEmpty()Z

    move-result v0

    xor-int/lit8 v0, v0, 0x1

    const-string v1, "No new use cases to be bound."

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 180
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCameraSupportedSurfaceCombinationMap:Ljava/util/Map;

    .line 181
    invoke-interface {v0, p2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;

    if-eqz v1, :cond_0

    move v2, p1

    move-object v3, p3

    move-object v4, p4

    move v5, p5

    move v6, p6

    .line 188
    invoke-virtual/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;->getSuggestedStreamSpecifications(ILjava/util/List;Ljava/util/Map;ZZ)Landroid/util/Pair;

    move-result-object p1

    return-object p1

    .line 184
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string p4, "No such camera id in supported combination list: "

    invoke-virtual {p3, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public transformSurfaceConfig(ILjava/lang/String;ILandroid/util/Size;)Landroidx/camera/core/impl/SurfaceConfig;
    .locals 1

    .line 131
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2DeviceSurfaceManager;->mCameraSupportedSurfaceCombinationMap:Ljava/util/Map;

    .line 132
    invoke-interface {v0, p2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;

    if-eqz p2, :cond_0

    .line 137
    invoke-virtual {p2, p1, p3, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SupportedSurfaceCombination;->transformSurfaceConfig(IILandroid/util/Size;)Landroidx/camera/core/impl/SurfaceConfig;

    move-result-object p1

    return-object p1

    :cond_0
    const/4 p1, 0x0

    return-object p1
.end method
