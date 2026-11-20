.class public Lorg/opencv/objdetect/RefineParameters;
.super Ljava/lang/Object;
.source "RefineParameters.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native RefineParameters_0(FFZ)J
.end method

.method private static native RefineParameters_1(FF)J
.end method

.method private static native RefineParameters_2(F)J
.end method

.method private static native RefineParameters_3()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_checkAllOrders_0(J)Z
.end method

.method private static native get_errorCorrectionRate_0(J)F
.end method

.method private static native get_minRepDistance_0(J)F
.end method

.method private static native set_checkAllOrders_0(JZ)V
.end method

.method private static native set_errorCorrectionRate_0(JF)V
.end method

.method private static native set_minRepDistance_0(JF)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 113
    iget-wide v0, p0, Lorg/opencv/objdetect/RefineParameters;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/RefineParameters;->delete(J)V

    return-void
.end method
