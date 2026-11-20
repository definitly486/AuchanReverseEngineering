.class public Lorg/opencv/dnn/DictValue;
.super Ljava/lang/Object;
.source "DictValue.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native DictValue_0(I)J
.end method

.method private static native DictValue_1(D)J
.end method

.method private static native DictValue_2(Ljava/lang/String;)J
.end method

.method private static native delete(J)V
.end method

.method private static native getIntValue_0(JI)I
.end method

.method private static native getIntValue_1(J)I
.end method

.method private static native getRealValue_0(JI)D
.end method

.method private static native getRealValue_1(J)D
.end method

.method private static native getStringValue_0(JI)Ljava/lang/String;
.end method

.method private static native getStringValue_1(J)Ljava/lang/String;
.end method

.method private static native isInt_0(J)Z
.end method

.method private static native isReal_0(J)Z
.end method

.method private static native isString_0(J)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 118
    iget-wide v0, p0, Lorg/opencv/dnn/DictValue;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/DictValue;->delete(J)V

    return-void
.end method
