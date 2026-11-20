.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda9;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

.field public final synthetic f$1:J


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;J)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda9;->f$1:J

    return-void
.end method


# virtual methods
.method public final attachCompleter(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$$ExternalSyntheticLambda9;->f$1:J

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->$r8$lambda$_I05frK_VXCHVufpVYy7l10H-b8(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;JLandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
