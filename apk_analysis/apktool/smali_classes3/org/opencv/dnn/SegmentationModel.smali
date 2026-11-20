.class public Lorg/opencv/dnn/SegmentationModel;
.super Lorg/opencv/dnn/Model;
.source "SegmentationModel.java"


# direct methods
.method private static native SegmentationModel_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native SegmentationModel_1(Ljava/lang/String;)J
.end method

.method private static native SegmentationModel_2(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native segment_0(JJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 78
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/SegmentationModel;->delete(J)V

    return-void
.end method
