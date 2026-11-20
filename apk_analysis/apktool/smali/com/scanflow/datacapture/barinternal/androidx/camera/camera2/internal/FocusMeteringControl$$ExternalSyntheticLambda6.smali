.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$CaptureResultListener;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

.field public final synthetic f$1:J

.field public final synthetic f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;JLandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$1:J

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    return-void
.end method


# virtual methods
.method public final onCaptureResult(Landroid/hardware/camera2/TotalCaptureResult;)Z
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$1:J

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda6;->f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;->$r8$lambda$chXyI9hdT5VG4Uqtm9gBWdNiuIk(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;JLandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Landroid/hardware/camera2/TotalCaptureResult;)Z

    move-result p1

    return p1
.end method
