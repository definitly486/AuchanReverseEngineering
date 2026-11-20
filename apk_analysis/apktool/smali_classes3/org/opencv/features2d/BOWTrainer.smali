.class public Lorg/opencv/features2d/BOWTrainer;
.super Ljava/lang/Object;
.source "BOWTrainer.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native add_0(JJ)V
.end method

.method private static native clear_0(J)V
.end method

.method private static native cluster_0(J)J
.end method

.method private static native cluster_1(JJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native descriptorsCount_0(J)I
.end method

.method private static native getDescriptors_0(J)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 114
    iget-wide v0, p0, Lorg/opencv/features2d/BOWTrainer;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/BOWTrainer;->delete(J)V

    return-void
.end method
