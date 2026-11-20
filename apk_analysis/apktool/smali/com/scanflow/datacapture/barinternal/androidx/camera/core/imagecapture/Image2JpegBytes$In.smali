.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;
.super Ljava/lang/Object;
.source "Image2JpegBytes.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "In"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 131
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/Image2JpegBytes$In;
    .locals 1

    .line 139
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_Image2JpegBytes_In;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_Image2JpegBytes_In;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;I)V

    return-object v0
.end method


# virtual methods
.method abstract getJpegQuality()I
.end method

.method abstract getPacket()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Packet;
.end method
