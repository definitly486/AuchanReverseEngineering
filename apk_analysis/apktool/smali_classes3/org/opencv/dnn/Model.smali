.class public Lorg/opencv/dnn/Model;
.super Ljava/lang/Object;
.source "Model.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Model_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native Model_1(Ljava/lang/String;)J
.end method

.method private static native Model_2(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native enableWinograd_0(JZ)J
.end method

.method private static native predict_0(JJJ)V
.end method

.method private static native setInputCrop_0(JZ)J
.end method

.method private static native setInputMean_0(JDDDD)J
.end method

.method private static native setInputParams_0(JDDDDDDDZZ)V
.end method

.method private static native setInputParams_1(JDDDDDDDZ)V
.end method

.method private static native setInputParams_2(JDDDDDDD)V
.end method

.method private static native setInputParams_3(JDDD)V
.end method

.method private static native setInputParams_4(JD)V
.end method

.method private static native setInputParams_5(J)V
.end method

.method private static native setInputScale_0(JDDDD)J
.end method

.method private static native setInputSize_0(JDD)J
.end method

.method private static native setInputSize_1(JII)J
.end method

.method private static native setInputSwapRB_0(JZ)J
.end method

.method private static native setOutputNames_0(JLjava/util/List;)J
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)J"
        }
    .end annotation
.end method

.method private static native setPreferableBackend_0(JI)J
.end method

.method private static native setPreferableTarget_0(JI)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 284
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/Model;->delete(J)V

    return-void
.end method
