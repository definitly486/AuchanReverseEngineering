.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Image;
.super Ljava/lang/Object;
.source "JpegBytes2Image.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
    .locals 8

    .line 45
    new-instance v0, Landroidx/camera/core/SafeCloseImageReaderProxy;

    .line 47
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSize()Landroid/util/Size;

    move-result-object v1

    invoke-virtual {v1}, Landroid/util/Size;->getWidth()I

    move-result v1

    .line 48
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSize()Landroid/util/Size;

    move-result-object v2

    invoke-virtual {v2}, Landroid/util/Size;->getHeight()I

    move-result v2

    const/16 v3, 0x100

    const/4 v4, 0x2

    .line 46
    invoke-static {v1, v2, v3, v4}, Landroidx/camera/core/ImageReaderProxys;->createIsolatedReader(IIII)Landroidx/camera/core/impl/ImageReaderProxy;

    move-result-object v1

    invoke-direct {v0, v1}, Landroidx/camera/core/SafeCloseImageReaderProxy;-><init>(Landroidx/camera/core/impl/ImageReaderProxy;)V

    .line 51
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getData()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, [B

    invoke-static {v0, v1}, Landroidx/camera/core/ImageProcessingUtil;->convertJpegBytesToImage(Landroidx/camera/core/impl/ImageReaderProxy;[B)Landroidx/camera/core/ImageProxy;

    move-result-object v1

    .line 52
    invoke-virtual {v0}, Landroidx/camera/core/SafeCloseImageReaderProxy;->safeClose()V

    .line 54
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-object v2, v1

    check-cast v2, Landroidx/camera/core/ImageProxy;

    .line 55
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getExif()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;

    move-result-object v3

    invoke-static {v3}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 56
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCropRect()Landroid/graphics/Rect;

    move-result-object v4

    .line 57
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getRotationDegrees()I

    move-result v5

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSensorToBufferTransform()Landroid/graphics/Matrix;

    move-result-object v6

    .line 58
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCameraCaptureResult()Landroidx/camera/core/impl/CameraCaptureResult;

    move-result-object v7

    .line 53
    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->of(Landroidx/camera/core/ImageProxy;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;Landroid/graphics/Rect;ILandroid/graphics/Matrix;Landroidx/camera/core/impl/CameraCaptureResult;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 36
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Image;->apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method
