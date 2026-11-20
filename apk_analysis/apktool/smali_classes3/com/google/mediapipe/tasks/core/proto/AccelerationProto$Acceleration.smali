.class public final Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "AccelerationProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$AccelerationOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/core/proto/AccelerationProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Acceleration"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$DelegateCase;,
        Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;",
        "Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$AccelerationOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

.field public static final GPU_FIELD_NUMBER:I = 0x2

.field public static final NNAPI_FIELD_NUMBER:I = 0x5

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;",
            ">;"
        }
    .end annotation
.end field

.field public static final TFLITE_FIELD_NUMBER:I = 0x4

.field public static final XNNPACK_FIELD_NUMBER:I = 0x1


# instance fields
.field private delegateCase_:I

.field private delegate_:Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 690
    new-instance v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;-><init>()V

    .line 693
    sput-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    .line 694
    const-class v1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 75
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x0

    .line 77
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 70
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->clearDelegate()V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->clearTflite()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->setNnapi(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->mergeNnapi(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->clearNnapi()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->setXnnpack(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->mergeXnnpack(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->clearXnnpack()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->setGpu(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->mergeGpu(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->clearGpu()V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->setTflite(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->mergeTflite(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V

    return-void
.end method

.method private clearDelegate()V
    .locals 1

    const/4 v0, 0x0

    .line 120
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v0, 0x0

    .line 121
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    return-void
.end method

.method private clearGpu()V
    .locals 2

    .line 218
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 219
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v0, 0x0

    .line 220
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearNnapi()V
    .locals 2

    .line 318
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 319
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v0, 0x0

    .line 320
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearTflite()V
    .locals 2

    .line 268
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 269
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v0, 0x0

    .line 270
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearXnnpack()V
    .locals 2

    .line 168
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 169
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v0, 0x0

    .line 170
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 699
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object v0
.end method

.method private mergeGpu(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V
    .locals 3

    .line 204
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 205
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 206
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 207
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;

    invoke-static {v0}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;->newBuilder(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu$Builder;

    move-result-object v0

    .line 208
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    goto :goto_0

    .line 210
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 212
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private mergeNnapi(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V
    .locals 3

    .line 304
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 305
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 306
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 307
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;

    invoke-static {v0}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;->newBuilder(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi$Builder;

    move-result-object v0

    .line 308
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    goto :goto_0

    .line 310
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 312
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private mergeTflite(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V
    .locals 3

    .line 254
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 255
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 256
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 257
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;

    invoke-static {v0}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;->newBuilder(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite$Builder;

    move-result-object v0

    .line 258
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    goto :goto_0

    .line 260
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 262
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private mergeXnnpack(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V
    .locals 3

    .line 154
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 155
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 156
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 157
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;

    invoke-static {v0}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;->newBuilder(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack$Builder;

    move-result-object v0

    .line 158
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    goto :goto_0

    .line 160
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    .line 162
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;
    .locals 1

    .line 401
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;
    .locals 1

    .line 404
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 377
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 384
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 340
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 347
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 389
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 396
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 364
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 371
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 327
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 334
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 352
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 359
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;",
            ">;"
        }
    .end annotation

    .line 705
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setGpu(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;)V
    .locals 0

    .line 196
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 197
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    const/4 p1, 0x2

    .line 198
    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private setNnapi(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;)V
    .locals 0

    .line 296
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 297
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    const/4 p1, 0x5

    .line 298
    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private setTflite(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;)V
    .locals 0

    .line 246
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 247
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    const/4 p1, 0x4

    .line 248
    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method

.method private setXnnpack(Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;)V
    .locals 0

    .line 146
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 147
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    const/4 p1, 0x1

    .line 148
    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 636
    sget-object p2, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 683
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 677
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 662
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 664
    const-class p2, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    monitor-enter p2

    .line 665
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 667
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 670
    sput-object p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    .line 672
    :cond_0
    :goto_0
    monitor-exit p2

    return-object p1

    :goto_1
    monitor-exit p2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_1
    return-object p1

    .line 659
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    return-object p1

    .line 644
    :pswitch_4
    const-string v0, "delegate_"

    const-string v1, "delegateCase_"

    const-class v2, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;

    const-class v3, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;

    const-class v4, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;

    const-class v5, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;

    filled-new-array/range {v0 .. v5}, [Ljava/lang/Object;

    move-result-object p1

    .line 652
    const-string p2, "\u0001\u0004\u0001\u0000\u0001\u0005\u0004\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000\u0004<\u0000\u0005<\u0000"

    .line 655
    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 641
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;-><init>(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$1;)V

    return-object p1

    .line 638
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;-><init>()V

    return-object p1

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 70
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getDelegateCase()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$DelegateCase;
    .locals 1

    .line 115
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$DelegateCase;->forNumber(I)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$DelegateCase;

    move-result-object v0

    return-object v0
.end method

.method public getGpu()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;
    .locals 2

    .line 187
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    .line 188
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;

    return-object v0

    .line 190
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Gpu;

    move-result-object v0

    return-object v0
.end method

.method public getNnapi()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;
    .locals 2

    .line 287
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    .line 288
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;

    return-object v0

    .line 290
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Nnapi;

    move-result-object v0

    return-object v0
.end method

.method public getTflite()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;
    .locals 2

    .line 237
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    .line 238
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;

    return-object v0

    .line 240
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$TfLite;

    move-result-object v0

    return-object v0
.end method

.method public getXnnpack()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;
    .locals 2

    .line 137
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 138
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegate_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;

    return-object v0

    .line 140
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;->getDefaultInstance()Lcom/google/mediapipe/calculator/proto/InferenceCalculatorProto$InferenceCalculatorOptions$Delegate$Xnnpack;

    move-result-object v0

    return-object v0
.end method

.method public hasGpu()Z
    .locals 2

    .line 180
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasNnapi()Z
    .locals 2

    .line 280
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasTflite()Z
    .locals 2

    .line 230
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasXnnpack()Z
    .locals 2

    .line 130
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->delegateCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 70
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 70
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
