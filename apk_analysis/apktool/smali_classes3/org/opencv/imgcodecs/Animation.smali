.class public Lorg/opencv/imgcodecs/Animation;
.super Ljava/lang/Object;
.source "Animation.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Animation_0(IDDDD)J
.end method

.method private static native Animation_1(I)J
.end method

.method private static native Animation_2()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_bgcolor_0(J)[D
.end method

.method private static native get_durations_0(J)J
.end method

.method private static native get_frames_0(J)J
.end method

.method private static native get_loop_count_0(J)I
.end method

.method private static native get_still_image_0(J)J
.end method

.method private static native set_bgcolor_0(JDDDD)V
.end method

.method private static native set_durations_0(JJ)V
.end method

.method private static native set_frames_0(JJ)V
.end method

.method private static native set_loop_count_0(JI)V
.end method

.method private static native set_still_image_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 221
    iget-wide v0, p0, Lorg/opencv/imgcodecs/Animation;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/imgcodecs/Animation;->delete(J)V

    return-void
.end method
