.class public Lorg/opencv/video/TrackerNano_Params;
.super Ljava/lang/Object;
.source "TrackerNano_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native TrackerNano_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_backbone_0(J)Ljava/lang/String;
.end method

.method private static native get_backend_0(J)I
.end method

.method private static native get_neckhead_0(J)Ljava/lang/String;
.end method

.method private static native get_target_0(J)I
.end method

.method private static native set_backbone_0(JLjava/lang/String;)V
.end method

.method private static native set_backend_0(JI)V
.end method

.method private static native set_neckhead_0(JLjava/lang/String;)V
.end method

.method private static native set_target_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 103
    iget-wide v0, p0, Lorg/opencv/video/TrackerNano_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/TrackerNano_Params;->delete(J)V

    return-void
.end method
