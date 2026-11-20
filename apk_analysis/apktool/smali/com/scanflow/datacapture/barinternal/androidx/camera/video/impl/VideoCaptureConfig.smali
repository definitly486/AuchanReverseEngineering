.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;
.super Ljava/lang/Object;
.source "VideoCaptureConfig.java"

# interfaces
.implements Landroidx/camera/core/impl/UseCaseConfig;
.implements Landroidx/camera/core/impl/ImageOutputConfig;
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ThreadConfig;


# static fields
.field public static final OPTION_FORCE_ENABLE_SURFACE_PROCESSING:Landroidx/camera/core/impl/Config$Option;

.field public static final OPTION_VIDEO_ENCODER_INFO_FINDER:Landroidx/camera/core/impl/Config$Option;

.field public static final OPTION_VIDEO_OUTPUT:Landroidx/camera/core/impl/Config$Option;


# instance fields
.field private final mConfig:Landroidx/camera/core/impl/OptionsBundle;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 51
    const-string v0, "camerax.video.VideoCapture.videoOutput"

    const-class v1, Landroidx/camera/video/VideoOutput;

    .line 52
    invoke-static {v0, v1}, Landroidx/camera/core/impl/Config$Option;->create(Ljava/lang/String;Ljava/lang/Class;)Landroidx/camera/core/impl/Config$Option;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_VIDEO_OUTPUT:Landroidx/camera/core/impl/Config$Option;

    .line 55
    const-string v0, "camerax.video.VideoCapture.videoEncoderInfoFinder"

    const-class v1, Landroidx/arch/core/util/Function;

    .line 56
    invoke-static {v0, v1}, Landroidx/camera/core/impl/Config$Option;->create(Ljava/lang/String;Ljava/lang/Class;)Landroidx/camera/core/impl/Config$Option;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_VIDEO_ENCODER_INFO_FINDER:Landroidx/camera/core/impl/Config$Option;

    .line 58
    const-string v0, "camerax.video.VideoCapture.forceEnableSurfaceProcessing"

    const-class v1, Ljava/lang/Boolean;

    invoke-static {v0, v1}, Landroidx/camera/core/impl/Config$Option;->create(Ljava/lang/String;Ljava/lang/Class;)Landroidx/camera/core/impl/Config$Option;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_FORCE_ENABLE_SURFACE_PROCESSING:Landroidx/camera/core/impl/Config$Option;

    return-void
.end method

.method public constructor <init>(Landroidx/camera/core/impl/OptionsBundle;)V
    .locals 1

    .line 65
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 66
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_VIDEO_OUTPUT:Landroidx/camera/core/impl/Config$Option;

    invoke-virtual {p1, v0}, Landroidx/camera/core/impl/OptionsBundle;->containsOption(Landroidx/camera/core/impl/Config$Option;)Z

    move-result v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(Z)V

    .line 67
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->mConfig:Landroidx/camera/core/impl/OptionsBundle;

    return-void
.end method


# virtual methods
.method public getConfig()Landroidx/camera/core/impl/Config;
    .locals 1

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->mConfig:Landroidx/camera/core/impl/OptionsBundle;

    return-object v0
.end method

.method public getInputFormat()I
    .locals 1

    .line 92
    const/16 v0, 0x22

    return v0
.end method

.method public getVideoEncoderInfoFinder()Landroidx/arch/core/util/Function;
    .locals 1

    .line 78
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_VIDEO_ENCODER_INFO_FINDER:Landroidx/camera/core/impl/Config$Option;

    invoke-interface {p0, v0}, Landroidx/camera/core/impl/ReadableConfig;->retrieveOption(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/arch/core/util/Function;

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v0, Landroidx/arch/core/util/Function;

    return-object v0
.end method

.method public getVideoOutput()Landroidx/camera/video/VideoOutput;
    .locals 1

    .line 73
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_VIDEO_OUTPUT:Landroidx/camera/core/impl/Config$Option;

    invoke-interface {p0, v0}, Landroidx/camera/core/impl/ReadableConfig;->retrieveOption(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/video/VideoOutput;

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v0, Landroidx/camera/video/VideoOutput;

    return-object v0
.end method

.method public isSurfaceProcessingForceEnabled()Z
    .locals 2

    .line 82
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/impl/VideoCaptureConfig;->OPTION_FORCE_ENABLE_SURFACE_PROCESSING:Landroidx/camera/core/impl/Config$Option;

    sget-object v1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-interface {p0, v0, v1}, Landroidx/camera/core/impl/ReadableConfig;->retrieveOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Boolean;

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    return v0
.end method
