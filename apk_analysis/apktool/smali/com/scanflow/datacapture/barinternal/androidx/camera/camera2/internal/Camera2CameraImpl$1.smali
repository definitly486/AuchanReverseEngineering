.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$1;
.super Ljava/lang/Object;
.source "Camera2CameraImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CamcorderProfileHelper;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;-><init>(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;Landroidx/camera/core/impl/CameraStateRegistry;Ljava/util/concurrent/Executor;Landroid/os/Handler;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/DisplayInfoManager;J)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;)V
    .locals 0

    .line 301
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public get(II)Landroid/media/CamcorderProfile;
    .locals 0

    .line 310
    invoke-static {p1, p2}, Landroid/media/CamcorderProfile;->get(II)Landroid/media/CamcorderProfile;

    move-result-object p1

    return-object p1
.end method

.method public hasProfile(II)Z
    .locals 0

    .line 304
    invoke-static {p1, p2}, Landroid/media/CamcorderProfile;->hasProfile(II)Z

    move-result p1

    return p1
.end method
