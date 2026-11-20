.class public Lorg/opencv/core/TickMeter;
.super Ljava/lang/Object;
.source "TickMeter.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native TickMeter_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getAvgTimeMilli_0(J)D
.end method

.method private static native getAvgTimeSec_0(J)D
.end method

.method private static native getCounter_0(J)J
.end method

.method private static native getFPS_0(J)D
.end method

.method private static native getLastTimeMicro_0(J)D
.end method

.method private static native getLastTimeMilli_0(J)D
.end method

.method private static native getLastTimeSec_0(J)D
.end method

.method private static native getLastTimeTicks_0(J)J
.end method

.method private static native getTimeMicro_0(J)D
.end method

.method private static native getTimeMilli_0(J)D
.end method

.method private static native getTimeSec_0(J)D
.end method

.method private static native getTimeTicks_0(J)J
.end method

.method private static native reset_0(J)V
.end method

.method private static native start_0(J)V
.end method

.method private static native stop_0(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 177
    iget-wide v0, p0, Lorg/opencv/core/TickMeter;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/core/TickMeter;->delete(J)V

    return-void
.end method
