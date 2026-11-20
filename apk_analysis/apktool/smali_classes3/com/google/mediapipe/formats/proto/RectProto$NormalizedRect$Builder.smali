.class public final Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "RectProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRectOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;",
        "Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRectOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1369
    invoke-static {}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1400()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/formats/proto/RectProto$1;)V
    .locals 0

    .line 1362
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearHeight()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1512
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1513
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2000(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public clearRectId()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1656
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1657
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2600(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public clearRotation()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1600
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1601
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2400(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public clearWidth()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1548
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1549
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2200(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public clearXCenter()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1424
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1425
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1600(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public clearYCenter()Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1460
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1461
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1800(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1362
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getHeight()F
    .locals 1

    .line 1487
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getHeight()F

    move-result v0

    return v0
.end method

.method public getRectId()J
    .locals 2

    .line 1629
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getRectId()J

    move-result-wide v0

    return-wide v0
.end method

.method public getRotation()F
    .locals 1

    .line 1575
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getRotation()F

    move-result v0

    return v0
.end method

.method public getWidth()F
    .locals 1

    .line 1531
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getWidth()F

    move-result v0

    return v0
.end method

.method public getXCenter()F
    .locals 1

    .line 1397
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getXCenter()F

    move-result v0

    return v0
.end method

.method public getYCenter()F
    .locals 1

    .line 1443
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->getYCenter()F

    move-result v0

    return v0
.end method

.method public hasHeight()Z
    .locals 1

    .line 1475
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasHeight()Z

    move-result v0

    return v0
.end method

.method public hasRectId()Z
    .locals 1

    .line 1616
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasRectId()Z

    move-result v0

    return v0
.end method

.method public hasRotation()Z
    .locals 1

    .line 1563
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasRotation()Z

    move-result v0

    return v0
.end method

.method public hasWidth()Z
    .locals 1

    .line 1523
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasWidth()Z

    move-result v0

    return v0
.end method

.method public hasXCenter()Z
    .locals 1

    .line 1384
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasXCenter()Z

    move-result v0

    return v0
.end method

.method public hasYCenter()Z
    .locals 1

    .line 1435
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->hasYCenter()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1362
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1362
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public setHeight(F)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1499
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1500
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1900(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;F)V

    return-object p0
.end method

.method public setRectId(J)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1642
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1643
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2500(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;J)V

    return-object p0
.end method

.method public setRotation(F)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1587
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1588
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2300(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;F)V

    return-object p0
.end method

.method public setWidth(F)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1539
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1540
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$2100(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;F)V

    return-object p0
.end method

.method public setXCenter(F)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1410
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1411
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1500(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;F)V

    return-object p0
.end method

.method public setYCenter(F)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;
    .locals 1

    .line 1451
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1452
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;->access$1700(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;F)V

    return-object p0
.end method
