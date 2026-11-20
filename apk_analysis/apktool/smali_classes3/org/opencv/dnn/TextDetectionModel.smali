.class public Lorg/opencv/dnn/TextDetectionModel;
.super Lorg/opencv/dnn/Model;
.source "TextDetectionModel.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native detectTextRectangles_0(JJJJ)V
.end method

.method private static native detectTextRectangles_1(JJJ)V
.end method

.method private static native detect_0(JJJJ)V
.end method

.method private static native detect_1(JJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 106
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/TextDetectionModel;->delete(J)V

    return-void
.end method
