.class public Lorg/opencv/dnn/TextRecognitionModel;
.super Lorg/opencv/dnn/Model;
.source "TextRecognitionModel.java"


# direct methods
.method private static native TextRecognitionModel_0(J)J
.end method

.method private static native TextRecognitionModel_1(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native TextRecognitionModel_2(Ljava/lang/String;)J
.end method

.method private static native delete(J)V
.end method

.method private static native getDecodeType_0(J)Ljava/lang/String;
.end method

.method private static native getVocabulary_0(J)Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J)",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end method

.method private static native recognize_0(JJ)Ljava/lang/String;
.end method

.method private static native recognize_1(JJJLjava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native setDecodeOptsCTCPrefixBeamSearch_0(JII)J
.end method

.method private static native setDecodeOptsCTCPrefixBeamSearch_1(JI)J
.end method

.method private static native setDecodeType_0(JLjava/lang/String;)J
.end method

.method private static native setVocabulary_0(JLjava/util/List;)J
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)J"
        }
    .end annotation
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 182
    iget-wide v0, p0, Lorg/opencv/dnn/Model;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/TextRecognitionModel;->delete(J)V

    return-void
.end method
