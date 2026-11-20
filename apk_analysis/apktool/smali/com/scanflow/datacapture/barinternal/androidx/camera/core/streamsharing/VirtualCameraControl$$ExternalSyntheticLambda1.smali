.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;

.field public final synthetic f$1:Ljava/util/List;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;Ljava/util/List;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda1;->f$1:Ljava/util/List;

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl$$ExternalSyntheticLambda1;->f$1:Ljava/util/List;

    check-cast p1, Ljava/lang/Void;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;->$r8$lambda$Nm9dM2EEwl4-VRptNjmesFJQKy4(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/streamsharing/VirtualCameraControl;Ljava/util/List;Ljava/lang/Void;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
