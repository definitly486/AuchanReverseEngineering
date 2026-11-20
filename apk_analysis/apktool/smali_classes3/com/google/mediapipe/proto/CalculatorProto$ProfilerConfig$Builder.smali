.class public final Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfigOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 4707
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$4700()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V
    .locals 0

    .line 4700
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllTraceEventTypesDisabled(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Integer;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;"
        }
    .end annotation

    .line 5112
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5113
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addTraceEventTypesDisabled(I)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5097
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5098
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearCalculatorFilter()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5606
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5607
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearEnableInputOutputLatency()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 4850
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4851
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearEnableProfiler()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4890
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4891
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearEnableStreamLatency()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4936
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4937
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearHistogramIntervalSizeUsec()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4752
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4753
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$4900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearNumHistogramIntervals()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4795
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4796
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceEnabled()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5509
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5510
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceEventTypesDisabled()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5125
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5126
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogCapacity()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5028
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5029
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogCount()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5245
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5246
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogDisabled()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5469
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5470
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogDurationEvents()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 5380
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5381
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogInstantEvents()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5552
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5553
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogIntervalCount()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5426
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5427
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogIntervalUsec()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5288
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5289
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogMarginUsec()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5334
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5335
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearTraceLogPath()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5183
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5184
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public clearUsePacketTimestampForAddedPacket()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4985
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4986
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public getCalculatorFilter()Ljava/lang/String;
    .locals 1

    .line 5567
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getCalculatorFilter()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getCalculatorFilterBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 5580
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getCalculatorFilterBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 4700
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getEnableInputOutputLatency()Z
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 4815
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getEnableInputOutputLatency()Z

    move-result v0

    return v0
.end method

.method public getEnableProfiler()Z
    .locals 1

    .line 4865
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getEnableProfiler()Z

    move-result v0

    return v0
.end method

.method public getEnableStreamLatency()Z
    .locals 1

    .line 4907
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getEnableStreamLatency()Z

    move-result v0

    return v0
.end method

.method public getHistogramIntervalSizeUsec()J
    .locals 2

    .line 4723
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getHistogramIntervalSizeUsec()J

    move-result-wide v0

    return-wide v0
.end method

.method public getNumHistogramIntervals()J
    .locals 2

    .line 4768
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getNumHistogramIntervals()J

    move-result-wide v0

    return-wide v0
.end method

.method public getTraceEnabled()Z
    .locals 1

    .line 5484
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceEnabled()Z

    move-result v0

    return v0
.end method

.method public getTraceEventTypesDisabled(I)I
    .locals 1

    .line 5070
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceEventTypesDisabled(I)I

    move-result p1

    return p1
.end method

.method public getTraceEventTypesDisabledCount()I
    .locals 1

    .line 5057
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceEventTypesDisabledCount()I

    move-result v0

    return v0
.end method

.method public getTraceEventTypesDisabledList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation

    .line 5044
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 5045
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceEventTypesDisabledList()Ljava/util/List;

    move-result-object v0

    .line 5044
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getTraceLogCapacity()J
    .locals 2

    .line 5001
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogCapacity()J

    move-result-wide v0

    return-wide v0
.end method

.method public getTraceLogCount()I
    .locals 1

    .line 5216
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogCount()I

    move-result v0

    return v0
.end method

.method public getTraceLogDisabled()Z
    .locals 1

    .line 5442
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogDisabled()Z

    move-result v0

    return v0
.end method

.method public getTraceLogDurationEvents()Z
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 5351
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogDurationEvents()Z

    move-result v0

    return v0
.end method

.method public getTraceLogInstantEvents()Z
    .locals 1

    .line 5525
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogInstantEvents()Z

    move-result v0

    return v0
.end method

.method public getTraceLogIntervalCount()I
    .locals 1

    .line 5397
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogIntervalCount()I

    move-result v0

    return v0
.end method

.method public getTraceLogIntervalUsec()J
    .locals 2

    .line 5261
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogIntervalUsec()J

    move-result-wide v0

    return-wide v0
.end method

.method public getTraceLogMarginUsec()J
    .locals 2

    .line 5305
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogMarginUsec()J

    move-result-wide v0

    return-wide v0
.end method

.method public getTraceLogPath()Ljava/lang/String;
    .locals 1

    .line 5141
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogPath()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getTraceLogPathBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 5155
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogPathBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getUsePacketTimestampForAddedPacket()Z
    .locals 1

    .line 4954
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getUsePacketTimestampForAddedPacket()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 4700
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 4700
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public setCalculatorFilter(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5593
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5594
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setCalculatorFilterBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5621
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5622
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setEnableInputOutputLatency(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 4832
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4833
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setEnableProfiler(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4877
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4878
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setEnableStreamLatency(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4921
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4922
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setHistogramIntervalSizeUsec(J)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4737
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4738
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$4800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V

    return-object p0
.end method

.method public setNumHistogramIntervals(J)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4781
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4782
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V

    return-object p0
.end method

.method public setTraceEnabled(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5496
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5497
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setTraceEventTypesDisabled(II)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5083
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5084
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;II)V

    return-object p0
.end method

.method public setTraceLogCapacity(J)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5014
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5015
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V

    return-object p0
.end method

.method public setTraceLogCount(I)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5230
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5231
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V

    return-object p0
.end method

.method public setTraceLogDisabled(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5455
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5456
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setTraceLogDurationEvents(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 5365
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5366
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setTraceLogInstantEvents(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5538
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5539
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$8300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method

.method public setTraceLogIntervalCount(I)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5411
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5412
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V

    return-object p0
.end method

.method public setTraceLogIntervalUsec(J)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5274
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5275
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V

    return-object p0
.end method

.method public setTraceLogMarginUsec(J)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5319
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5320
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$7300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V

    return-object p0
.end method

.method public setTraceLogPath(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5169
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5170
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setTraceLogPathBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 5199
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 5200
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$6800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setUsePacketTimestampForAddedPacket(Z)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4969
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 4970
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->access$5800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V

    return-object p0
.end method
