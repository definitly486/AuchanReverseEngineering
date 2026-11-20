.class public Lorg/opencv/dnn/DetectionModel;
.super Lorg/opencv/dnn/Model;
.source "DetectionModel.java"


# direct methods
.method private static native DetectionModel_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native DetectionModel_1(Ljava/lang/String;)J
.end method

.method private static native DetectionModel_2(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native detect_0(JJJJJFF)V
.end method

.method private static native detect_1(JJJJJF)V
.end method

.method private static native detect_2(JJJJJ)V
.end method

.method private static native getNmsAcrossClasses_0(J)Z
.end method

.method private static native setNmsAcrossClasses_0(JZ)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 152
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/DetectionModel;->delete(J)V

    return-void
.end method
