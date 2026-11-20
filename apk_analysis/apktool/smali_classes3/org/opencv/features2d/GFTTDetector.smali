.class public Lorg/opencv/features2d/GFTTDetector;
.super Lorg/opencv/features2d/Feature2D;
.source "GFTTDetector.java"


# direct methods
.method private static native create_0(IDDIZD)J
.end method

.method private static native create_1(IDDIZ)J
.end method

.method private static native create_2(IDDI)J
.end method

.method private static native create_3(IDD)J
.end method

.method private static native create_4(ID)J
.end method

.method private static native create_5(I)J
.end method

.method private static native create_6()J
.end method

.method private static native create_7(IDDIIZD)J
.end method

.method private static native create_8(IDDIIZ)J
.end method

.method private static native create_9(IDDII)J
.end method

.method private static native delete(J)V
.end method

.method private static native getBlockSize_0(J)I
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getGradientSize_0(J)I
.end method

.method private static native getHarrisDetector_0(J)Z
.end method

.method private static native getK_0(J)D
.end method

.method private static native getMaxFeatures_0(J)I
.end method

.method private static native getMinDistance_0(J)D
.end method

.method private static native getQualityLevel_0(J)D
.end method

.method private static native setBlockSize_0(JI)V
.end method

.method private static native setGradientSize_0(JI)V
.end method

.method private static native setHarrisDetector_0(JZ)V
.end method

.method private static native setK_0(JD)V
.end method

.method private static native setMaxFeatures_0(JI)V
.end method

.method private static native setMinDistance_0(JD)V
.end method

.method private static native setQualityLevel_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 207
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/GFTTDetector;->delete(J)V

    return-void
.end method
