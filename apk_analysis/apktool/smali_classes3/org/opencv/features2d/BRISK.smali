.class public Lorg/opencv/features2d/BRISK;
.super Lorg/opencv/features2d/Feature2D;
.source "BRISK.java"


# direct methods
.method private static native create_0(IIF)J
.end method

.method private static native create_1(II)J
.end method

.method private static native create_10(IIJJF)J
.end method

.method private static native create_11(IIJJ)J
.end method

.method private static native create_2(I)J
.end method

.method private static native create_3()J
.end method

.method private static native create_4(JJFFJ)J
.end method

.method private static native create_5(JJFF)J
.end method

.method private static native create_6(JJF)J
.end method

.method private static native create_7(JJ)J
.end method

.method private static native create_8(IIJJFFJ)J
.end method

.method private static native create_9(IIJJFF)J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getOctaves_0(J)I
.end method

.method private static native getPatternScale_0(J)F
.end method

.method private static native getThreshold_0(J)I
.end method

.method private static native setOctaves_0(JI)V
.end method

.method private static native setPatternScale_0(JF)V
.end method

.method private static native setThreshold_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 323
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/BRISK;->delete(J)V

    return-void
.end method
