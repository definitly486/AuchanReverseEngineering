.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

.field public final synthetic f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

.field public final synthetic f$2:Landroidx/camera/core/FocusMeteringAction;

.field public final synthetic f$3:J


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Landroidx/camera/core/FocusMeteringAction;J)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$2:Landroidx/camera/core/FocusMeteringAction;

    iput-wide p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$3:J

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 5

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$2:Landroidx/camera/core/FocusMeteringAction;

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl$$ExternalSyntheticLambda10;->f$3:J

    invoke-static {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;->$r8$lambda$yBIpBep9f__pcRaEB02CRv6WwvA(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/FocusMeteringControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Landroidx/camera/core/FocusMeteringAction;J)V

    return-void
.end method
