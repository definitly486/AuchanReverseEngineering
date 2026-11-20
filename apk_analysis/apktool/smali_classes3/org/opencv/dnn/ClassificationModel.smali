.class public Lorg/opencv/dnn/ClassificationModel;
.super Lorg/opencv/dnn/Model;
.source "ClassificationModel.java"


# direct methods
.method private static native ClassificationModel_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native ClassificationModel_1(Ljava/lang/String;)J
.end method

.method private static native ClassificationModel_2(J)J
.end method

.method private static native classify_0(JJ[D[D)V
.end method

.method private static native delete(J)V
.end method

.method private static native getEnableSoftmaxPostProcessing_0(J)Z
.end method

.method private static native setEnableSoftmaxPostProcessing_0(JZ)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 112
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/ClassificationModel;->delete(J)V

    return-void
.end method
