.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;

.field public final synthetic f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

.field public final synthetic f$2:Z


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Z)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$2:Z

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl$$ExternalSyntheticLambda2;->f$2:Z

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;->$r8$lambda$UNcpYPqGISP5w9YIuaKM5em0Ivs(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/TorchControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Z)V

    return-void
.end method
