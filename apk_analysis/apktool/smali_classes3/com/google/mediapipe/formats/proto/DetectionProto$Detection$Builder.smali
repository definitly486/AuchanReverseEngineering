.class public final Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "DetectionProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1578
    invoke-static {}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$600()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/formats/proto/DetectionProto$1;)V
    .locals 0

    .line 1571
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllAssociatedDetections(Ljava/lang/Iterable;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;)",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;"
        }
    .end annotation

    .line 2220
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2221
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllDisplayName(Ljava/lang/Iterable;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;"
        }
    .end annotation

    .line 2343
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2344
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllLabel(Ljava/lang/Iterable;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;"
        }
    .end annotation

    .line 1677
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1678
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllLabelId(Ljava/lang/Iterable;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Integer;",
            ">;)",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;"
        }
    .end annotation

    .line 1765
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1766
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllScore(Ljava/lang/Iterable;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Float;",
            ">;)",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;"
        }
    .end annotation

    .line 1834
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1835
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2210
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2211
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 2212
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    .line 2211
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public addAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2192
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2193
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public addAssociatedDetections(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2201
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2202
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public addAssociatedDetections(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2183
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2184
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public addDisplayName(Ljava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2327
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2328
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V

    return-object p0
.end method

.method public addDisplayNameBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2373
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2374
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$4100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addLabel(Ljava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1662
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1663
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V

    return-object p0
.end method

.method public addLabelBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1705
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1706
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public addLabelId(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1754
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1755
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;I)V

    return-object p0
.end method

.method public addScore(F)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1823
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1824
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;F)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearAssociatedDetections()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2228
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2229
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearDetectionId()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2134
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2135
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearDisplayName()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2357
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2358
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$4000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearFeatureTag()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1985
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1986
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearLabel()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1690
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1691
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearLabelId()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1774
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1775
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearLocationData()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1914
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1915
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearScore()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1843
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1844
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearTimestampUsec()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2429
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2430
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$4300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public clearTrackId()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2067
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2068
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public getAssociatedDetections(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 2158
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getAssociatedDetections(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    move-result-object p1

    return-object p1
.end method

.method public getAssociatedDetectionsCount()I
    .locals 1

    .line 2152
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getAssociatedDetectionsCount()I

    move-result v0

    return v0
.end method

.method public getAssociatedDetectionsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;"
        }
    .end annotation

    .line 2144
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 2145
    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getAssociatedDetectionsList()Ljava/util/List;

    move-result-object v0

    .line 2144
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1571
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getDetectionId()J
    .locals 2

    .line 2109
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDetectionId()J

    move-result-wide v0

    return-wide v0
.end method

.method public getDisplayName(I)Ljava/lang/String;
    .locals 1

    .line 2281
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDisplayName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getDisplayNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 2296
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDisplayNameBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getDisplayNameCount()I
    .locals 1

    .line 2267
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDisplayNameCount()I

    move-result v0

    return v0
.end method

.method public getDisplayNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 2253
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 2254
    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDisplayNameList()Ljava/util/List;

    move-result-object v0

    .line 2253
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getFeatureTag()Ljava/lang/String;
    .locals 1

    .line 1943
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getFeatureTag()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getFeatureTagBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1957
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getFeatureTagBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getLabel(I)Ljava/lang/String;
    .locals 1

    .line 1619
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabel(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getLabelBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1633
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelBytes(I)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getLabelCount()I
    .locals 1

    .line 1606
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelCount()I

    move-result v0

    return v0
.end method

.method public getLabelId(I)I
    .locals 1

    .line 1735
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelId(I)I

    move-result p1

    return p1
.end method

.method public getLabelIdCount()I
    .locals 1

    .line 1726
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelIdCount()I

    move-result v0

    return v0
.end method

.method public getLabelIdList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation

    .line 1717
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 1718
    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelIdList()Ljava/util/List;

    move-result-object v0

    .line 1717
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getLabelList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1593
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 1594
    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLabelList()Ljava/util/List;

    move-result-object v0

    .line 1593
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getLocationData()Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;
    .locals 1

    .line 1868
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getLocationData()Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    move-result-object v0

    return-object v0
.end method

.method public getScore(I)F
    .locals 1

    .line 1804
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getScore(I)F

    move-result p1

    return p1
.end method

.method public getScoreCount()I
    .locals 1

    .line 1795
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getScoreCount()I

    move-result v0

    return v0
.end method

.method public getScoreList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Float;",
            ">;"
        }
    .end annotation

    .line 1786
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 1787
    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getScoreList()Ljava/util/List;

    move-result-object v0

    .line 1786
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getTimestampUsec()J
    .locals 2

    .line 2402
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getTimestampUsec()J

    move-result-wide v0

    return-wide v0
.end method

.method public getTrackId()Ljava/lang/String;
    .locals 1

    .line 2028
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getTrackId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getTrackIdBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 2041
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getTrackIdBytes()Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasDetectionId()Z
    .locals 1

    .line 2097
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->hasDetectionId()Z

    move-result v0

    return v0
.end method

.method public hasFeatureTag()Z
    .locals 1

    .line 1930
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->hasFeatureTag()Z

    move-result v0

    return v0
.end method

.method public hasLocationData()Z
    .locals 1

    .line 1857
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->hasLocationData()Z

    move-result v0

    return v0
.end method

.method public hasTimestampUsec()Z
    .locals 1

    .line 2389
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->hasTimestampUsec()Z

    move-result v0

    return v0
.end method

.method public hasTrackId()Z
    .locals 1

    .line 2016
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->hasTrackId()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1571
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1571
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1903
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1904
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V

    return-object p0
.end method

.method public removeAssociatedDetections(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2236
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2237
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;I)V

    return-object p0
.end method

.method public setAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2174
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2175
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 2176
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    .line 2175
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public setAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2165
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2166
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-object p0
.end method

.method public setDetectionId(J)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2121
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2122
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;J)V

    return-object p0
.end method

.method public setDisplayName(ILjava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2311
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2312
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$3700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILjava/lang/String;)V

    return-object p0
.end method

.method public setFeatureTag(Ljava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1971
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1972
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V

    return-object p0
.end method

.method public setFeatureTagBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2001
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2002
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method

.method public setLabel(ILjava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1647
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1648
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILjava/lang/String;)V

    return-object p0
.end method

.method public setLabelId(II)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1744
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1745
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;II)V

    return-object p0
.end method

.method public setLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData$Builder;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1891
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1892
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V

    return-object p0
.end method

.method public setLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1878
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1879
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V

    return-object p0
.end method

.method public setScore(IF)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1813
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1814
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$1600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;IF)V

    return-object p0
.end method

.method public setTimestampUsec(J)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2415
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2416
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$4200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;J)V

    return-object p0
.end method

.method public setTrackId(Ljava/lang/String;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2054
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2055
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V

    return-object p0
.end method

.method public setTrackIdBytes(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 2082
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 2083
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->access$2800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V

    return-object p0
.end method
