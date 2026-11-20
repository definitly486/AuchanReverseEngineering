.class public Lorg/opencv/ml/RTrees;
.super Lorg/opencv/ml/DTrees;
.source "RTrees.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getActiveVarCount_0(J)I
.end method

.method private static native getCalculateVarImportance_0(J)Z
.end method

.method private static native getOOBError_0(J)D
.end method

.method private static native getTermCriteria_0(J)[D
.end method

.method private static native getVarImportance_0(J)J
.end method

.method private static native getVotes_0(JJJI)V
.end method

.method private static native load_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native load_1(Ljava/lang/String;)J
.end method

.method private static native setActiveVarCount_0(JI)V
.end method

.method private static native setCalculateVarImportance_0(JZ)V
.end method

.method private static native setTermCriteria_0(JIID)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 202
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/RTrees;->delete(J)V

    return-void
.end method
