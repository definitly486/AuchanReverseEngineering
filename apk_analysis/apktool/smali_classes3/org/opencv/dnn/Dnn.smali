.class public Lorg/opencv/dnn/Dnn;
.super Ljava/lang/Object;
.source "Dnn.java"


# direct methods
.method private static native NMSBoxesBatched_0(JJJFFJFI)V
.end method

.method private static native NMSBoxesBatched_1(JJJFFJF)V
.end method

.method private static native NMSBoxesBatched_2(JJJFFJ)V
.end method

.method private static native NMSBoxesRotated_0(JJFFJFI)V
.end method

.method private static native NMSBoxesRotated_1(JJFFJF)V
.end method

.method private static native NMSBoxesRotated_2(JJFFJ)V
.end method

.method private static native NMSBoxes_0(JJFFJFI)V
.end method

.method private static native NMSBoxes_1(JJFFJF)V
.end method

.method private static native NMSBoxes_2(JJFFJ)V
.end method

.method private static native blobFromImageWithParams_0(JJ)J
.end method

.method private static native blobFromImageWithParams_1(J)J
.end method

.method private static native blobFromImageWithParams_2(JJJ)V
.end method

.method private static native blobFromImageWithParams_3(JJ)V
.end method

.method private static native blobFromImage_0(JDDDDDDDZZI)J
.end method

.method private static native blobFromImage_1(JDDDDDDDZZ)J
.end method

.method private static native blobFromImage_2(JDDDDDDDZ)J
.end method

.method private static native blobFromImage_3(JDDDDDDD)J
.end method

.method private static native blobFromImage_4(JDDD)J
.end method

.method private static native blobFromImage_5(JD)J
.end method

.method private static native blobFromImage_6(J)J
.end method

.method private static native blobFromImagesWithParams_0(JJ)J
.end method

.method private static native blobFromImagesWithParams_1(J)J
.end method

.method private static native blobFromImagesWithParams_2(JJJ)V
.end method

.method private static native blobFromImagesWithParams_3(JJ)V
.end method

.method private static native blobFromImages_0(JDDDDDDDZZI)J
.end method

.method private static native blobFromImages_1(JDDDDDDDZZ)J
.end method

.method private static native blobFromImages_2(JDDDDDDDZ)J
.end method

.method private static native blobFromImages_3(JDDDDDDD)J
.end method

.method private static native blobFromImages_4(JDDD)J
.end method

.method private static native blobFromImages_5(JD)J
.end method

.method private static native blobFromImages_6(J)J
.end method

.method private static native getAvailableTargets_0(I)Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native getInferenceEngineBackendType_0()Ljava/lang/String;
.end method

.method private static native getInferenceEngineCPUType_0()Ljava/lang/String;
.end method

.method private static native getInferenceEngineVPUType_0()Ljava/lang/String;
.end method

.method private static native imagesFromBlob_0(JJ)V
.end method

.method private static native readNetFromCaffe_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNetFromCaffe_1(Ljava/lang/String;)J
.end method

.method private static native readNetFromCaffe_2(JJ)J
.end method

.method private static native readNetFromCaffe_3(J)J
.end method

.method private static native readNetFromDarknet_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNetFromDarknet_1(Ljava/lang/String;)J
.end method

.method private static native readNetFromDarknet_2(JJ)J
.end method

.method private static native readNetFromDarknet_3(J)J
.end method

.method private static native readNetFromModelOptimizer_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNetFromModelOptimizer_1(Ljava/lang/String;)J
.end method

.method private static native readNetFromModelOptimizer_2(JJ)J
.end method

.method private static native readNetFromONNX_0(Ljava/lang/String;)J
.end method

.method private static native readNetFromONNX_1(J)J
.end method

.method private static native readNetFromTFLite_0(Ljava/lang/String;)J
.end method

.method private static native readNetFromTFLite_1(J)J
.end method

.method private static native readNetFromTensorflow_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNetFromTensorflow_1(Ljava/lang/String;)J
.end method

.method private static native readNetFromTensorflow_2(JJ)J
.end method

.method private static native readNetFromTensorflow_3(J)J
.end method

.method private static native readNetFromTorch_0(Ljava/lang/String;ZZ)J
.end method

.method private static native readNetFromTorch_1(Ljava/lang/String;Z)J
.end method

.method private static native readNetFromTorch_2(Ljava/lang/String;)J
.end method

.method private static native readNet_0(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNet_1(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native readNet_2(Ljava/lang/String;)J
.end method

.method private static native readNet_3(Ljava/lang/String;JJ)J
.end method

.method private static native readNet_4(Ljava/lang/String;J)J
.end method

.method private static native readTensorFromONNX_0(Ljava/lang/String;)J
.end method

.method private static native readTorchBlob_0(Ljava/lang/String;Z)J
.end method

.method private static native readTorchBlob_1(Ljava/lang/String;)J
.end method

.method private static native releaseHDDLPlugin_0()V
.end method

.method private static native resetMyriadDevice_0()V
.end method

.method private static native setInferenceEngineBackendType_0(Ljava/lang/String;)Ljava/lang/String;
.end method

.method private static native shrinkCaffeModel_0(Ljava/lang/String;Ljava/lang/String;Ljava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native shrinkCaffeModel_1(Ljava/lang/String;Ljava/lang/String;)V
.end method

.method private static native softNMSBoxes_0(JJJFFJJF)V
.end method

.method private static native softNMSBoxes_2(JJJFFJJ)V
.end method

.method private static native softNMSBoxes_3(JJJFFJ)V
.end method

.method private static native writeTextGraph_0(Ljava/lang/String;Ljava/lang/String;)V
.end method
