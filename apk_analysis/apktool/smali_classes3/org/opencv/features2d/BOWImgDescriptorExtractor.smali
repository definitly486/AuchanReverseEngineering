.class public Lorg/opencv/features2d/BOWImgDescriptorExtractor;
.super Ljava/lang/Object;
.source "BOWImgDescriptorExtractor.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native BOWImgDescriptorExtractor_0(JJ)J
.end method

.method private static native compute_0(JJJJ)V
.end method

.method private static native delete(J)V
.end method

.method private static native descriptorSize_0(J)I
.end method

.method private static native descriptorType_0(J)I
.end method

.method private static native getVocabulary_0(J)J
.end method

.method private static native setVocabulary_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 127
    iget-wide v0, p0, Lorg/opencv/features2d/BOWImgDescriptorExtractor;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/BOWImgDescriptorExtractor;->delete(J)V

    return-void
.end method
