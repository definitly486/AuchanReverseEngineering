.class public final Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "PacketGeneratorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1372
    invoke-static {}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$400()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/proto/PacketGeneratorProto$1;)V
    .locals 0

    .line 1365
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllExternalInput(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;"
        }
    .end annotation

    .line 1689
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1690
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllExternalOutput(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;"
        }
    .end annotation

    .line 1963
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1964
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllInputSidePacket(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;"
        }
    .end annotation

    .line 1559
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1560
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllOutputSidePacket(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;"
        }
    .end annotation

    .line 1831
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1832
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addExternalInput(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1674
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1675
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1400(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addExternalInputBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1717
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1718
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addExternalOutput(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1948
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1949
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2400(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addExternalOutputBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1991
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1992
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addInputSidePacket(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1543
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1544
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1589
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1590
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1200(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addOutputSidePacket(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1814
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1815
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1863
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1864
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2200(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearExternalInput()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1702
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1703
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public clearExternalOutput()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1976
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1977
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public clearInputSidePacket()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1573
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1574
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1100(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public clearOptions()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 2062
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2063
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$3000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public clearOutputSidePacket()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1846
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1847
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2100(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public clearPacketGenerator()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1437
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1438
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1365
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalInput(I)Ljava/lang/String;
    .locals 1

    .line 1631
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalInput(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1645
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalInputBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputCount()I
    .locals 1

    .line 1618
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalInputCount()I

    move-result v0

    return v0
.end method

.method public getExternalInputList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1605
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 1606
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalInputList()Ljava/util/List;

    move-result-object v0

    .line 1605
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getExternalOutput(I)Ljava/lang/String;
    .locals 1

    .line 1905
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalOutput(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getExternalOutputBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1919
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalOutputBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalOutputCount()I
    .locals 1

    .line 1892
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalOutputCount()I

    move-result v0

    return v0
.end method

.method public getExternalOutputList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1879
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 1880
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getExternalOutputList()Ljava/util/List;

    move-result-object v0

    .line 1879
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 1497
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getInputSidePacket(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1512
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 1483
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getInputSidePacketCount()I

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

    .line 1469
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 1470
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getInputSidePacketList()Ljava/util/List;

    move-result-object v0

    .line 1469
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 2016
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getOptions()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    move-result-object v0

    return-object v0
.end method

.method public getOutputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 1765
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getOutputSidePacket(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1781
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketCount()I
    .locals 1

    .line 1750
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getOutputSidePacketCount()I

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

    .line 1735
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 1736
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getOutputSidePacketList()Ljava/util/List;

    move-result-object v0

    .line 1735
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getPacketGenerator()Ljava/lang/String;
    .locals 1

    .line 1398
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getPacketGenerator()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPacketGeneratorBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1411
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getPacketGeneratorBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 2005
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->hasOptions()Z

    move-result v0

    return v0
.end method

.method public hasPacketGenerator()Z
    .locals 1

    .line 1386
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->hasPacketGenerator()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1365
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1365
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 2051
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2052
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V

    return-object p0
.end method

.method public setExternalInput(ILjava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1659
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1660
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1300(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setExternalOutput(ILjava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1933
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1934
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2300(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setInputSidePacket(ILjava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1527
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1528
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 2039
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2040
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 2026
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2027
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$2800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V

    return-object p0
.end method

.method public setOutputSidePacket(ILjava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1797
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1798
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$1800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V

    return-object p0
.end method

.method public setPacketGenerator(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1424
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1425
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setPacketGeneratorBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1452
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1453
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->access$700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method
