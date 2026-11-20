.class public Lorg/opencv/dnn/Image2BlobParams;
.super Ljava/lang/Object;
.source "Image2BlobParams.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Image2BlobParams_0()J
.end method

.method private static native Image2BlobParams_1(DDDDDDDDDDZIIDDDD)J
.end method

.method private static native Image2BlobParams_2(DDDDDDDDDDZII)J
.end method

.method private static native Image2BlobParams_4(DDDDDDDDDDZI)J
.end method

.method private static native Image2BlobParams_5(DDDDDDDDDDZ)J
.end method

.method private static native Image2BlobParams_6(DDDDDDDDDD)J
.end method

.method private static native Image2BlobParams_7(DDDDDD)J
.end method

.method private static native Image2BlobParams_8(DDDD)J
.end method

.method private static native blobRectToImageRect_0(JIIIIDD)[D
.end method

.method private static native blobRectsToImageRects_0(JJJDD)V
.end method

.method private static native delete(J)V
.end method

.method private static native get_borderValue_0(J)[D
.end method

.method private static native get_datalayout_0(J)I
.end method

.method private static native get_ddepth_0(J)I
.end method

.method private static native get_mean_0(J)[D
.end method

.method private static native get_paddingmode_0(J)I
.end method

.method private static native get_scalefactor_0(J)[D
.end method

.method private static native get_size_0(J)[D
.end method

.method private static native get_swapRB_0(J)Z
.end method

.method private static native set_borderValue_0(JDDDD)V
.end method

.method private static native set_datalayout_0(JI)V
.end method

.method private static native set_ddepth_0(JI)V
.end method

.method private static native set_mean_0(JDDDD)V
.end method

.method private static native set_paddingmode_0(JI)V
.end method

.method private static native set_scalefactor_0(JDDDD)V
.end method

.method private static native set_size_0(JDD)V
.end method

.method private static native set_swapRB_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 258
    iget-wide v0, p0, Lorg/opencv/dnn/Image2BlobParams;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/Image2BlobParams;->delete(J)V

    return-void
.end method
