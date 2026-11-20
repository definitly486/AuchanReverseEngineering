.class public Lorg/opencv/dnn/Layer;
.super Lorg/opencv/core/Algorithm;
.source "Layer.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native finalize_0(JJJ)V
.end method

.method private static native get_blobs_0(J)J
.end method

.method private static native get_name_0(J)Ljava/lang/String;
.end method

.method private static native get_preferableTarget_0(J)I
.end method

.method private static native get_type_0(J)Ljava/lang/String;
.end method

.method private static native outputNameToIndex_0(JLjava/lang/String;)I
.end method

.method private static native run_0(JJJJ)V
.end method

.method private static native set_blobs_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 137
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/Layer;->delete(J)V

    return-void
.end method
