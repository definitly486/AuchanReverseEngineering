.class public abstract Landroidx/camera/core/CaptureBundles;
.super Ljava/lang/Object;
.source "CaptureBundles.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/camera/core/CaptureBundles$CaptureBundleImpl;
    }
.end annotation


# direct methods
.method static varargs createCaptureBundle([Landroidx/camera/core/impl/CaptureStage;)Landroidx/camera/core/impl/CaptureBundle;
    .locals 1

    .line 44
    new-instance v0, Landroidx/camera/core/CaptureBundles$CaptureBundleImpl;

    invoke-static {p0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object p0

    invoke-direct {v0, p0}, Landroidx/camera/core/CaptureBundles$CaptureBundleImpl;-><init>(Ljava/util/List;)V

    return-object v0
.end method

.method public static singleDefaultCaptureBundle()Landroidx/camera/core/impl/CaptureBundle;
    .locals 3

    .line 38
    new-instance v0, Landroidx/camera/core/impl/CaptureStage$DefaultCaptureStage;

    invoke-direct {v0}, Landroidx/camera/core/impl/CaptureStage$DefaultCaptureStage;-><init>()V

    const/4 v1, 0x1

    new-array v1, v1, [Landroidx/camera/core/impl/CaptureStage;

    const/4 v2, 0x0

    aput-object v0, v1, v2

    invoke-static {v1}, Landroidx/camera/core/CaptureBundles;->createCaptureBundle([Landroidx/camera/core/impl/CaptureStage;)Landroidx/camera/core/impl/CaptureBundle;

    move-result-object v0

    return-object v0
.end method
