.class public Lorg/opencv/features2d/ORB;
.super Lorg/opencv/features2d/Feature2D;
.source "ORB.java"


# direct methods
.method private static native create_0(IFIIIIIII)J
.end method

.method private static native create_1(IFIIIIII)J
.end method

.method private static native create_2(IFIIIII)J
.end method

.method private static native create_3(IFIIII)J
.end method

.method private static native create_4(IFIII)J
.end method

.method private static native create_5(IFII)J
.end method

.method private static native create_6(IFI)J
.end method

.method private static native create_7(IF)J
.end method

.method private static native create_8(I)J
.end method

.method private static native create_9()J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getEdgeThreshold_0(J)I
.end method

.method private static native getFastThreshold_0(J)I
.end method

.method private static native getFirstLevel_0(J)I
.end method

.method private static native getMaxFeatures_0(J)I
.end method

.method private static native getNLevels_0(J)I
.end method

.method private static native getPatchSize_0(J)I
.end method

.method private static native getScaleFactor_0(J)D
.end method

.method private static native getScoreType_0(J)I
.end method

.method private static native getWTA_K_0(J)I
.end method

.method private static native setEdgeThreshold_0(JI)V
.end method

.method private static native setFastThreshold_0(JI)V
.end method

.method private static native setFirstLevel_0(JI)V
.end method

.method private static native setMaxFeatures_0(JI)V
.end method

.method private static native setNLevels_0(JI)V
.end method

.method private static native setPatchSize_0(JI)V
.end method

.method private static native setScaleFactor_0(JD)V
.end method

.method private static native setScoreType_0(JI)V
.end method

.method private static native setWTA_K_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 534
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/ORB;->delete(J)V

    return-void
.end method
