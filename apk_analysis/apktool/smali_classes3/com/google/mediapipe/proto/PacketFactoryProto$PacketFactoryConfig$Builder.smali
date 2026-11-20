.class public final Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "PacketFactoryProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 732
    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$200()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/proto/PacketFactoryProto$1;)V
    .locals 0

    .line 725
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearExternalOutput()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 959
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 960
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1000(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public clearOptions()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 1045
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1046
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1400(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public clearOutputSidePacket()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 878
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 879
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$700(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public clearPacketFactory()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 797
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 798
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$400(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 725
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalOutput()Ljava/lang/String;
    .locals 1

    .line 920
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getExternalOutput()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getExternalOutputBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 933
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getExternalOutputBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;
    .locals 1

    .line 999
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getOptions()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    move-result-object v0

    return-object v0
.end method

.method public getOutputSidePacket()Ljava/lang/String;
    .locals 1

    .line 839
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getOutputSidePacket()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getOutputSidePacketBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 852
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getOutputSidePacketBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getPacketFactory()Ljava/lang/String;
    .locals 1

    .line 758
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getPacketFactory()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPacketFactoryBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 771
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getPacketFactoryBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasExternalOutput()Z
    .locals 1

    .line 908
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->hasExternalOutput()Z

    move-result v0

    return v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 988
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->hasOptions()Z

    move-result v0

    return v0
.end method

.method public hasOutputSidePacket()Z
    .locals 1

    .line 827
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->hasOutputSidePacket()Z

    move-result v0

    return v0
.end method

.method public hasPacketFactory()Z
    .locals 1

    .line 746
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->hasPacketFactory()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 725
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 725
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 1034
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1035
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1300(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V

    return-object p0
.end method

.method public setExternalOutput(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 946
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 947
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$900(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setExternalOutputBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 974
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 975
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1100(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions$Builder;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 1022
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1023
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1200(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V

    return-object p0
.end method

.method public setOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 1009
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1010
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$1200(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V

    return-object p0
.end method

.method public setOutputSidePacket(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 865
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 866
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$600(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 893
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 894
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$800(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setPacketFactory(Ljava/lang/String;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 784
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 785
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$300(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V

    return-object p0
.end method

.method public setPacketFactoryBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 812
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 813
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->access$500(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method
