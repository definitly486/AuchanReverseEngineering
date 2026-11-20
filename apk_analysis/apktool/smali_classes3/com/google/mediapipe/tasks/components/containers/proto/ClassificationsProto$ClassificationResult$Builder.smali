.class public final Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "ClassificationsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResultOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResultOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1117
    invoke-static {}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1000()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$1;)V
    .locals 0

    .line 1110
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllClassifications(Ljava/lang/Iterable;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;"
        }
    .end annotation

    .line 1252
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1253
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1400(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1237
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1238
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    .line 1239
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    .line 1238
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1300(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public addClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1209
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1210
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1300(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public addClassifications(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1223
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1224
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1200(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public addClassifications(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1195
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1196
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1200(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearClassifications()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1265
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1266
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1500(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;)V

    return-object p0
.end method

.method public clearTimestampMs()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1354
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1355
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1800(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public getClassifications(I)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 1155
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->getClassifications(I)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    move-result-object p1

    return-object p1
.end method

.method public getClassificationsCount()I
    .locals 1

    .line 1144
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->getClassificationsCount()I

    move-result v0

    return v0
.end method

.method public getClassificationsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;"
        }
    .end annotation

    .line 1131
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    .line 1132
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->getClassificationsList()Ljava/util/List;

    move-result-object v0

    .line 1131
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getTimestampMs()J
    .locals 2

    .line 1317
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->getTimestampMs()J

    move-result-wide v0

    return-wide v0
.end method

.method public hasTimestampMs()Z
    .locals 1

    .line 1299
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->hasTimestampMs()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1110
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1110
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public removeClassifications(I)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1278
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1279
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1600(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;I)V

    return-object p0
.end method

.method public setClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1181
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1182
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    .line 1183
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    .line 1182
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1100(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public setClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1167
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1168
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1100(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-object p0
.end method

.method public setTimestampMs(J)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1335
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1336
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->access$1700(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;J)V

    return-object p0
.end method
