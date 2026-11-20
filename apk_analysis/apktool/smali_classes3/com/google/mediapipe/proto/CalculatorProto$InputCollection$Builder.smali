.class public final Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1862
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1100()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V
    .locals 0

    .line 1855
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllExternalInputName(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;"
        }
    .end annotation

    .line 2167
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2168
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2200(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllSidePacketName(Ljava/lang/Iterable;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;"
        }
    .end annotation

    .line 2037
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2038
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1700(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addExternalInputName(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2152
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2153
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2100(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V

    return-object p0
.end method

.method public addExternalInputNameBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2195
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2196
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2400(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addSidePacketName(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2021
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2022
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1600(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V

    return-object p0
.end method

.method public addSidePacketNameBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2067
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2068
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1900(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearExternalInputName()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2180
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2181
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2300(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-object p0
.end method

.method public clearFileName()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2328
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2329
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2900(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-object p0
.end method

.method public clearInputType()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2266
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2267
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2700(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-object p0
.end method

.method public clearName()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 1915
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1916
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1300(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-object p0
.end method

.method public clearSidePacketName()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2051
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2052
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1800(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1855
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalInputName(I)Ljava/lang/String;
    .locals 1

    .line 2109
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getExternalInputName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 2123
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getExternalInputNameBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputNameCount()I
    .locals 1

    .line 2096
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getExternalInputNameCount()I

    move-result v0

    return v0
.end method

.method public getExternalInputNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 2083
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    .line 2084
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getExternalInputNameList()Ljava/util/List;

    move-result-object v0

    .line 2083
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getFileName()Ljava/lang/String;
    .locals 1

    .line 2283
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getFileName()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getFileNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 2298
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getFileNameBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getInputType()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;
    .locals 1

    .line 2239
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getInputType()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;

    move-result-object v0

    return-object v0
.end method

.method public getInputTypeValue()I
    .locals 1

    .line 2211
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getInputTypeValue()I

    move-result v0

    return v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .line 1876
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getName()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1889
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getNameBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getSidePacketName(I)Ljava/lang/String;
    .locals 1

    .line 1975
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getSidePacketName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getSidePacketNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1990
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getSidePacketNameBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getSidePacketNameCount()I
    .locals 1

    .line 1961
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getSidePacketNameCount()I

    move-result v0

    return v0
.end method

.method public getSidePacketNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1947
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    .line 1948
    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getSidePacketNameList()Ljava/util/List;

    move-result-object v0

    .line 1947
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1855
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1855
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public setExternalInputName(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2137
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2138
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2000(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;ILjava/lang/String;)V

    return-object p0
.end method

.method public setFileName(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2313
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2314
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2800(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V

    return-object p0
.end method

.method public setFileNameBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2345
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2346
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$3000(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setInputType(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2252
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2253
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2600(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;)V

    return-object p0
.end method

.method public setInputTypeValue(I)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2224
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2225
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$2500(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;I)V

    return-object p0
.end method

.method public setName(Ljava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 1902
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1903
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1200(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V

    return-object p0
.end method

.method public setNameBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 1930
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1931
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1400(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setSidePacketName(ILjava/lang/String;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 2005
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2006
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->access$1500(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;ILjava/lang/String;)V

    return-object p0
.end method
