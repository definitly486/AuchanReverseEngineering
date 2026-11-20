.class public final Lcom/scanflow/ui/ar/ArObject;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation build Landroidx/annotation/Keep;
.end annotation


# instance fields
.field private final bboxcolor:I

.field private final boundingBox:Landroid/graphics/RectF;

.field private decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

.field private showtickimage:Z

.field private final sourceRotationDegrees:I

.field private final sourceSize:Landroid/util/Size;

.field private final trackingId:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V
    .locals 1

    .line 1
    const-string v0, "trackingId"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "boundingBox"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sourceSize"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    iput-object p3, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    iput p4, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    iput p5, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    iput-object p6, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    iput-boolean p7, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    return-void
.end method

.method public synthetic constructor <init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 8

    and-int/lit8 v0, p8, 0x10

    if-eqz v0, :cond_0

    const/4 p5, -0x1

    :cond_0
    move v5, p5

    and-int/lit8 p5, p8, 0x20

    if-eqz p5, :cond_1

    const/4 p6, 0x0

    :cond_1
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move v4, p4

    move-object v6, p6

    move v7, p7

    .line 2
    invoke-direct/range {v0 .. v7}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/ui/ar/ArObject;Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;ZILjava/lang/Object;)Lcom/scanflow/ui/ar/ArObject;
    .locals 0

    .line 0
    and-int/lit8 p9, p8, 0x1

    if-eqz p9, :cond_0

    iget-object p1, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    :cond_0
    and-int/lit8 p9, p8, 0x2

    if-eqz p9, :cond_1

    iget-object p2, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    :cond_1
    and-int/lit8 p9, p8, 0x4

    if-eqz p9, :cond_2

    iget-object p3, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    :cond_2
    and-int/lit8 p9, p8, 0x8

    if-eqz p9, :cond_3

    iget p4, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    :cond_3
    and-int/lit8 p9, p8, 0x10

    if-eqz p9, :cond_4

    iget p5, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    :cond_4
    and-int/lit8 p9, p8, 0x20

    if-eqz p9, :cond_5

    iget-object p6, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    :cond_5
    and-int/lit8 p8, p8, 0x40

    if-eqz p8, :cond_6

    iget-boolean p7, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    :cond_6
    move-object p8, p6

    move p9, p7

    move p6, p4

    move p7, p5

    move-object p4, p2

    move-object p5, p3

    move-object p2, p0

    move-object p3, p1

    invoke-virtual/range {p2 .. p9}, Lcom/scanflow/ui/ar/ArObject;->copy(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)Lcom/scanflow/ui/ar/ArObject;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    return-object v0
.end method

.method public final component2()Landroid/graphics/RectF;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    return-object v0
.end method

.method public final component3()Landroid/util/Size;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    return-object v0
.end method

.method public final component4()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    return v0
.end method

.method public final component5()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    return v0
.end method

.method public final component6()Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    return-object v0
.end method

.method public final component7()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    return v0
.end method

.method public final copy(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)Lcom/scanflow/ui/ar/ArObject;
    .locals 9

    .line 0
    const-string v0, "trackingId"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "boundingBox"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sourceSize"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/ui/ar/ArObject;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move v5, p4

    move v6, p5

    move-object v7, p6

    move/from16 v8, p7

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    return-object v1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/ui/ar/ArObject;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/ui/ar/ArObject;

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    iget-object v3, p1, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    iget-object v3, p1, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    iget v1, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    iget v3, p1, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    if-eq v1, v3, :cond_5

    return v2

    :cond_5
    iget v1, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    iget v3, p1, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    if-eq v1, v3, :cond_6

    return v2

    :cond_6
    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    iget-object v3, p1, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_7

    return v2

    :cond_7
    iget-boolean v1, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    iget-boolean p1, p1, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    if-eq v1, p1, :cond_8

    return v2

    :cond_8
    return v0
.end method

.method public final getBboxcolor()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    return v0
.end method

.method public final getBoundingBox()Landroid/graphics/RectF;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    return-object v0
.end method

.method public final getDecodedResult()Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    return-object v0
.end method

.method public final getShowtickimage()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    return v0
.end method

.method public final getSourceRotationDegrees()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    return v0
.end method

.method public final getSourceSize()Landroid/util/Size;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    return-object v0
.end method

.method public final getTrackingId()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    invoke-virtual {v1}, Landroid/graphics/RectF;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    invoke-virtual {v0}, Landroid/util/Size;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget v1, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    invoke-static {v1}, Ljava/lang/Integer;->hashCode(I)I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget v0, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    invoke-static {v0}, Ljava/lang/Integer;->hashCode(I)I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    if-nez v1, :cond_0

    const/4 v1, 0x0

    goto :goto_0

    :cond_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;->hashCode()I

    move-result v1

    :goto_0
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-boolean v1, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    invoke-static {v1}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public final setDecodedResult(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    return-void
.end method

.method public final setShowtickimage(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "ArObject(trackingId="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->trackingId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", boundingBox="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->boundingBox:Landroid/graphics/RectF;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", sourceSize="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->sourceSize:Landroid/util/Size;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", sourceRotationDegrees="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/ui/ar/ArObject;->sourceRotationDegrees:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", bboxcolor="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/ui/ar/ArObject;->bboxcolor:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", decodedResult="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/ui/ar/ArObject;->decodedResult:Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", showtickimage="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/ui/ar/ArObject;->showtickimage:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
