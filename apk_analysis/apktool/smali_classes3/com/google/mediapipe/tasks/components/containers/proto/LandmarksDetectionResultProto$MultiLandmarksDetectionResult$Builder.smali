.class public final Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "LandmarksDetectionResultProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResultOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResultOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 1165
    invoke-static {}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1400()Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$1;)V
    .locals 0

    .line 1158
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public addAllClassifications(Ljava/lang/Iterable;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;"
        }
    .end annotation

    .line 1352
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1353
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2400(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllLandmarks(Ljava/lang/Iterable;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;"
        }
    .end annotation

    .line 1250
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1251
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1800(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllRects(Ljava/lang/Iterable;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;"
        }
    .end annotation

    .line 1556
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1557
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3600(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addAllWorldLandmarks(Ljava/lang/Iterable;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;"
        }
    .end annotation

    .line 1454
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1455
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3000(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Ljava/lang/Iterable;)V

    return-object p0
.end method

.method public addClassifications(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1342
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1343
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1344
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 1343
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2300(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public addClassifications(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1324
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1325
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2300(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public addClassifications(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1333
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1334
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2200(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public addClassifications(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1315
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1316
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2200(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public addLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1240
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1241
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1242
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;

    .line 1241
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1700(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public addLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1222
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1223
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1700(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public addLandmarks(Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1231
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1232
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1600(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public addLandmarks(Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1213
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1214
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1600(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public addRects(ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1546
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1547
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1548
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    .line 1547
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3500(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public addRects(ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1528
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1529
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3500(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public addRects(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1537
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1538
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3400(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public addRects(Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1519
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1520
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3400(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public addWorldLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1444
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1445
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1446
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    .line 1445
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2900(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method

.method public addWorldLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1426
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1427
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2900(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method

.method public addWorldLandmarks(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1435
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1436
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2800(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method

.method public addWorldLandmarks(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1417
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1418
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2800(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method

.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearClassifications()Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1360
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1361
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2500(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;)V

    return-object p0
.end method

.method public clearLandmarks()Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1258
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1259
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1900(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;)V

    return-object p0
.end method

.method public clearRects()Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1564
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1565
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3700(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;)V

    return-object p0
.end method

.method public clearWorldLandmarks()Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1462
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1463
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3100(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public getClassifications(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1290
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getClassifications(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    move-result-object p1

    return-object p1
.end method

.method public getClassificationsCount()I
    .locals 1

    .line 1284
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getClassificationsCount()I

    move-result v0

    return v0
.end method

.method public getClassificationsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;"
        }
    .end annotation

    .line 1276
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1277
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getClassificationsList()Ljava/util/List;

    move-result-object v0

    .line 1276
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1158
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getLandmarks(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;
    .locals 1

    .line 1188
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getLandmarks(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;

    move-result-object p1

    return-object p1
.end method

.method public getLandmarksCount()I
    .locals 1

    .line 1182
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getLandmarksCount()I

    move-result v0

    return v0
.end method

.method public getLandmarksList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;",
            ">;"
        }
    .end annotation

    .line 1174
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1175
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getLandmarksList()Ljava/util/List;

    move-result-object v0

    .line 1174
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getRects(I)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;
    .locals 1

    .line 1494
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getRects(I)Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    move-result-object p1

    return-object p1
.end method

.method public getRectsCount()I
    .locals 1

    .line 1488
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getRectsCount()I

    move-result v0

    return v0
.end method

.method public getRectsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;",
            ">;"
        }
    .end annotation

    .line 1480
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1481
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getRectsList()Ljava/util/List;

    move-result-object v0

    .line 1480
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getWorldLandmarks(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 1392
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getWorldLandmarks(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    move-result-object p1

    return-object p1
.end method

.method public getWorldLandmarksCount()I
    .locals 1

    .line 1386
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getWorldLandmarksCount()I

    move-result v0

    return v0
.end method

.method public getWorldLandmarksList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;"
        }
    .end annotation

    .line 1378
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1379
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->getWorldLandmarksList()Ljava/util/List;

    move-result-object v0

    .line 1378
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1158
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 1158
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public removeClassifications(I)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1368
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1369
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2600(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;I)V

    return-object p0
.end method

.method public removeLandmarks(I)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1266
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1267
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2000(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;I)V

    return-object p0
.end method

.method public removeRects(I)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1572
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1573
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3800(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;I)V

    return-object p0
.end method

.method public removeWorldLandmarks(I)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1470
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1471
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3200(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;I)V

    return-object p0
.end method

.method public setClassifications(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1306
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1307
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1308
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 1307
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2100(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public setClassifications(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1297
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1298
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2100(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-object p0
.end method

.method public setLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1204
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1205
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1206
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;

    .line 1205
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1500(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public setLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1195
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1196
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$1500(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$NormalizedLandmarkList;)V

    return-object p0
.end method

.method public setRects(ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1510
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1511
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1512
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;

    .line 1511
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3300(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public setRects(ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1501
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1502
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$3300(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/RectProto$NormalizedRect;)V

    return-object p0
.end method

.method public setWorldLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1408
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1409
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    .line 1410
    invoke-virtual {p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    .line 1409
    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2700(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method

.method public setWorldLandmarks(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult$Builder;
    .locals 1

    .line 1399
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1400
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;

    invoke-static {v0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;->access$2700(Lcom/google/mediapipe/tasks/components/containers/proto/LandmarksDetectionResultProto$MultiLandmarksDetectionResult;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-object p0
.end method
