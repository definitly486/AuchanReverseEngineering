.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$CaptureResultListener;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

.field public final synthetic f$1:I

.field public final synthetic f$2:J


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;IJ)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$1:I

    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$2:J

    return-void
.end method


# virtual methods
.method public final onCaptureResult(Landroid/hardware/camera2/TotalCaptureResult;)Z
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$1:I

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda11;->f$2:J

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;->$r8$lambda$4DT1TcdBY8lgZyOrQIRKV9jYFi8(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;IJLandroid/hardware/camera2/TotalCaptureResult;)Z

    move-result p1

    return p1
.end method
