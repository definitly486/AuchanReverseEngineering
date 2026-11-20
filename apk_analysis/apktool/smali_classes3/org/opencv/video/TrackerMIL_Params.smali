.class public Lorg/opencv/video/TrackerMIL_Params;
.super Ljava/lang/Object;
.source "TrackerMIL_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native TrackerMIL_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_featureSetNumFeatures_0(J)I
.end method

.method private static native get_samplerInitInRadius_0(J)F
.end method

.method private static native get_samplerInitMaxNegNum_0(J)I
.end method

.method private static native get_samplerSearchWinSize_0(J)F
.end method

.method private static native get_samplerTrackInRadius_0(J)F
.end method

.method private static native get_samplerTrackMaxNegNum_0(J)I
.end method

.method private static native get_samplerTrackMaxPosNum_0(J)I
.end method

.method private static native set_featureSetNumFeatures_0(JI)V
.end method

.method private static native set_samplerInitInRadius_0(JF)V
.end method

.method private static native set_samplerInitMaxNegNum_0(JI)V
.end method

.method private static native set_samplerSearchWinSize_0(JF)V
.end method

.method private static native set_samplerTrackInRadius_0(JF)V
.end method

.method private static native set_samplerTrackMaxNegNum_0(JI)V
.end method

.method private static native set_samplerTrackMaxPosNum_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 157
    iget-wide v0, p0, Lorg/opencv/video/TrackerMIL_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/TrackerMIL_Params;->delete(J)V

    return-void
.end method
