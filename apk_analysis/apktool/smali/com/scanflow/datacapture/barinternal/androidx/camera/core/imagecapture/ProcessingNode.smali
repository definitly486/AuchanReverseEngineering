.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;
.super Ljava/lang/Object;
.source "ProcessingNode.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;
    }
.end annotation


# instance fields
.field private mBitmap2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field final mBlockingExecutor:Ljava/util/concurrent/Executor;

.field private final mHasIncorrectJpegMetadataQuirk:Z

.field private mImage2Bitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mImage2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field final mImageProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

.field private mInput2Packet:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mInputEdge:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

.field private mJpegBytes2CroppedBitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mJpegBytes2Disk:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mJpegBytes2Image:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private mJpegImage2Result:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

.field private final mQuirks:Landroidx/camera/core/impl/Quirks;


# direct methods
.method public static synthetic $r8$lambda$1KS_UxQ559WWCCTkk2ROJ1HvnoQ(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCapture$OutputFileResults;)V
    .locals 0

    .line 184
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onFinalResult(Landroidx/camera/core/ImageCapture$OutputFileResults;)V

    return-void
.end method

.method public static synthetic $r8$lambda$6U13Zlx7P74SDa-Hwc-iYmFh6g8(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 2

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 127
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->isAborted()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 129
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getImageProxy()Landroidx/camera/core/ImageProxy;

    move-result-object p0

    invoke-interface {p0}, Landroidx/camera/core/ImageProxy;->close()V

    return-void

    .line 132
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBlockingExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public static synthetic $r8$lambda$Dyd-C8C5v5RyU_LUTOih5XrCnUA(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageProxy;)V
    .locals 0

    .line 181
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onFinalResult(Landroidx/camera/core/ImageProxy;)V

    return-void
.end method

.method public static synthetic $r8$lambda$EI5MKd_Nwbt-kM8O4-wtsjxa9o4(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 2

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 136
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->isAborted()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 137
    const-string p0, "ProcessingNode"

    const-string v0, "The postview image is closed due to request aborted"

    invoke-static {p0, v0}, Landroidx/camera/core/Logger;->w(Ljava/lang/String;Ljava/lang/String;)V

    .line 140
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getImageProxy()Landroidx/camera/core/ImageProxy;

    move-result-object p0

    invoke-interface {p0}, Landroidx/camera/core/ImageProxy;->close()V

    return-void

    .line 143
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBlockingExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda2;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public static synthetic $r8$lambda$JmQGVOKdnxLl7G2mmDH2jCuypVI(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 0

    .line 143
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->processPostviewInputPacket(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V

    return-void
.end method

.method public static synthetic $r8$lambda$RV_s8_qnBjf0nBF138h6IngABHM(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroid/graphics/Bitmap;)V
    .locals 0

    .line 207
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onPostviewBitmapAvailable(Landroid/graphics/Bitmap;)V

    return-void
.end method

.method public static synthetic $r8$lambda$TuzUOw7ZYJ3HYz2yCF1myuddRtI(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V
    .locals 0

    .line 273
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onProcessFailure(Landroidx/camera/core/ImageCaptureException;)V

    return-void
.end method

.method public static synthetic $r8$lambda$cI2ICEMuDd0UqmUT_5T0Vcv_lxM(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 0

    .line 132
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->processInputPacket(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V

    return-void
.end method

.method constructor <init>(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;)V
    .locals 1

    .line 98
    invoke-static {}, Landroidx/camera/core/internal/compat/quirk/DeviceQuirks;->getAll()Landroidx/camera/core/impl/Quirks;

    move-result-object v0

    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;-><init>(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/impl/Quirks;)V

    return-void
.end method

.method constructor <init>(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/impl/Quirks;)V
    .locals 1

    .line 108
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 109
    const-class v0, Landroidx/camera/core/internal/compat/quirk/LowMemoryQuirk;

    invoke-static {v0}, Landroidx/camera/core/internal/compat/quirk/DeviceQuirks;->get(Ljava/lang/Class;)Landroidx/camera/core/impl/Quirk;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 111
    invoke-static {p1}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->newSequentialExecutor(Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Executor;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBlockingExecutor:Ljava/util/concurrent/Executor;

    goto :goto_0

    .line 113
    :cond_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBlockingExecutor:Ljava/util/concurrent/Executor;

    .line 115
    :goto_0
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImageProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    .line 116
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mQuirks:Landroidx/camera/core/impl/Quirks;

    .line 117
    const-class p1, Landroidx/camera/core/internal/compat/quirk/IncorrectJpegMetadataQuirk;

    invoke-virtual {p3, p1}, Landroidx/camera/core/impl/Quirks;->contains(Ljava/lang/Class;)Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mHasIncorrectJpegMetadataQuirk:Z

    return-void
.end method

.method private cropAndMaybeApplyEffect(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
    .locals 1

    .line 258
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getFormat()I

    move-result v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil;->isJpegFormats(I)Z

    move-result v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkState(Z)V

    .line 259
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2CroppedBitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 260
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    if-eqz v0, :cond_0

    .line 262
    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 264
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmap2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 265
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;->of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes$In;

    move-result-object p1

    .line 264
    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    return-object p1
.end method

.method private static sendError(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V
    .locals 2

    .line 273
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda7;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method


# virtual methods
.method processInMemoryCapture(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)Landroidx/camera/core/ImageProxy;
    .locals 3

    .line 236
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    .line 237
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInput2Packet:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 240
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->getFormat()I

    move-result v1

    const/16 v2, 0x23

    if-eq v1, v2, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    if-nez v1, :cond_0

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mHasIncorrectJpegMetadataQuirk:Z

    if-eqz v1, :cond_2

    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInputEdge:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

    .line 242
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getOutputFormat()I

    move-result v1

    const/16 v2, 0x100

    if-ne v1, v2, :cond_2

    .line 243
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImage2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 244
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->getJpegQuality()I

    move-result v2

    invoke-static {p1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;->of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;

    move-result-object p1

    .line 243
    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 245
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    if-eqz v1, :cond_1

    .line 246
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->getJpegQuality()I

    move-result v0

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->cropAndMaybeApplyEffect(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    .line 248
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2Image:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 250
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegImage2Result:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/camera/core/ImageProxy;

    return-object p1
.end method

.method processInputPacket(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 4

    .line 177
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    const/4 v1, 0x0

    .line 179
    :try_start_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v2

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->isInMemoryCapture()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 180
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->processInMemoryCapture(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)Landroidx/camera/core/ImageProxy;

    move-result-object p1

    .line 181
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v2

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda4;

    invoke-direct {v3, v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageProxy;)V

    invoke-interface {v2, v3}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void

    :catch_0
    move-exception p1

    goto :goto_0

    :catch_1
    move-exception p1

    goto :goto_1

    :catch_2
    move-exception p1

    goto :goto_2

    .line 183
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->processOnDiskCapture(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)Landroidx/camera/core/ImageCapture$OutputFileResults;

    move-result-object p1

    .line 184
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v2

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda5;

    invoke-direct {v3, v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCapture$OutputFileResults;)V

    invoke-interface {v2, v3}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V
    :try_end_0
    .catch Landroidx/camera/core/ImageCaptureException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/RuntimeException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    .line 193
    :goto_0
    new-instance v2, Landroidx/camera/core/ImageCaptureException;

    const-string v3, "Processing failed."

    invoke-direct {v2, v1, v3, p1}, Landroidx/camera/core/ImageCaptureException;-><init>(ILjava/lang/String;Ljava/lang/Throwable;)V

    invoke-static {v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->sendError(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V

    goto :goto_3

    .line 189
    :goto_1
    new-instance v2, Landroidx/camera/core/ImageCaptureException;

    const-string v3, "Processing failed due to low memory."

    invoke-direct {v2, v1, v3, p1}, Landroidx/camera/core/ImageCaptureException;-><init>(ILjava/lang/String;Ljava/lang/Throwable;)V

    invoke-static {v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->sendError(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V

    goto :goto_3

    .line 187
    :goto_2
    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->sendError(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageCaptureException;)V

    :goto_3
    return-void
.end method

.method processOnDiskCapture(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)Landroidx/camera/core/ImageCapture$OutputFileResults;
    .locals 3

    .line 218
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInputEdge:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getOutputFormat()I

    move-result v0

    .line 219
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil;->isJpegFormats(I)Z

    move-result v1

    .line 220
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    .line 219
    const-string v2, "On-disk capture only support JPEG and JPEG/R output formats. Output format: %s"

    invoke-static {v2, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 221
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    .line 222
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInput2Packet:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 223
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImage2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 224
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->getJpegQuality()I

    move-result v2

    invoke-static {p1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;->of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;

    move-result-object p1

    .line 223
    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 225
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;->hasCropping()Z

    move-result v1

    if-nez v1, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    if-eqz v1, :cond_1

    .line 226
    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->getJpegQuality()I

    move-result v1

    invoke-direct {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->cropAndMaybeApplyEffect(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    move-result-object p1

    .line 228
    :cond_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2Disk:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 229
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->getOutputFileOptions()Landroidx/camera/core/ImageCapture$OutputFileOptions;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk$In;->of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;Landroidx/camera/core/ImageCapture$OutputFileOptions;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk$In;

    move-result-object p1

    .line 228
    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/camera/core/ImageCapture$OutputFileResults;

    return-object p1
.end method

.method processPostviewInputPacket(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V
    .locals 4

    .line 199
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInputEdge:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getOutputFormat()I

    move-result v0

    const/16 v1, 0x23

    if-eq v0, v1, :cond_1

    const/16 v1, 0x100

    if-ne v0, v1, :cond_0

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    goto :goto_1

    :cond_1
    :goto_0
    const/4 v1, 0x1

    .line 202
    :goto_1
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    .line 201
    const-string v2, "Postview only support YUV and JPEG output formats. Output format: %s"

    invoke-static {v2, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 200
    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 203
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    move-result-object v0

    .line 205
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInput2Packet:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;

    .line 206
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImage2Bitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    invoke-interface {v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;->apply(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/graphics/Bitmap;

    .line 207
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v2

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda6;

    invoke-direct {v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroid/graphics/Bitmap;)V

    invoke-interface {v2, v3}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    .line 209
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;->getImageProxy()Landroidx/camera/core/ImageProxy;

    move-result-object p1

    invoke-interface {p1}, Landroidx/camera/core/ImageProxy;->close()V

    .line 210
    const-string p1, "ProcessingNode"

    const-string v1, "process postview input packet failed."

    invoke-static {p1, v1, v0}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V

    return-void
.end method

.method public release()V
    .locals 0

    .line 170
    return-void
.end method

.method public transform(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;)Ljava/lang/Void;
    .locals 2

    .line 123
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInputEdge:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;

    .line 125
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;->setListener(Landroidx/core/util/Consumer;)V

    .line 134
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getPostviewEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;->setListener(Landroidx/core/util/Consumer;)V

    .line 147
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingInput2Packet;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingInput2Packet;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mInput2Packet:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 148
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mQuirks:Landroidx/camera/core/impl/Quirks;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes;-><init>(Landroidx/camera/core/impl/Quirks;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImage2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 149
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2CroppedBitmap;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2CroppedBitmap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2CroppedBitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 150
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Bitmap2JpegBytes;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmap2JpegBytes:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 151
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2Disk:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 152
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegImage2Result;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegImage2Result;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegImage2Result:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 153
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2Bitmap;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2Bitmap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImage2Bitmap:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 154
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;->getInputFormat()I

    move-result p1

    const/16 v0, 0x23

    if-eq p1, v0, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImageProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    if-nez p1, :cond_0

    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mHasIncorrectJpegMetadataQuirk:Z

    if-eqz p1, :cond_1

    .line 159
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Image;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Image;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mJpegBytes2Image:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    .line 161
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mImageProcessor:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    if-eqz p1, :cond_2

    .line 162
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/BitmapEffect;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->mBitmapEffect:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Operation;

    :cond_2
    const/4 p1, 0x0

    return-object p1
.end method
