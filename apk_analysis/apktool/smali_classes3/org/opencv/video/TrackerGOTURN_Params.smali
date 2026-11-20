.class public Lorg/opencv/video/TrackerGOTURN_Params;
.super Ljava/lang/Object;
.source "TrackerGOTURN_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native TrackerGOTURN_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_modelBin_0(J)Ljava/lang/String;
.end method

.method private static native get_modelTxt_0(J)Ljava/lang/String;
.end method

.method private static native set_modelBin_0(JLjava/lang/String;)V
.end method

.method private static native set_modelTxt_0(JLjava/lang/String;)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 67
    iget-wide v0, p0, Lorg/opencv/video/TrackerGOTURN_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/TrackerGOTURN_Params;->delete(J)V

    return-void
.end method
