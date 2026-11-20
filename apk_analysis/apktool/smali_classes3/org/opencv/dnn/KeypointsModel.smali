.class public Lorg/opencv/dnn/KeypointsModel;
.super Lorg/opencv/dnn/Model;
.source "KeypointsModel.java"


# direct methods
.method private static native KeypointsModel_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native KeypointsModel_1(Ljava/lang/String;)J
.end method

.method private static native KeypointsModel_2(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native estimate_0(JJF)J
.end method

.method private static native estimate_1(JJ)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 94
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/KeypointsModel;->delete(J)V

    return-void
.end method
