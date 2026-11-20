.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/compat/workaround/CaptureOutputSurfaceForCaptureProcessor$ImageWriterCompat;
.super Ljava/lang/Object;
.source "CaptureOutputSurfaceForCaptureProcessor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/compat/workaround/CaptureOutputSurfaceForCaptureProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "ImageWriterCompat"
.end annotation


# direct methods
.method static close(Landroid/media/ImageWriter;)V
    .locals 0

    .line 163
    invoke-virtual {p0}, Landroid/media/ImageWriter;->close()V

    return-void
.end method

.method static newInstance(Landroid/view/Surface;II)Landroid/media/ImageWriter;
    .locals 0

    .line 155
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/compat/workaround/CaptureOutputSurfaceForCaptureProcessor$ImageWriterCompat$$ExternalSyntheticApiModelOutline0;->m(Landroid/view/Surface;II)Landroid/media/ImageWriter;

    move-result-object p0

    return-object p0
.end method

.method static queueInputImage(Landroid/media/ImageWriter;Landroid/media/Image;)V
    .locals 0

    .line 159
    invoke-virtual {p0, p1}, Landroid/media/ImageWriter;->queueInputImage(Landroid/media/Image;)V

    return-void
.end method
