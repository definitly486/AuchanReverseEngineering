.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;
.super Ljava/lang/Object;
.source "OutputConfigurationCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;
    }
.end annotation


# instance fields
.field private final mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;


# direct methods
.method public constructor <init>(ILandroid/view/Surface;)V
    .locals 2

    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 62
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x21

    if-lt v0, v1, :cond_0

    .line 63
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi33Impl;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi33Impl;-><init>(ILandroid/view/Surface;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    return-void

    :cond_0
    const/16 v1, 0x1c

    if-lt v0, v1, :cond_1

    .line 65
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi28Impl;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi28Impl;-><init>(ILandroid/view/Surface;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    return-void

    .line 67
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi26Impl;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi26Impl;-><init>(ILandroid/view/Surface;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    return-void
.end method

.method private constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;)V
    .locals 0

    .line 118
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 119
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    return-void
.end method

.method public static wrap(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;
    .locals 3

    const/4 v0, 0x0

    if-nez p0, :cond_0

    return-object v0

    .line 140
    :cond_0
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x21

    if-lt v1, v2, :cond_1

    .line 141
    check-cast p0, Landroid/hardware/camera2/params/OutputConfiguration;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi33Impl;->wrap(Landroid/hardware/camera2/params/OutputConfiguration;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi33Impl;

    move-result-object p0

    goto :goto_0

    :cond_1
    const/16 v2, 0x1c

    if-lt v1, v2, :cond_2

    .line 144
    check-cast p0, Landroid/hardware/camera2/params/OutputConfiguration;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi28Impl;->wrap(Landroid/hardware/camera2/params/OutputConfiguration;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi28Impl;

    move-result-object p0

    goto :goto_0

    .line 147
    :cond_2
    check-cast p0, Landroid/hardware/camera2/params/OutputConfiguration;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi26Impl;->wrap(Landroid/hardware/camera2/params/OutputConfiguration;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatApi26Impl;

    move-result-object p0

    :goto_0
    if-nez p0, :cond_3

    return-object v0

    .line 158
    :cond_3
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;)V

    return-object v0
.end method


# virtual methods
.method public addSurface(Landroid/view/Surface;)V
    .locals 1

    .line 302
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->addSurface(Landroid/view/Surface;)V

    return-void
.end method

.method public enableSurfaceSharing()V
    .locals 1

    .line 198
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->enableSurfaceSharing()V

    return-void
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 1

    .line 477
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 481
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-virtual {v0, p1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public getPhysicalCameraId()Ljava/lang/String;
    .locals 1

    .line 226
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->getPhysicalCameraId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getSurface()Landroid/view/Surface;
    .locals 1

    .line 342
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->getSurface()Landroid/view/Surface;

    move-result-object v0

    return-object v0
.end method

.method public hashCode()I
    .locals 1

    .line 489
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    return v0
.end method

.method public setDynamicRangeProfile(J)V
    .locals 1

    .line 412
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->setDynamicRangeProfile(J)V

    return-void
.end method

.method public setMirrorMode(I)V
    .locals 1

    .line 216
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->setMirrorMode(I)V

    return-void
.end method

.method public setPhysicalCameraId(Ljava/lang/String;)V
    .locals 1

    .line 257
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->setPhysicalCameraId(Ljava/lang/String;)V

    return-void
.end method

.method public setStreamUseCase(J)V
    .locals 1

    .line 451
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->setStreamUseCase(J)V

    return-void
.end method

.method public unwrap()Ljava/lang/Object;
    .locals 1

    .line 502
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;->getOutputConfiguration()Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method
