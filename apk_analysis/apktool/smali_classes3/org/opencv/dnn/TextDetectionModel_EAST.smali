.class public Lorg/opencv/dnn/TextDetectionModel_EAST;
.super Lorg/opencv/dnn/TextDetectionModel;
.source "TextDetectionModel_EAST.java"


# direct methods
.method private static native TextDetectionModel_EAST_0(J)J
.end method

.method private static native TextDetectionModel_EAST_1(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native TextDetectionModel_EAST_2(Ljava/lang/String;)J
.end method

.method private static native delete(J)V
.end method

.method private static native getConfidenceThreshold_0(J)F
.end method

.method private static native getNMSThreshold_0(J)F
.end method

.method private static native setConfidenceThreshold_0(JF)J
.end method

.method private static native setNMSThreshold_0(JF)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 118
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/TextDetectionModel_EAST;->delete(J)V

    return-void
.end method
