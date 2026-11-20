.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2Interop$Extender;
.super Ljava/lang/Object;
.source "Camera2Interop.java"


# instance fields
.field mBaseBuilder:Landroidx/camera/core/ExtendableBuilder;


# direct methods
.method public constructor <init>(Landroidx/camera/core/ExtendableBuilder;)V
    .locals 0

    .line 58
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 59
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2Interop$Extender;->mBaseBuilder:Landroidx/camera/core/ExtendableBuilder;

    return-void
.end method


# virtual methods
.method public setCaptureRequestOption(Landroid/hardware/camera2/CaptureRequest$Key;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2Interop$Extender;
    .locals 2

    .line 77
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/impl/Camera2ImplConfig;->createCaptureRequestOption(Landroid/hardware/camera2/CaptureRequest$Key;)Landroidx/camera/core/impl/Config$Option;

    move-result-object p1

    .line 78
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/Camera2Interop$Extender;->mBaseBuilder:Landroidx/camera/core/ExtendableBuilder;

    invoke-interface {v0}, Landroidx/camera/core/ExtendableBuilder;->getMutableConfig()Landroidx/camera/core/impl/MutableConfig;

    move-result-object v0

    sget-object v1, Landroidx/camera/core/impl/Config$OptionPriority;->ALWAYS_OVERRIDE:Landroidx/camera/core/impl/Config$OptionPriority;

    invoke-interface {v0, p1, v1, p2}, Landroidx/camera/core/impl/MutableConfig;->insertOption(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;Ljava/lang/Object;)V

    return-object p0
.end method
