.class public Lorg/opencv/video/TrackerVit_Params;
.super Ljava/lang/Object;
.source "TrackerVit_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native TrackerVit_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_backend_0(J)I
.end method

.method private static native get_meanvalue_0(J)[D
.end method

.method private static native get_net_0(J)Ljava/lang/String;
.end method

.method private static native get_stdvalue_0(J)[D
.end method

.method private static native get_target_0(J)I
.end method

.method private static native get_tracking_score_threshold_0(J)F
.end method

.method private static native set_backend_0(JI)V
.end method

.method private static native set_meanvalue_0(JDDDD)V
.end method

.method private static native set_net_0(JLjava/lang/String;)V
.end method

.method private static native set_stdvalue_0(JDDDD)V
.end method

.method private static native set_target_0(JI)V
.end method

.method private static native set_tracking_score_threshold_0(JF)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 139
    iget-wide v0, p0, Lorg/opencv/video/TrackerVit_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/TrackerVit_Params;->delete(J)V

    return-void
.end method
