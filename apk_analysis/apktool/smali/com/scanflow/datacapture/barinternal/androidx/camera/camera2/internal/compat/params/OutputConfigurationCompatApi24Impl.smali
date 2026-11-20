.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi24Impl;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;
.source "OutputConfigurationCompatApi24Impl.java"


# direct methods
.method constructor <init>(Ljava/lang/Object;)V
    .locals 0

    .line 48
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;-><init>(Ljava/lang/Object;)V

    return-void
.end method


# virtual methods
.method public abstract getOutputConfiguration()Ljava/lang/Object;
.end method

.method public getSurface()Landroid/view/Surface;
    .locals 1

    .line 98
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi24Impl;->getOutputConfiguration()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/hardware/camera2/params/OutputConfiguration;

    invoke-virtual {v0}, Landroid/hardware/camera2/params/OutputConfiguration;->getSurface()Landroid/view/Surface;

    move-result-object v0

    return-object v0
.end method
