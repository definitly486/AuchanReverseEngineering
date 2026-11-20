.class public Lorg/opencv/dnn/Net;
.super Ljava/lang/Object;
.source "Net.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Net_0()J
.end method

.method private static native connect_0(JLjava/lang/String;Ljava/lang/String;)V
.end method

.method private static native delete(J)V
.end method

.method private static native dumpToFile_0(JLjava/lang/String;)V
.end method

.method private static native dumpToPbtxt_0(JLjava/lang/String;)V
.end method

.method private static native dump_0(J)Ljava/lang/String;
.end method

.method private static native empty_0(J)Z
.end method

.method private static native enableFusion_0(JZ)V
.end method

.method private static native enableWinograd_0(JZ)V
.end method

.method private static native forward_0(JLjava/lang/String;)J
.end method

.method private static native forward_1(J)J
.end method

.method private static native forward_2(JJLjava/lang/String;)V
.end method

.method private static native forward_3(JJ)V
.end method

.method private static native forward_4(JJLjava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native getFLOPS_0(JLjava/util/List;)J
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/Object;",
            ">;)J"
        }
    .end annotation
.end method

.method private static native getFLOPS_1(JJ)J
.end method

.method private static native getFLOPS_2(JILjava/util/List;)J
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JI",
            "Ljava/util/List<",
            "Ljava/lang/Object;",
            ">;)J"
        }
    .end annotation
.end method

.method private static native getFLOPS_3(JIJ)J
.end method

.method private static native getInputDetails_0(JJJ)V
.end method

.method private static native getLayerId_0(JLjava/lang/String;)I
.end method

.method private static native getLayerNames_0(J)Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J)",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end method

.method private static native getLayerTypes_0(JLjava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native getLayer_0(JI)J
.end method

.method private static native getLayer_1(JLjava/lang/String;)J
.end method

.method private static native getLayer_2(JJ)J
.end method

.method private static native getLayersCount_0(JLjava/lang/String;)I
.end method

.method private static native getMemoryConsumption_0(JJ[D[D)V
.end method

.method private static native getMemoryConsumption_1(JILjava/util/List;[D[D)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JI",
            "Ljava/util/List<",
            "Ljava/lang/Object;",
            ">;[D[D)V"
        }
    .end annotation
.end method

.method private static native getMemoryConsumption_2(JIJ[D[D)V
.end method

.method private static native getOutputDetails_0(JJJ)V
.end method

.method private static native getParam_0(JII)J
.end method

.method private static native getParam_1(JI)J
.end method

.method private static native getParam_2(JLjava/lang/String;I)J
.end method

.method private static native getParam_3(JLjava/lang/String;)J
.end method

.method private static native getPerfProfile_0(JJ)J
.end method

.method private static native getUnconnectedOutLayersNames_0(J)Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J)",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end method

.method private static native getUnconnectedOutLayers_0(J)J
.end method

.method private static native quantize_0(JJIIZ)J
.end method

.method private static native quantize_1(JJII)J
.end method

.method private static native readFromModelOptimizer_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readFromModelOptimizer_1(JJ)J
.end method

.method private static native registerOutput_0(JLjava/lang/String;II)I
.end method

.method private static native setHalideScheduler_0(JLjava/lang/String;)V
.end method

.method private static native setInputShape_0(JLjava/lang/String;J)V
.end method

.method private static native setInput_0(JJLjava/lang/String;DDDDD)V
.end method

.method private static native setInput_1(JJLjava/lang/String;D)V
.end method

.method private static native setInput_2(JJLjava/lang/String;)V
.end method

.method private static native setInput_3(JJ)V
.end method

.method private static native setInputsNames_0(JLjava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native setParam_0(JIIJ)V
.end method

.method private static native setParam_1(JLjava/lang/String;IJ)V
.end method

.method private static native setPreferableBackend_0(JI)V
.end method

.method private static native setPreferableTarget_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 839
    iget-wide v0, p0, Lorg/opencv/dnn/Net;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/dnn/Net;->delete(J)V

    return-void
.end method
