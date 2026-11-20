.class public Lorg/opencv/dnn/TextDetectionModel_DB;
.super Lorg/opencv/dnn/TextDetectionModel;
.source "TextDetectionModel_DB.java"


# direct methods
.method private static native TextDetectionModel_DB_0(J)J
.end method

.method private static native TextDetectionModel_DB_1(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native TextDetectionModel_DB_2(Ljava/lang/String;)J
.end method

.method private static native delete(J)V
.end method

.method private static native getBinaryThreshold_0(J)F
.end method

.method private static native getMaxCandidates_0(J)I
.end method

.method private static native getPolygonThreshold_0(J)F
.end method

.method private static native getUnclipRatio_0(J)D
.end method

.method private static native setBinaryThreshold_0(JF)J
.end method

.method private static native setMaxCandidates_0(JI)J
.end method

.method private static native setPolygonThreshold_0(JF)J
.end method

.method private static native setUnclipRatio_0(JD)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 142
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/TextDetectionModel_DB;->delete(J)V

    return-void
.end method
