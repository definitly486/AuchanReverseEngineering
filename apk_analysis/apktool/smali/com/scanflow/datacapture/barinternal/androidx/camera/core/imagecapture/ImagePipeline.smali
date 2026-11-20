.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;
.super Ljava/lang/Object;
.source "ImagePipeline.java"


# static fields
.field static final EXIF_ROTATION_AVAILABILITY:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;

.field private static sNextRequestId:I


# instance fields
.field private final mCaptureConfig:Landroidx/camera/core/impl/CaptureConfig;

.field private final mCaptureNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

.field private final mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

.field private final mProcessingNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

.field private final mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 68
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->EXIF_ROTATION_AVAILABILITY:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;

    return-void
.end method

.method public constructor <init>(Landroidx/camera/core/impl/ImageCaptureConfig;Landroid/util/Size;Landroidx/camera/core/CameraEffect;ZLandroid/util/Size;I)V
    .locals 11

    .line 112
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 113
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 114
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;

    .line 115
    invoke-static {p1}, Landroidx/camera/core/impl/CaptureConfig$Builder;->createFrom(Landroidx/camera/core/impl/UseCaseConfig;)Landroidx/camera/core/impl/CaptureConfig$Builder;

    move-result-object v0

    invoke-virtual {v0}, Landroidx/camera/core/impl/CaptureConfig$Builder;->build()Landroidx/camera/core/impl/CaptureConfig;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureConfig:Landroidx/camera/core/impl/CaptureConfig;

    .line 118
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    .line 119
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

    .line 120
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->ioExecutor()Ljava/util/concurrent/Executor;

    move-result-object v2

    invoke-virtual {p1, v2}, Landroidx/camera/core/impl/ImageCaptureConfig;->getIoExecutor(Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Executor;

    move-result-object v2

    invoke-static {v2}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v2, Ljava/util/concurrent/Executor;

    if-eqz p3, :cond_0

    .line 121
    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    invoke-direct {v3, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;-><init>(Landroidx/camera/core/CameraEffect;)V

    goto :goto_0

    :cond_0
    const/4 v3, 0x0

    :goto_0
    invoke-direct {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;-><init>(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mProcessingNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

    .line 126
    invoke-virtual {p1}, Landroidx/camera/core/impl/ImageCaptureConfig;->getInputFormat()I

    move-result v5

    .line 127
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->getOutputFormat()I

    move-result v6

    .line 129
    invoke-virtual {p1}, Landroidx/camera/core/impl/ImageCaptureConfig;->getImageReaderProxyProvider()Landroidx/camera/core/ImageReaderProxyProvider;

    move-result-object v8

    move-object v4, p2

    move v7, p4

    move-object/from16 v9, p5

    move/from16 v10, p6

    .line 124
    invoke-static/range {v4 .. v10}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->of(Landroid/util/Size;IIZLandroidx/camera/core/ImageReaderProxyProvider;Landroid/util/Size;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    .line 132
    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->transform(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

    move-result-object p1

    .line 133
    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->transform(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;)Ljava/lang/Void;

    return-void
.end method

.method private createCameraRequest(ILandroidx/camera/core/impl/CaptureBundle;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;
    .locals 6

    .line 293
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 294
    invoke-virtual {p2}, Ljava/lang/Object;->hashCode()I

    move-result v1

    invoke-static {v1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    .line 295
    invoke-interface {p2}, Landroidx/camera/core/impl/CaptureBundle;->getCaptureStages()Ljava/util/List;

    move-result-object p2

    invoke-static {p2}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast p2, Ljava/util/List;

    invoke-interface {p2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p2

    :goto_0
    invoke-interface {p2}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-interface {p2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroidx/camera/core/impl/CaptureStage;

    .line 296
    new-instance v3, Landroidx/camera/core/impl/CaptureConfig$Builder;

    invoke-direct {v3}, Landroidx/camera/core/impl/CaptureConfig$Builder;-><init>()V

    .line 297
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureConfig:Landroidx/camera/core/impl/CaptureConfig;

    invoke-virtual {v4}, Landroidx/camera/core/impl/CaptureConfig;->getTemplateType()I

    move-result v4

    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->setTemplateType(I)V

    .line 300
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureConfig:Landroidx/camera/core/impl/CaptureConfig;

    invoke-virtual {v4}, Landroidx/camera/core/impl/CaptureConfig;->getImplementationOptions()Landroidx/camera/core/impl/Config;

    move-result-object v4

    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addImplementationOptions(Landroidx/camera/core/impl/Config;)V

    .line 302
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getSessionConfigCameraCaptureCallbacks()Ljava/util/List;

    move-result-object v4

    .line 301
    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addAllCameraCaptureCallbacks(Ljava/util/Collection;)V

    .line 303
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getSurface()Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v4

    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addSurface(Landroidx/camera/core/impl/DeferrableSurface;)V

    .line 304
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->shouldEnablePostview()Z

    move-result v4

    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->setPostviewEnabled(Z)V

    .line 308
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getInputFormat()I

    move-result v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil;->isJpegFormats(I)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 309
    sget-object v4, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->EXIF_ROTATION_AVAILABILITY:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/compat/workaround/ExifRotationAvailability;->isRotationOptionSupported()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 310
    sget-object v4, Landroidx/camera/core/impl/CaptureConfig;->OPTION_ROTATION:Landroidx/camera/core/impl/Config$Option;

    .line 311
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getRotationDegrees()I

    move-result v5

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    .line 310
    invoke-virtual {v3, v4, v5}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addImplementationOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V

    .line 313
    :cond_0
    sget-object v4, Landroidx/camera/core/impl/CaptureConfig;->OPTION_JPEG_QUALITY:Landroidx/camera/core/impl/Config$Option;

    .line 314
    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->getCameraRequestJpegQuality(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;)I

    move-result v5

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    .line 313
    invoke-virtual {v3, v4, v5}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addImplementationOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V

    .line 319
    :cond_1
    invoke-interface {v2}, Landroidx/camera/core/impl/CaptureStage;->getCaptureConfig()Landroidx/camera/core/impl/CaptureConfig;

    move-result-object v4

    invoke-virtual {v4}, Landroidx/camera/core/impl/CaptureConfig;->getImplementationOptions()Landroidx/camera/core/impl/Config;

    move-result-object v4

    .line 318
    invoke-virtual {v3, v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addImplementationOptions(Landroidx/camera/core/impl/Config;)V

    .line 322
    invoke-interface {v2}, Landroidx/camera/core/impl/CaptureStage;->getId()I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v3, v1, v2}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addTag(Ljava/lang/String;Ljava/lang/Object;)V

    .line 323
    invoke-virtual {v3, p1}, Landroidx/camera/core/impl/CaptureConfig$Builder;->setId(I)V

    .line 324
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getCameraCaptureCallback()Landroidx/camera/core/impl/CameraCaptureCallback;

    move-result-object v2

    invoke-virtual {v3, v2}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addCameraCaptureCallback(Landroidx/camera/core/impl/CameraCaptureCallback;)V

    .line 325
    invoke-virtual {v3}, Landroidx/camera/core/impl/CaptureConfig$Builder;->build()Landroidx/camera/core/impl/CaptureConfig;

    move-result-object v2

    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto/16 :goto_0

    .line 328
    :cond_2
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;

    invoke-direct {p1, v0, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;-><init>(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;)V

    return-object p1
.end method

.method private createCaptureBundle()Landroidx/camera/core/impl/CaptureBundle;
    .locals 2

    .line 256
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;

    invoke-static {}, Landroidx/camera/core/CaptureBundles;->singleDefaultCaptureBundle()Landroidx/camera/core/impl/CaptureBundle;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroidx/camera/core/impl/ImageCaptureConfig;->getCaptureBundle(Landroidx/camera/core/impl/CaptureBundle;)Landroidx/camera/core/impl/CaptureBundle;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v0, Landroidx/camera/core/impl/CaptureBundle;

    return-object v0
.end method

.method private createProcessingRequest(ILandroidx/camera/core/impl/CaptureBundle;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;Lcom/google/common/util/concurrent/ListenableFuture;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;
    .locals 10

    .line 266
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    .line 268
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getOutputFileOptions()Landroidx/camera/core/ImageCapture$OutputFileOptions;

    move-result-object v2

    .line 269
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getCropRect()Landroid/graphics/Rect;

    move-result-object v3

    .line 270
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getRotationDegrees()I

    move-result v4

    .line 271
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getJpegQuality()I

    move-result v5

    .line 272
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getSensorToBufferTransform()Landroid/graphics/Matrix;

    move-result-object v6

    move v9, p1

    move-object v1, p2

    move-object v7, p4

    move-object v8, p5

    invoke-direct/range {v0 .. v9}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;-><init>(Landroidx/camera/core/impl/CaptureBundle;Landroidx/camera/core/ImageCapture$OutputFileOptions;Landroid/graphics/Rect;IILandroid/graphics/Matrix;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;Lcom/google/common/util/concurrent/ListenableFuture;I)V

    return-object v0
.end method

.method private getOutputFormat()I
    .locals 3

    .line 239
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;

    sget-object v1, Landroidx/camera/core/impl/ImageCaptureConfig;->OPTION_BUFFER_FORMAT:Landroidx/camera/core/impl/Config$Option;

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroidx/camera/core/impl/ReadableConfig;->retrieveOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    if-eqz v0, :cond_0

    .line 242
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    return v0

    .line 245
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;

    sget-object v1, Landroidx/camera/core/impl/ImageInputConfig;->OPTION_INPUT_FORMAT:Landroidx/camera/core/impl/Config$Option;

    invoke-interface {v0, v1, v2}, Landroidx/camera/core/impl/ReadableConfig;->retrieveOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    if-eqz v0, :cond_1

    .line 246
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    const/16 v1, 0x1005

    if-ne v0, v1, :cond_1

    return v1

    :cond_1
    const/16 v0, 0x100

    return v0
.end method

.method private shouldEnablePostview()Z
    .locals 1

    .line 279
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getPostviewSurface()Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method


# virtual methods
.method public close()V
    .locals 1

    .line 160
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 161
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->release()V

    .line 162
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mProcessingNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->release()V

    return-void
.end method

.method createRequests(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;Lcom/google/common/util/concurrent/ListenableFuture;)Landroidx/core/util/Pair;
    .locals 8

    .line 205
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 206
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->createCaptureBundle()Landroidx/camera/core/impl/CaptureBundle;

    move-result-object v2

    .line 209
    sget v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->sNextRequestId:I

    add-int/lit8 v0, v1, 0x1

    sput v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->sNextRequestId:I

    .line 210
    new-instance v6, Landroidx/core/util/Pair;

    .line 211
    invoke-direct {p0, v1, v2, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->createCameraRequest(ILandroidx/camera/core/impl/CaptureBundle;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraRequest;

    move-result-object v7

    move-object v0, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    .line 216
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->createProcessingRequest(ILandroidx/camera/core/impl/CaptureBundle;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureCallback;Lcom/google/common/util/concurrent/ListenableFuture;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object p1

    invoke-direct {v6, v7, p1}, Landroidx/core/util/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    return-object v6
.end method

.method public createSessionConfigBuilder(Landroid/util/Size;)Landroidx/camera/core/impl/SessionConfig$Builder;
    .locals 1

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mUseCaseConfig:Landroidx/camera/core/impl/ImageCaptureConfig;

    invoke-static {v0, p1}, Landroidx/camera/core/impl/SessionConfig$Builder;->createFrom(Landroidx/camera/core/impl/UseCaseConfig;Landroid/util/Size;)Landroidx/camera/core/impl/SessionConfig$Builder;

    move-result-object p1

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getSurface()Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v0

    invoke-virtual {p1, v0}, Landroidx/camera/core/impl/SessionConfig$Builder;->addNonRepeatingSurface(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;

    .line 146
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getPostviewSurface()Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getPostviewSurface()Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v0

    invoke-virtual {p1, v0}, Landroidx/camera/core/impl/SessionConfig$Builder;->setPostviewSurface(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;

    :cond_0
    return-object p1
.end method

.method getCameraRequestJpegQuality(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;)I
    .locals 3

    .line 340
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getOnDiskCallback()Landroidx/camera/core/ImageCapture$OnImageSavedCallback;

    move-result-object v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 341
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getCropRect()Landroid/graphics/Rect;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getSize()Landroid/util/Size;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/TransformUtils;->hasCropping(Landroid/graphics/Rect;Landroid/util/Size;)Z

    move-result v1

    if-eqz v0, :cond_2

    if-eqz v1, :cond_2

    .line 346
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getCaptureMode()I

    move-result p1

    if-nez p1, :cond_1

    const/16 p1, 0x64

    return p1

    :cond_1
    const/16 p1, 0x5f

    return p1

    .line 354
    :cond_2
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureRequest;->getJpegQuality()I

    move-result p1

    return p1
.end method

.method public getCapacity()I
    .locals 1

    .line 170
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 171
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->getCapacity()I

    move-result v0

    return v0
.end method

.method notifyCaptureError(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager$CaptureError;)V
    .locals 1

    .line 232
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 233
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getErrorEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;->accept(Ljava/lang/Object;)V

    return-void
.end method

.method public setOnImageCloseListener(Landroidx/camera/core/ForwardingImageProxy$OnImageCloseListener;)V
    .locals 1

    .line 182
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 183
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mCaptureNode:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->setOnImageCloseListener(Landroidx/camera/core/ForwardingImageProxy$OnImageCloseListener;)V

    return-void
.end method

.method submitProcessingRequest(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;)V
    .locals 1

    .line 226
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->checkMainThread()V

    .line 227
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ImagePipeline;->mPipelineIn:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;->getRequestEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;->accept(Ljava/lang/Object;)V

    return-void
.end method
