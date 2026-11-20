.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/ImageWriterCompatApi23Impl;
.super Ljava/lang/Object;
.source "ImageWriterCompatApi23Impl.java"


# direct methods
.method static close(Landroid/media/ImageWriter;)V
    .locals 0

    .line 45
    invoke-virtual {p0}, Landroid/media/ImageWriter;->close()V

    return-void
.end method

.method static dequeueInputImage(Landroid/media/ImageWriter;)Landroid/media/Image;
    .locals 0

    .line 37
    invoke-virtual {p0}, Landroid/media/ImageWriter;->dequeueInputImage()Landroid/media/Image;

    move-result-object p0

    return-object p0
.end method

.method static newInstance(Landroid/view/Surface;I)Landroid/media/ImageWriter;
    .locals 0

    .line 32
    invoke-static {p0, p1}, Landroid/media/ImageWriter;->newInstance(Landroid/view/Surface;I)Landroid/media/ImageWriter;

    move-result-object p0

    return-object p0
.end method

.method static queueInputImage(Landroid/media/ImageWriter;Landroid/media/Image;)V
    .locals 0

    .line 41
    invoke-virtual {p0, p1}, Landroid/media/ImageWriter;->queueInputImage(Landroid/media/Image;)V

    return-void
.end method
