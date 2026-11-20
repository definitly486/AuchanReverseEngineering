.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask$$ExternalSyntheticLambda7;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/arch/core/util/Function;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    check-cast p1, Landroid/hardware/camera2/TotalCaptureResult;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;->$r8$lambda$DyNrjGgA4DpO9jlmQryAeAiU9PM(Landroid/hardware/camera2/TotalCaptureResult;)Ljava/lang/Boolean;

    move-result-object p1

    return-object p1
.end method
