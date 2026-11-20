.class Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes;
.super Ljava/lang/Object;
.source "Bitmap2JpegBytes.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$Api34Impl;
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getOutputFormat(Landroid/graphics/Bitmap;)I
    .locals 2

    .line 60
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x22

    if-lt v0, v1, :cond_0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$Api34Impl;->hasGainmap(Landroid/graphics/Bitmap;)Z

    move-result p0

    if-eqz p0, :cond_0

    const/16 p0, 0x1005

    return p0

    :cond_0
    const/16 p0, 0x100

    return p0
.end method


# virtual methods
.method public apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
    .locals 12

    .line 45
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;->getPacket()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object v0

    .line 46
    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 47
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getData()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/graphics/Bitmap;

    sget-object v3, Landroid/graphics/Bitmap$CompressFormat;->JPEG:Landroid/graphics/Bitmap$CompressFormat;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;->getJpegQuality()I

    move-result p1

    invoke-virtual {v2, v3, p1, v1}, Landroid/graphics/Bitmap;->compress(Landroid/graphics/Bitmap$CompressFormat;ILjava/io/OutputStream;)Z

    .line 49
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v4

    .line 50
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getExif()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;

    move-result-object v5

    invoke-static {v5}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 51
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getData()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/graphics/Bitmap;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes;->getOutputFormat(Landroid/graphics/Bitmap;)I

    move-result v6

    .line 52
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSize()Landroid/util/Size;

    move-result-object v7

    .line 53
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCropRect()Landroid/graphics/Rect;

    move-result-object v8

    .line 54
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getRotationDegrees()I

    move-result v9

    .line 55
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSensorToBufferTransform()Landroid/graphics/Matrix;

    move-result-object v10

    .line 56
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCameraCaptureResult()Landroidx/camera/core/impl/CameraCaptureResult;

    move-result-object v11

    .line 49
    invoke-static/range {v4 .. v11}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->of([BLcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;ILandroid/util/Size;Landroid/graphics/Rect;ILandroid/graphics/Matrix;Landroidx/camera/core/impl/CameraCaptureResult;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 40
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes;->apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method
