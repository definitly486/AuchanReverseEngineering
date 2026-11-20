.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$PacketInfo;
.super Ljava/lang/Object;
.source "AudioStream.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "PacketInfo"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 83
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static of(IJ)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$PacketInfo;
    .locals 1

    .line 93
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AutoValue_AudioStream_PacketInfo;

    invoke-direct {v0, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AutoValue_AudioStream_PacketInfo;-><init>(IJ)V

    return-object v0
.end method


# virtual methods
.method public abstract getSizeInBytes()I
.end method

.method public abstract getTimestampNs()J
.end method
