.class public final Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;
.super Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;
.source "InteractiveSegmenter.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;,
        Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;
    }
.end annotation


# static fields
.field private static final IMAGE_IN_STREAM_NAME:Ljava/lang/String; = "image_in"

.field private static final INPUT_STREAMS:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final NORM_RECT_IN_STREAM_NAME:Ljava/lang/String; = "norm_rect_in"

.field private static final ROI_IN_STREAM_NAME:Ljava/lang/String; = "roi_in"

.field private static final TAG:Ljava/lang/String; = "InteractiveSegmenter"

.field private static final TASK_GRAPH_NAME:Ljava/lang/String; = "mediapipe.tasks.vision.interactive_segmenter.InteractiveSegmenterGraph"

.field private static final TENSORS_TO_SEGMENTATION_CALCULATOR_NAME:Ljava/lang/String; = "mediapipe.tasks.TensorsToSegmentationCalculator"


# instance fields
.field private hasResultListener:Z

.field private labels:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 89
    const-string v0, "ROI:roi_in"

    const-string v1, "NORM_RECT:norm_rect_in"

    const-string v2, "IMAGE:image_in"

    filled-new-array {v2, v0, v1}, [Ljava/lang/String;

    move-result-object v0

    .line 91
    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    .line 90
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->INPUT_STREAMS:Ljava/util/List;

    .line 104
    const-string v0, "mediapipe_tasks_vision_jni"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 105
    const-class v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;

    const-string v1, "mediapipe.tasks.vision.interactive_segmenter.proto.RegionOfInterest"

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/ProtoUtil;->registerTypeName(Ljava/lang/Class;Ljava/lang/String;)V

    return-void
.end method

.method private constructor <init>(Lcom/google/mediapipe/tasks/core/TaskRunner;Z)V
    .locals 3

    .line 255
    sget-object v0, Lcom/google/mediapipe/tasks/vision/core/RunningMode;->IMAGE:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    const-string v1, "image_in"

    const-string v2, "norm_rect_in"

    invoke-direct {p0, p1, v0, v1, v2}, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;-><init>(Lcom/google/mediapipe/tasks/core/TaskRunner;Lcom/google/mediapipe/tasks/vision/core/RunningMode;Ljava/lang/String;Ljava/lang/String;)V

    const/4 p1, 0x0

    .line 100
    iput-boolean p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->hasResultListener:Z

    .line 101
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->labels:Ljava/util/List;

    .line 256
    iput-boolean p2, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->hasResultListener:Z

    .line 257
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->populateLabels()V

    return-void
.end method

.method private static convertToRegionOfInterest(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;
    .locals 5

    .line 556
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;->newBuilder()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$Builder;

    move-result-object v0

    .line 558
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;->access$000(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 561
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->newBuilder()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object v1

    .line 562
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;->access$000(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;->x()F

    move-result v2

    invoke-virtual {v1, v2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;->setX(F)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object v1

    .line 563
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;->access$000(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;

    move-result-object p0

    invoke-virtual {p0}, Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;->y()F

    move-result p0

    invoke-virtual {v1, p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;->setY(F)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object p0

    .line 560
    invoke-virtual {v0, p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$Builder;->setKeypoint(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$Builder;

    move-result-object p0

    .line 564
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;

    return-object p0

    .line 565
    :cond_0
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;->access$100(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Ljava/util/List;

    move-result-object v1

    if-eqz v1, :cond_2

    .line 567
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Scribble;->newBuilder()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Scribble$Builder;

    move-result-object v1

    .line 568
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;->access$100(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Ljava/util/List;

    move-result-object p0

    invoke-interface {p0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p0

    :goto_0
    invoke-interface {p0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-interface {p0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;

    .line 569
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->newBuilder()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object v3

    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;->x()F

    move-result v4

    invoke-virtual {v3, v4}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;->setX(F)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object v3

    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/components/containers/NormalizedKeypoint;->y()F

    move-result v2

    invoke-virtual {v3, v2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;->setY(F)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Scribble$Builder;->addPoint(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Scribble$Builder;

    goto :goto_0

    .line 571
    :cond_1
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$Builder;->setScribble(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Scribble$Builder;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$Builder;

    move-result-object p0

    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;

    return-object p0

    .line 574
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string v0, "RegionOfInterest does not include a valid user interaction"

    invoke-direct {p0, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static createFromOptions(Landroid/content/Context;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;
    .locals 8

    .line 119
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->outputConfidenceMasks()Z

    move-result v0

    if-nez v0, :cond_1

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->outputCategoryMask()Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 120
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "At least one of `outputConfidenceMasks` and `outputCategoryMask` must be set."

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 123
    :cond_1
    :goto_0
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 124
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->outputConfidenceMasks()Z

    move-result v1

    if-eqz v1, :cond_2

    .line 125
    const-string v1, "CONFIDENCE_MASKS:confidence_masks"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 127
    :cond_2
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v5, v1, -0x1

    .line 128
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->outputCategoryMask()Z

    move-result v1

    if-eqz v1, :cond_3

    .line 129
    const-string v1, "CATEGORY_MASK:category_mask"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 131
    :cond_3
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v6, v1, -0x1

    .line 133
    const-string v1, "QUALITY_SCORES:quality_scores"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 134
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v7, v1, -0x1

    .line 136
    const-string v1, "IMAGE:image_out"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 138
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v3, v1, -0x1

    .line 141
    new-instance v1, Lcom/google/mediapipe/tasks/core/OutputHandler;

    invoke-direct {v1}, Lcom/google/mediapipe/tasks/core/OutputHandler;-><init>()V

    .line 142
    new-instance v2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$1;

    move-object v4, p1

    invoke-direct/range {v2 .. v7}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$1;-><init>(ILcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;III)V

    invoke-virtual {v1, v2}, Lcom/google/mediapipe/tasks/core/OutputHandler;->setOutputPacketConverter(Lcom/google/mediapipe/tasks/core/OutputHandler$OutputPacketConverter;)V

    .line 231
    invoke-virtual {v4}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->resultListener()Ljava/util/Optional;

    move-result-object p1

    new-instance v2, Lcom/google/mediapipe/tasks/vision/facedetector/FaceDetector$$ExternalSyntheticLambda0;

    invoke-direct {v2, v1}, Lcom/google/mediapipe/tasks/vision/facedetector/FaceDetector$$ExternalSyntheticLambda0;-><init>(Lcom/google/mediapipe/tasks/core/OutputHandler;)V

    invoke-virtual {p1, v2}, Ljava/util/Optional;->ifPresent(Ljava/util/function/Consumer;)V

    .line 232
    invoke-virtual {v4}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->errorListener()Ljava/util/Optional;

    move-result-object p1

    new-instance v2, Lcom/google/mediapipe/tasks/vision/facedetector/FaceDetector$$ExternalSyntheticLambda1;

    invoke-direct {v2, v1}, Lcom/google/mediapipe/tasks/vision/facedetector/FaceDetector$$ExternalSyntheticLambda1;-><init>(Lcom/google/mediapipe/tasks/core/OutputHandler;)V

    invoke-virtual {p1, v2}, Ljava/util/Optional;->ifPresent(Ljava/util/function/Consumer;)V

    .line 236
    invoke-static {}, Lcom/google/mediapipe/tasks/core/TaskInfo;->builder()Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    const-class v2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;

    .line 237
    invoke-virtual {v2}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1, v2}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setTaskName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    sget-object v2, Lcom/google/mediapipe/tasks/vision/core/RunningMode;->IMAGE:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    .line 238
    invoke-virtual {v2}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1, v2}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setTaskRunningModeName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    const-string v2, "mediapipe.tasks.vision.interactive_segmenter.InteractiveSegmenterGraph"

    .line 239
    invoke-virtual {p1, v2}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setTaskGraphName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    sget-object v2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->INPUT_STREAMS:Ljava/util/List;

    .line 240
    invoke-virtual {p1, v2}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setInputStreams(Ljava/util/List;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    .line 241
    invoke-virtual {p1, v0}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setOutputStreams(Ljava/util/List;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    .line 242
    invoke-virtual {p1, v4}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setTaskOptions(Lcom/google/mediapipe/tasks/core/TaskOptions;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    const/4 v0, 0x0

    .line 243
    invoke-virtual {p1, v0}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->setEnableFlowLimiting(Z)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;

    move-result-object p1

    .line 244
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;->build()Lcom/google/mediapipe/tasks/core/TaskInfo;

    move-result-object p1

    .line 234
    invoke-static {p0, p1, v1}, Lcom/google/mediapipe/tasks/core/TaskRunner;->create(Landroid/content/Context;Lcom/google/mediapipe/tasks/core/TaskInfo;Lcom/google/mediapipe/tasks/core/OutputHandler;)Lcom/google/mediapipe/tasks/core/TaskRunner;

    move-result-object p0

    .line 246
    new-instance p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;

    invoke-virtual {v4}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;->resultListener()Ljava/util/Optional;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/Optional;->isPresent()Z

    move-result v0

    invoke-direct {p1, p0, v0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;-><init>(Lcom/google/mediapipe/tasks/core/TaskRunner;Z)V

    return-object p1
.end method

.method private populateLabels()V
    .locals 7

    .line 266
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runner:Lcom/google/mediapipe/tasks/core/TaskRunner;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/TaskRunner;->getCalculatorGraphConfig()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    move-result-object v0

    .line 269
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getNodeList()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const/4 v1, 0x0

    move v2, v1

    :cond_0
    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_4

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    .line 270
    invoke-virtual {v3}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;->getName()Ljava/lang/String;

    move-result-object v4

    const-string v5, "mediapipe.tasks.TensorsToSegmentationCalculator"

    invoke-virtual {v4, v5}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    if-nez v2, :cond_3

    .line 278
    invoke-virtual {v3}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;->getOptions()Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;

    move-result-object v2

    sget-object v3, Lcom/google/mediapipe/tasks/TensorsToSegmentationCalculatorOptionsProto$TensorsToSegmentationCalculatorOptions;->ext:Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;

    .line 279
    invoke-virtual {v2, v3}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;->getExtension(Lcom/google/protobuf/ExtensionLite;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/mediapipe/tasks/TensorsToSegmentationCalculatorOptionsProto$TensorsToSegmentationCalculatorOptions;

    move v3, v1

    .line 282
    :goto_1
    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/TensorsToSegmentationCalculatorOptionsProto$TensorsToSegmentationCalculatorOptions;->getLabelItemsMap()Ljava/util/Map;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/Map;->size()I

    move-result v4

    if-ge v3, v4, :cond_2

    int-to-long v4, v3

    .line 283
    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    .line 284
    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/TensorsToSegmentationCalculatorOptionsProto$TensorsToSegmentationCalculatorOptions;->getLabelItemsMap()Ljava/util/Map;

    move-result-object v5

    invoke-interface {v5, v4}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 289
    iget-object v5, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->labels:Ljava/util/List;

    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/TensorsToSegmentationCalculatorOptionsProto$TensorsToSegmentationCalculatorOptions;->getLabelItemsMap()Ljava/util/Map;

    move-result-object v6

    invoke-interface {v6, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mediapipe/util/proto/LabelMapProto$LabelMapItem;

    invoke-virtual {v4}, Lcom/google/mediapipe/util/proto/LabelMapProto$LabelMapItem;->getName()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v5, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 285
    :cond_1
    new-instance v0, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object v1, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->INTERNAL:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 286
    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "The lablemap have no expected key: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw v0

    :cond_2
    const/4 v2, 0x1

    goto :goto_0

    .line 272
    :cond_3
    new-instance v0, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object v1, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->INTERNAL:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 273
    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    const-string v2, "The graph has more than one mediapipe.tasks.TensorsToSegmentationCalculator."

    invoke-direct {v0, v1, v2}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw v0

    :cond_4
    return-void
.end method

.method private processImageWithRoi(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;
    .locals 3

    .line 593
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runningMode:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    sget-object v1, Lcom/google/mediapipe/tasks/vision/core/RunningMode;->IMAGE:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    if-ne v0, v1, :cond_0

    .line 599
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 600
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runner:Lcom/google/mediapipe/tasks/core/TaskRunner;

    invoke-virtual {v1}, Lcom/google/mediapipe/tasks/core/TaskRunner;->getPacketCreator()Lcom/google/mediapipe/framework/AndroidPacketCreator;

    move-result-object v1

    invoke-virtual {v1, p1}, Lcom/google/mediapipe/framework/AndroidPacketCreator;->createImage(Lcom/google/mediapipe/framework/image/MPImage;)Lcom/google/mediapipe/framework/Packet;

    move-result-object v1

    const-string v2, "image_in"

    invoke-interface {v0, v2, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 601
    invoke-static {p2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->convertToRegionOfInterest(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;

    move-result-object p2

    .line 602
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runner:Lcom/google/mediapipe/tasks/core/TaskRunner;

    invoke-virtual {v1}, Lcom/google/mediapipe/tasks/core/TaskRunner;->getPacketCreator()Lcom/google/mediapipe/framework/AndroidPacketCreator;

    move-result-object v1

    invoke-virtual {v1, p2}, Lcom/google/mediapipe/framework/PacketCreator;->createProto(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p2

    const-string v1, "roi_in"

    invoke-interface {v0, v1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 603
    iget-object p2, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runner:Lcom/google/mediapipe/tasks/core/TaskRunner;

    .line 606
    invoke-virtual {p2}, Lcom/google/mediapipe/tasks/core/TaskRunner;->getPacketCreator()Lcom/google/mediapipe/framework/AndroidPacketCreator;

    move-result-object p2

    .line 607
    invoke-static {p3, p1}, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->convertToNormalizedRect(Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;Lcom/google/mediapipe/framework/image/MPImage;)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    move-result-object p1

    invoke-virtual {p2, p1}, Lcom/google/mediapipe/framework/PacketCreator;->createProto(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    .line 603
    const-string p2, "norm_rect_in"

    invoke-interface {v0, p2, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 608
    iget-object p1, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runner:Lcom/google/mediapipe/tasks/core/TaskRunner;

    invoke-virtual {p1, v0}, Lcom/google/mediapipe/tasks/core/TaskRunner;->process(Ljava/util/Map;)Lcom/google/mediapipe/tasks/core/TaskResult;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;

    return-object p1

    .line 594
    :cond_0
    new-instance p1, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object p2, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->FAILED_PRECONDITION:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 595
    invoke-virtual {p2}, Ljava/lang/Enum;->ordinal()I

    move-result p2

    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Task is not initialized with the image mode. Current running mode:"

    invoke-virtual {p3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->runningMode:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    .line 597
    invoke-virtual {v0}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p3

    invoke-direct {p1, p2, p3}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw p1
.end method

.method private static validateImageProcessingOptions(Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)V
    .locals 1

    .line 511
    invoke-virtual {p0}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->regionOfInterest()Ljava/util/Optional;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/Optional;->isPresent()Z

    move-result p0

    if-nez p0, :cond_0

    return-void

    .line 512
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string v0, "InteractiveSegmenter doesn\'t support region-of-interest."

    invoke-direct {p0, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method


# virtual methods
.method getLabels()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 427
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->labels:Ljava/util/List;

    return-object v0
.end method

.method public segment(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;
    .locals 1

    .line 315
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->builder()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;

    move-result-object v0

    invoke-virtual {p0, p1, p2, v0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->segment(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;

    move-result-object p1

    return-object p1
.end method

.method public segment(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;
    .locals 1

    .line 344
    iget-boolean v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->hasResultListener:Z

    if-nez v0, :cond_0

    .line 350
    invoke-static {p3}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->validateImageProcessingOptions(Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)V

    .line 351
    invoke-direct {p0, p1, p2, p3}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->processImageWithRoi(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;

    move-result-object p1

    return-object p1

    .line 345
    :cond_0
    new-instance p1, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object p2, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->FAILED_PRECONDITION:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 346
    invoke-virtual {p2}, Ljava/lang/Enum;->ordinal()I

    move-result p2

    const-string p3, "ResultListener is provided in the InteractiveSegmenterOptions, but this method will return an ImageSegmentationResult."

    invoke-direct {p1, p2, p3}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw p1
.end method

.method public segmentWithResultListener(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;)V
    .locals 1

    .line 378
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->builder()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;

    move-result-object v0

    invoke-virtual {p0, p1, p2, v0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->segmentWithResultListener(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)V

    return-void
.end method

.method public segmentWithResultListener(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)V
    .locals 1

    .line 409
    iget-boolean v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->hasResultListener:Z

    if-eqz v0, :cond_0

    .line 415
    invoke-static {p3}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->validateImageProcessingOptions(Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)V

    .line 416
    invoke-direct {p0, p1, p2, p3}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter;->processImageWithRoi(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$RegionOfInterest;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;

    return-void

    .line 410
    :cond_0
    new-instance p1, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object p2, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->FAILED_PRECONDITION:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 411
    invoke-virtual {p2}, Ljava/lang/Enum;->ordinal()I

    move-result p2

    const-string p3, "ResultListener is not set in the InteractiveSegmenterOptions, but this method expects a ResultListener to process ImageSegmentationResult."

    invoke-direct {p1, p2, p3}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw p1
.end method
