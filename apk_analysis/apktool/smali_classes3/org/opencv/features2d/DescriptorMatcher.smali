.class public Lorg/opencv/features2d/DescriptorMatcher;
.super Lorg/opencv/core/Algorithm;
.source "DescriptorMatcher.java"


# direct methods
.method protected constructor <init>(J)V
    .locals 0

    .line 23
    invoke-direct {p0, p1, p2}, Lorg/opencv/core/Algorithm;-><init>(J)V

    return-void
.end method

.method public static __fromPtr__(J)Lorg/opencv/features2d/DescriptorMatcher;
    .locals 1

    .line 26
    new-instance v0, Lorg/opencv/features2d/DescriptorMatcher;

    invoke-direct {v0, p0, p1}, Lorg/opencv/features2d/DescriptorMatcher;-><init>(J)V

    return-object v0
.end method

.method private static native add_0(JJ)V
.end method

.method private static native clear_0(J)V
.end method

.method private static native clone_0(JZ)J
.end method

.method private static native clone_1(J)J
.end method

.method private static native create_0(Ljava/lang/String;)J
.end method

.method private static native create_1(I)J
.end method

.method private static native delete(J)V
.end method

.method private static native empty_0(J)Z
.end method

.method private static native getTrainDescriptors_0(J)J
.end method

.method private static native isMaskSupported_0(J)Z
.end method

.method private static native knnMatch_0(JJJJIJZ)V
.end method

.method private static native knnMatch_1(JJJJIJ)V
.end method

.method private static native knnMatch_2(JJJJI)V
.end method

.method private static native knnMatch_3(JJJIJZ)V
.end method

.method private static native knnMatch_4(JJJIJ)V
.end method

.method private static native knnMatch_5(JJJI)V
.end method

.method private static native match_0(JJJJJ)V
.end method

.method private static native match_1(JJJJ)V
.end method

.method private static native match_2(JJJJ)V
.end method

.method private static native match_3(JJJ)V
.end method

.method private static native radiusMatch_0(JJJJFJZ)V
.end method

.method private static native radiusMatch_1(JJJJFJ)V
.end method

.method private static native radiusMatch_2(JJJJF)V
.end method

.method private static native radiusMatch_3(JJJFJZ)V
.end method

.method private static native radiusMatch_4(JJJFJ)V
.end method

.method private static native radiusMatch_5(JJJF)V
.end method

.method private static native read_0(JLjava/lang/String;)V
.end method

.method private static native train_0(J)V
.end method

.method private static native write_0(JLjava/lang/String;)V
.end method


# virtual methods
.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 21
    invoke-virtual {p0}, Lorg/opencv/features2d/DescriptorMatcher;->clone()Lorg/opencv/features2d/DescriptorMatcher;

    move-result-object v0

    return-object v0
.end method

.method public clone()Lorg/opencv/features2d/DescriptorMatcher;
    .locals 2

    .line 544
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/DescriptorMatcher;->clone_1(J)J

    move-result-wide v0

    invoke-static {v0, v1}, Lorg/opencv/features2d/DescriptorMatcher;->__fromPtr__(J)Lorg/opencv/features2d/DescriptorMatcher;

    move-result-object v0

    return-object v0
.end method

.method protected finalize()V
    .locals 2

    .line 600
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/DescriptorMatcher;->delete(J)V

    return-void
.end method
