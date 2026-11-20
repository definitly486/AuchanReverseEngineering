.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;
.super Ljava/lang/Object;
.source "BitmapEffect.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;


# instance fields
.field private final mProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;)V
    .locals 0

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;->mProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    return-void
.end method


# virtual methods
.method public apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
    .locals 9

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;->mProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/ImageProcessorRequest;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/RgbaImageProxy;

    invoke-direct {v2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/RgbaImageProxy;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;)V

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/ImageProcessorRequest;-><init>(Landroidx/camera/core/ImageProxy;I)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->safeProcess(Landroidx/camera/core/ImageProcessor$Request;)Landroidx/camera/core/ImageProcessor$Response;

    move-result-object v0

    .line 58
    invoke-interface {v0}, Landroidx/camera/core/ImageProcessor$Response;->getOutputImage()Landroidx/camera/core/ImageProxy;

    move-result-object v0

    .line 60
    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-object v1, v0

    check-cast v1, Landroidx/camera/core/ImageProxy;

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getPlanes()[Landroidx/camera/core/ImageProxy$PlaneProxy;

    move-result-object v1

    .line 61
    invoke-interface {v0}, Landroidx/camera/core/ImageProxy;->getWidth()I

    move-result v2

    .line 62
    invoke-interface {v0}, Landroidx/camera/core/ImageProxy;->getHeight()I

    move-result v0

    .line 59
    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil;->createBitmapFromPlane([Landroidx/camera/core/ImageProxy$PlaneProxy;II)Landroid/graphics/Bitmap;

    move-result-object v3

    .line 65
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getExif()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;

    move-result-object v4

    invoke-static {v4}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 66
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCropRect()Landroid/graphics/Rect;

    move-result-object v5

    .line 67
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getRotationDegrees()I

    move-result v6

    .line 68
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getSensorToBufferTransform()Landroid/graphics/Matrix;

    move-result-object v7

    .line 69
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getCameraCaptureResult()Landroidx/camera/core/impl/CameraCaptureResult;

    move-result-object v8

    .line 63
    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->of(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Exif;Landroid/graphics/Rect;ILandroid/graphics/Matrix;Landroidx/camera/core/impl/CameraCaptureResult;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 41
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;->apply(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    return-object p1
.end method
