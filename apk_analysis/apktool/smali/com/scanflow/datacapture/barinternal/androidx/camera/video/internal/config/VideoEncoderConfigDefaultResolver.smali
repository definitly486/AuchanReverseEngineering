.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;
.super Ljava/lang/Object;
.source "VideoEncoderConfigDefaultResolver.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/core/util/Supplier;


# static fields
.field private static final VALID_FRAME_RATE_RANGE:Landroid/util/Range;

.field private static final VIDEO_SIZE_BASE:Landroid/util/Size;


# instance fields
.field private final mDynamicRange:Landroidx/camera/core/DynamicRange;

.field private final mExpectedFrameRateRange:Landroid/util/Range;

.field private final mInputTimebase:Landroidx/camera/core/impl/Timebase;

.field private final mMimeType:Ljava/lang/String;

.field private final mSurfaceSize:Landroid/util/Size;

.field private final mVideoSpec:Landroidx/camera/video/VideoSpec;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 46
    new-instance v0, Landroid/util/Size;

    const/16 v1, 0x500

    const/16 v2, 0x2d0

    invoke-direct {v0, v1, v2}, Landroid/util/Size;-><init>(II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->VIDEO_SIZE_BASE:Landroid/util/Size;

    .line 50
    new-instance v0, Landroid/util/Range;

    const/4 v1, 0x1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    const/16 v2, 0x3c

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Landroid/util/Range;-><init>(Ljava/lang/Comparable;Ljava/lang/Comparable;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->VALID_FRAME_RATE_RANGE:Landroid/util/Range;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Landroidx/camera/core/impl/Timebase;Landroidx/camera/video/VideoSpec;Landroid/util/Size;Landroidx/camera/core/DynamicRange;Landroid/util/Range;)V
    .locals 0

    .line 81
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 82
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    .line 83
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mInputTimebase:Landroidx/camera/core/impl/Timebase;

    .line 84
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mVideoSpec:Landroidx/camera/video/VideoSpec;

    .line 85
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mSurfaceSize:Landroid/util/Size;

    .line 86
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mDynamicRange:Landroidx/camera/core/DynamicRange;

    .line 87
    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mExpectedFrameRateRange:Landroid/util/Range;

    return-void
.end method

.method private resolveFrameRate()I
    .locals 4

    .line 128
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mExpectedFrameRateRange:Landroid/util/Range;

    sget-object v1, Landroidx/camera/core/SurfaceRequest;->FRAME_RATE_RANGE_UNSPECIFIED:Landroid/util/Range;

    invoke-static {v0, v1}, Ljava/util/Objects;->equals(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 129
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->VALID_FRAME_RATE_RANGE:Landroid/util/Range;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mExpectedFrameRateRange:Landroid/util/Range;

    invoke-virtual {v2}, Landroid/util/Range;->getUpper()Ljava/lang/Comparable;

    move-result-object v2

    check-cast v2, Ljava/lang/Integer;

    invoke-virtual {v0, v2}, Landroid/util/Range;->clamp(Ljava/lang/Comparable;)Ljava/lang/Comparable;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    goto :goto_0

    :cond_0
    const/16 v0, 0x1e

    .line 137
    :goto_0
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mExpectedFrameRateRange:Landroid/util/Range;

    invoke-static {v3, v1}, Ljava/util/Objects;->equals(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 139
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mExpectedFrameRateRange:Landroid/util/Range;

    goto :goto_1

    :cond_1
    const-string v1, "<UNSPECIFIED>"

    :goto_1
    filled-new-array {v2, v1}, [Ljava/lang/Object;

    move-result-object v1

    .line 136
    const-string v2, "Default resolved frame rate: %dfps. [Expected operating range: %s]"

    invoke-static {v2, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    .line 135
    const-string v2, "VidEncCfgDefaultRslvr"

    invoke-static {v2, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    return v0
.end method


# virtual methods
.method public get()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;
    .locals 10

    .line 93
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->resolveFrameRate()I

    move-result v3

    .line 94
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Resolved VIDEO frame rate: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, "fps"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "VidEncCfgDefaultRslvr"

    invoke-static {v1, v0}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 96
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mVideoSpec:Landroidx/camera/video/VideoSpec;

    invoke-virtual {v0}, Landroidx/camera/video/VideoSpec;->getBitrate()Landroid/util/Range;

    move-result-object v9

    .line 97
    const-string v0, "Using fallback VIDEO bitrate"

    invoke-static {v1, v0}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mDynamicRange:Landroidx/camera/core/DynamicRange;

    .line 101
    invoke-virtual {v0}, Landroidx/camera/core/DynamicRange;->getBitDepth()I

    move-result v1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mSurfaceSize:Landroid/util/Size;

    .line 103
    invoke-virtual {v0}, Landroid/util/Size;->getWidth()I

    move-result v5

    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->VIDEO_SIZE_BASE:Landroid/util/Size;

    invoke-virtual {v0}, Landroid/util/Size;->getWidth()I

    move-result v6

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mSurfaceSize:Landroid/util/Size;

    .line 104
    invoke-virtual {v2}, Landroid/util/Size;->getHeight()I

    move-result v7

    invoke-virtual {v0}, Landroid/util/Size;->getHeight()I

    move-result v8

    const v0, 0xd59f80

    const/16 v2, 0x8

    const/16 v4, 0x1e

    .line 99
    invoke-static/range {v0 .. v9}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoConfigUtil;->scaleAndClampBitrate(IIIIIIIIILandroid/util/Range;)I

    move-result v0

    .line 107
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mDynamicRange:Landroidx/camera/core/DynamicRange;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/utils/DynamicRangeUtil;->dynamicRangeToCodecProfileLevelForMime(Ljava/lang/String;Landroidx/camera/core/DynamicRange;)I

    move-result v1

    .line 109
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    .line 110
    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoConfigUtil;->mimeAndProfileToEncoderDataSpace(Ljava/lang/String;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderDataSpace;

    move-result-object v2

    .line 112
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;->builder()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v4

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    .line 113
    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setMimeType(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v4

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mInputTimebase:Landroidx/camera/core/impl/Timebase;

    .line 114
    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setInputTimebase(Landroidx/camera/core/impl/Timebase;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v4

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->mSurfaceSize:Landroid/util/Size;

    .line 115
    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setResolution(Landroid/util/Size;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v4

    .line 116
    invoke-virtual {v4, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setBitrate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v0

    .line 117
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setFrameRate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v0

    .line 118
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setProfile(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v0

    .line 119
    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->setDataSpace(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderDataSpace;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;

    move-result-object v0

    .line 120
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;->build()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic get()Ljava/lang/Object;
    .locals 1

    .line 39
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoEncoderConfigDefaultResolver;->get()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;

    move-result-object v0

    return-object v0
.end method
