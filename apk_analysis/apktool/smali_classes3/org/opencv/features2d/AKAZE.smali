.class public Lorg/opencv/features2d/AKAZE;
.super Lorg/opencv/features2d/Feature2D;
.source "AKAZE.java"


# direct methods
.method private static native create_0(IIIFIIII)J
.end method

.method private static native create_1(IIIFIII)J
.end method

.method private static native create_2(IIIFII)J
.end method

.method private static native create_3(IIIFI)J
.end method

.method private static native create_4(IIIF)J
.end method

.method private static native create_5(III)J
.end method

.method private static native create_6(II)J
.end method

.method private static native create_7(I)J
.end method

.method private static native create_8()J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getDescriptorChannels_0(J)I
.end method

.method private static native getDescriptorSize_0(J)I
.end method

.method private static native getDescriptorType_0(J)I
.end method

.method private static native getDiffusivity_0(J)I
.end method

.method private static native getMaxPoints_0(J)I
.end method

.method private static native getNOctaveLayers_0(J)I
.end method

.method private static native getNOctaves_0(J)I
.end method

.method private static native getThreshold_0(J)D
.end method

.method private static native setDescriptorChannels_0(JI)V
.end method

.method private static native setDescriptorSize_0(JI)V
.end method

.method private static native setDescriptorType_0(JI)V
.end method

.method private static native setDiffusivity_0(JI)V
.end method

.method private static native setMaxPoints_0(JI)V
.end method

.method private static native setNOctaveLayers_0(JI)V
.end method

.method private static native setNOctaves_0(JI)V
.end method

.method private static native setThreshold_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 354
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/AKAZE;->delete(J)V

    return-void
.end method
