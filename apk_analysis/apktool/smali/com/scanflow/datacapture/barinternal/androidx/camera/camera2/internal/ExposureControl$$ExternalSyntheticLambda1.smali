.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;

.field public final synthetic f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

.field public final synthetic f$2:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$2:I

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$1:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl$$ExternalSyntheticLambda1;->f$2:I

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;->$r8$lambda$1kxhfZr7gubJH_H2icbROHCkSvs(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ExposureControl;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;I)V

    return-void
.end method
