.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/compat/workaround/CaptureOutputSurfaceForCaptureProcessor$Api23Impl;
.super Ljava/lang/Object;
.source "CaptureOutputSurfaceForCaptureProcessor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/compat/workaround/CaptureOutputSurfaceForCaptureProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Api23Impl"
.end annotation


# direct methods
.method static setImageTimestamp(Landroid/media/Image;J)V
    .locals 0

    .line 172
    invoke-virtual {p0, p1, p2}, Landroid/media/Image;->setTimestamp(J)V

    return-void
.end method
