.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/google/common/util/concurrent/ListenableFuture;


# direct methods
.method public synthetic constructor <init>(Lcom/google/common/util/concurrent/ListenableFuture;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda0;->f$0:Lcom/google/common/util/concurrent/ListenableFuture;

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda0;->f$0:Lcom/google/common/util/concurrent/ListenableFuture;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraCapturePipeline;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;->$r8$lambda$xK7J_OPoPIl8bofTcVKoHRGf_nM(Lcom/google/common/util/concurrent/ListenableFuture;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraCapturePipeline;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
