.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk$In;
.super Ljava/lang/Object;
.source "JpegBytes2Disk.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "In"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 290
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;Landroidx/camera/core/ImageCapture$OutputFileOptions;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/JpegBytes2Disk$In;
    .locals 1

    .line 301
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_JpegBytes2Disk_In;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_JpegBytes2Disk_In;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;Landroidx/camera/core/ImageCapture$OutputFileOptions;)V

    return-object v0
.end method


# virtual methods
.method abstract getOutputFileOptions()Landroidx/camera/core/ImageCapture$OutputFileOptions;
.end method

.method abstract getPacket()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
.end method
