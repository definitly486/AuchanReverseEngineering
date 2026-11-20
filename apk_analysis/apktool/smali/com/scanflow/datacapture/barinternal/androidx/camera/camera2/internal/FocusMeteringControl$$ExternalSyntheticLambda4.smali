.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

.field public final synthetic f$1:Z

.field public final synthetic f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;ZLandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$1:Z

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$1:Z

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda4;->f$2:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;->$r8$lambda$4cH9ZjwWsuf0reG0-bUbrN88Oas(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;ZLandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    return-void
.end method
