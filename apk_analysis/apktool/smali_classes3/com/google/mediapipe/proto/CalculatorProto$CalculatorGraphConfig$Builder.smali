.class public final Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfigOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 13777
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16600()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V
    .locals 0

    .line 13770
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllExecutor(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 15781
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15782
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllGraphOptions(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/protobuf/Any;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 16254
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16255
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllInputSidePacket(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 15051
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15052
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllInputStream(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 14789
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14790
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllNode(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 13902
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13903
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllOutputSidePacket(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 15179
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15180
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllOutputStream(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 14923
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14924
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllPacketFactory(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 14082
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14083
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllPacketGenerator(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14338
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14339
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllStatusHandler(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;"
        }
    .end annotation

    .line 14630
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14631
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15762
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15763
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 15764
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    .line 15763
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public addExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15726
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15727
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public addExecutor(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15744
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15745
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public addExecutor(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15708
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15709
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public addGraphOptions(ILcom/google/protobuf/Any$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16240
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16241
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 16242
    invoke-virtual {p2}, Lcom/google/protobuf/Any$Builder;->build()Lcom/google/protobuf/Any;

    move-result-object p2

    .line 16241
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public addGraphOptions(ILcom/google/protobuf/Any;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16214
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16215
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public addGraphOptions(Lcom/google/protobuf/Any$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16227
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16228
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/Any$Builder;->build()Lcom/google/protobuf/Any;

    move-result-object p1

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public addGraphOptions(Lcom/google/protobuf/Any;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16201
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16202
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public addInputSidePacket(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15036
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15037
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15079
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15080
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addInputStream(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14771
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14772
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addInputStreamBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14823
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14824
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13888
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13889
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 13890
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    .line 13889
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public addNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13862
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13863
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public addNode(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13875
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13876
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public addNode(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13849
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13850
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public addOutputSidePacket(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15164
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15165
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15207
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15208
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addOutputStream(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14908
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14909
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addOutputStreamBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14951
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14952
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14065
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14066
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14067
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    .line 14066
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public addPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14033
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14034
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public addPacketFactory(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14049
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14050
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public addPacketFactory(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14017
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14018
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public addPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14314
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14315
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14316
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 14315
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public addPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14268
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14269
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public addPacketGenerator(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14291
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14292
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public addPacketGenerator(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14245
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14246
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public addStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14609
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14610
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14611
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    .line 14610
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public addStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14569
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14570
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public addStatusHandler(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14589
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14590
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public addStatusHandler(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14549
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14550
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearExecutor()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15798
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15799
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearGraphOptions()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16266
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16267
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearInputSidePacket()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15064
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15065
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearInputStream()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14805
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14806
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearInputStreamHandler()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15522
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15523
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearMaxQueueSize()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15280
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15281
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearNode()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13914
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13915
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearNumThreads()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14434
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14435
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearOptions()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16128
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16129
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearOutputSidePacket()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15192
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15193
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearOutputStream()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14936
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14937
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearOutputStreamHandler()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15605
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15606
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearPackage()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15966
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15967
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearPacketFactory()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14097
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14098
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearPacketGenerator()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14360
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14361
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearProfilerConfig()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15904
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15905
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearReportDeadlock()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15326
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15327
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearRuntimeInfo()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15403
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15404
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearStatusHandler()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14649
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14650
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public clearType()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16041
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16042
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 13770
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExecutor(I)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 15656
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getExecutor(I)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    move-result-object p1

    return-object p1
.end method

.method public getExecutorCount()I
    .locals 1

    .line 15641
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getExecutorCount()I

    move-result v0

    return v0
.end method

.method public getExecutorList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;"
        }
    .end annotation

    .line 15624
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 15625
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getExecutorList()Ljava/util/List;

    move-result-object v0

    .line 15624
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getGraphOptions(I)Lcom/google/protobuf/Any;
    .locals 1

    .line 16164
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getGraphOptions(I)Lcom/google/protobuf/Any;

    move-result-object p1

    return-object p1
.end method

.method public getGraphOptionsCount()I
    .locals 1

    .line 16154
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getGraphOptionsCount()I

    move-result v0

    return v0
.end method

.method public getGraphOptionsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/protobuf/Any;",
            ">;"
        }
    .end annotation

    .line 16142
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 16143
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getGraphOptionsList()Ljava/util/List;

    move-result-object v0

    .line 16142
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 14993
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputSidePacket(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 15007
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 14980
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputSidePacketCount()I

    move-result v0

    return v0
.end method

.method public getInputSidePacketList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 14967
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14968
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputSidePacketList()Ljava/util/List;

    move-result-object v0

    .line 14967
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getInputStream(I)Ljava/lang/String;
    .locals 1

    .line 14719
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputStream(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getInputStreamBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 14736
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputStreamBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputStreamCount()I
    .locals 1

    .line 14703
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputStreamCount()I

    move-result v0

    return v0
.end method

.method public getInputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 15444
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    move-result-object v0

    return-object v0
.end method

.method public getInputStreamList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 14687
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14688
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getInputStreamList()Ljava/util/List;

    move-result-object v0

    .line 14687
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getMaxQueueSize()I
    .locals 1

    .line 15233
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getMaxQueueSize()I

    move-result v0

    return v0
.end method

.method public getNode(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;
    .locals 1

    .line 13812
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getNode(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    move-result-object p1

    return-object p1
.end method

.method public getNodeCount()I
    .locals 1

    .line 13802
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getNodeCount()I

    move-result v0

    return v0
.end method

.method public getNodeList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;",
            ">;"
        }
    .end annotation

    .line 13790
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 13791
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getNodeList()Ljava/util/List;

    move-result-object v0

    .line 13790
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getNumThreads()I
    .locals 1

    .line 14401
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getNumThreads()I

    move-result v0

    return v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 16082
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    return-object v0
.end method

.method public getOutputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 15121
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputSidePacket(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 15135
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketCount()I
    .locals 1

    .line 15108
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputSidePacketCount()I

    move-result v0

    return v0
.end method

.method public getOutputSidePacketList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 15095
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 15096
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputSidePacketList()Ljava/util/List;

    move-result-object v0

    .line 15095
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getOutputStream(I)Ljava/lang/String;
    .locals 1

    .line 14865
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputStream(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getOutputStreamBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 14879
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputStreamBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputStreamCount()I
    .locals 1

    .line 14852
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputStreamCount()I

    move-result v0

    return v0
.end method

.method public getOutputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 15551
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    move-result-object v0

    return-object v0
.end method

.method public getOutputStreamList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 14839
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14840
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getOutputStreamList()Ljava/util/List;

    move-result-object v0

    .line 14839
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getPackage()Ljava/lang/String;
    .locals 1

    .line 15921
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPackage()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPackageBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 15936
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPackageBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getPacketFactory(I)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 13971
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketFactory(I)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    move-result-object p1

    return-object p1
.end method

.method public getPacketFactoryCount()I
    .locals 1

    .line 13958
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketFactoryCount()I

    move-result v0

    return v0
.end method

.method public getPacketFactoryList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;"
        }
    .end annotation

    .line 13943
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 13944
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketFactoryList()Ljava/util/List;

    move-result-object v0

    .line 13943
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getPacketGenerator(I)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14178
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketGenerator(I)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    move-result-object p1

    return-object p1
.end method

.method public getPacketGeneratorCount()I
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14158
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketGeneratorCount()I

    move-result v0

    return v0
.end method

.method public getPacketGeneratorList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;"
        }
    .end annotation

    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14136
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14137
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPacketGeneratorList()Ljava/util/List;

    move-result-object v0

    .line 14136
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getProfilerConfig()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 15846
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getProfilerConfig()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v0

    return-object v0
.end method

.method public getReportDeadlock()Z
    .locals 1

    .line 15297
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getReportDeadlock()Z

    move-result v0

    return v0
.end method

.method public getRuntimeInfo()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 15353
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getRuntimeInfo()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    move-result-object v0

    return-object v0
.end method

.method public getStatusHandler(I)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 14491
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getStatusHandler(I)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    move-result-object p1

    return-object p1
.end method

.method public getStatusHandlerCount()I
    .locals 1

    .line 14474
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getStatusHandlerCount()I

    move-result v0

    return v0
.end method

.method public getStatusHandlerList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;"
        }
    .end annotation

    .line 14455
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14456
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getStatusHandlerList()Ljava/util/List;

    move-result-object v0

    .line 14455
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getType()Ljava/lang/String;
    .locals 1

    .line 15999
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getType()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getTypeBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 16013
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getTypeBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasInputStreamHandler()Z
    .locals 1

    .line 15425
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->hasInputStreamHandler()Z

    move-result v0

    return v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 16071
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->hasOptions()Z

    move-result v0

    return v0
.end method

.method public hasOutputStreamHandler()Z
    .locals 1

    .line 15538
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->hasOutputStreamHandler()Z

    move-result v0

    return v0
.end method

.method public hasProfilerConfig()Z
    .locals 1

    .line 15832
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->hasProfilerConfig()Z

    move-result v0

    return v0
.end method

.method public hasRuntimeInfo()Z
    .locals 1

    .line 15341
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->hasRuntimeInfo()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 13770
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 13770
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15503
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15504
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V

    return-object p0
.end method

.method public mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16117
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16118
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-object p0
.end method

.method public mergeOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15592
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15593
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V

    return-object p0
.end method

.method public mergeProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15890
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15891
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public mergeRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15391
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15392
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V

    return-object p0
.end method

.method public removeExecutor(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15815
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15816
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public removeGraphOptions(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16278
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16279
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public removeNode(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13926
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13927
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public removePacketFactory(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14112
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14113
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public removePacketGenerator(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14382
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14383
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public removeStatusHandler(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14668
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14669
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public setExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15690
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15691
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 15692
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    .line 15691
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public setExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15672
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15673
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-object p0
.end method

.method public setGraphOptions(ILcom/google/protobuf/Any$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16188
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16189
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 16190
    invoke-virtual {p2}, Lcom/google/protobuf/Any$Builder;->build()Lcom/google/protobuf/Any;

    move-result-object p2

    .line 16189
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public setGraphOptions(ILcom/google/protobuf/Any;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16175
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16176
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V

    return-object p0
.end method

.method public setInputSidePacket(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15021
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15022
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setInputStream(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14753
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14754
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15483
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15484
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V

    return-object p0
.end method

.method public setInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15462
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15463
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V

    return-object p0
.end method

.method public setMaxQueueSize(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15256
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15257
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public setNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13836
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13837
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 13838
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    .line 13837
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public setNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13823
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13824
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$16700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-object p0
.end method

.method public setNumThreads(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14417
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14418
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16105
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16106
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16092
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16093
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-object p0
.end method

.method public setOutputSidePacket(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15149
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15150
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$20800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setOutputStream(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14893
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14894
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$19800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15578
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15579
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V

    return-object p0
.end method

.method public setOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15563
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15564
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$22300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V

    return-object p0
.end method

.method public setPackage(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15951
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15952
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setPackageBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15983
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15984
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14001
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14002
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14003
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    .line 14002
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public setPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13985
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 13986
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public setPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14222
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14223
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14224
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 14223
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public setPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 14199
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14200
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$17900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public setProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15875
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15876
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public setProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15859
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15860
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-object p0
.end method

.method public setReportDeadlock(Z)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15311
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15312
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Z)V

    return-object p0
.end method

.method public setRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15378
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15379
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V

    return-object p0
.end method

.method public setRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 15364
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 15365
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$21700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V

    return-object p0
.end method

.method public setStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14529
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14530
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 14531
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    .line 14530
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public setStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 14509
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 14510
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$18700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-object p0
.end method

.method public setType(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16027
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16028
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$23800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setTypeBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 16057
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 16058
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->access$24000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method
