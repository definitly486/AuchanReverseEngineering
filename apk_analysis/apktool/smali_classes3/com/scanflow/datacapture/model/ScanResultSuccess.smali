.class public final Lcom/scanflow/datacapture/model/ScanResultSuccess;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field private final boundingBox:Landroid/graphics/RectF;

.field private final isLongDistance:Z

.field private final modelScanType:Ljava/lang/String;

.field private points:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;"
        }
    .end annotation
.end field

.field private final text:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/utils/BarcodeFormat;",
            "Z",
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;",
            "Landroid/graphics/RectF;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .line 0
    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "barcodeFormat"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "points"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "boundingBox"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "modelScanType"

    invoke-static {p6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    iput-boolean p3, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    iput-object p4, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    iput-object p5, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    iput-object p6, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/model/ScanResultSuccess;Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;ILjava/lang/Object;)Lcom/scanflow/datacapture/model/ScanResultSuccess;
    .locals 0

    .line 0
    and-int/lit8 p8, p7, 0x1

    if-eqz p8, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    :cond_0
    and-int/lit8 p8, p7, 0x2

    if-eqz p8, :cond_1

    iget-object p2, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    :cond_1
    and-int/lit8 p8, p7, 0x4

    if-eqz p8, :cond_2

    iget-boolean p3, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    :cond_2
    and-int/lit8 p8, p7, 0x8

    if-eqz p8, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    :cond_3
    and-int/lit8 p8, p7, 0x10

    if-eqz p8, :cond_4

    iget-object p5, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    :cond_4
    and-int/lit8 p7, p7, 0x20

    if-eqz p7, :cond_5

    iget-object p6, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    :cond_5
    move-object p7, p5

    move-object p8, p6

    move p5, p3

    move-object p6, p4

    move-object p3, p1

    move-object p4, p2

    move-object p2, p0

    invoke-virtual/range {p2 .. p8}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->copy(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)Lcom/scanflow/datacapture/model/ScanResultSuccess;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    return-object v0
.end method

.method public final component2()Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object v0
.end method

.method public final component3()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    return v0
.end method

.method public final component4()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final component5()Landroid/graphics/RectF;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    return-object v0
.end method

.method public final component6()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    return-object v0
.end method

.method public final copy(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)Lcom/scanflow/datacapture/model/ScanResultSuccess;
    .locals 8
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/utils/BarcodeFormat;",
            "Z",
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;",
            "Landroid/graphics/RectF;",
            "Ljava/lang/String;",
            ")",
            "Lcom/scanflow/datacapture/model/ScanResultSuccess;"
        }
    .end annotation

    .line 0
    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "barcodeFormat"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "points"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "boundingBox"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "modelScanType"

    invoke-static {p6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    move-object v2, p1

    move-object v3, p2

    move v4, p3

    move-object v5, p4

    move-object v6, p5

    move-object v7, p6

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    return-object v1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    if-eq v1, v3, :cond_3

    return v2

    :cond_3
    iget-boolean v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    if-eq v1, v3, :cond_4

    return v2

    :cond_4
    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    iget-object p1, p1, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_7

    return v2

    :cond_7
    return v0
.end method

.method public final getBarcodeFormat()Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object v0
.end method

.method public final getBoundingBox()Landroid/graphics/RectF;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    return-object v0
.end method

.method public final getModelScanType()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    return-object v0
.end method

.method public final getPoints()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final getText()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    const/16 v1, 0x1f

    mul-int/2addr v0, v1

    iget-object v2, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-boolean v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    .line 1
    invoke-static {v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 2
    iget-object v2, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    invoke-virtual {v2}, Ljava/util/ArrayList;->hashCode()I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-object v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    invoke-virtual {v0}, Landroid/graphics/RectF;->hashCode()I

    move-result v0

    add-int/2addr v0, v2

    mul-int/2addr v0, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public final isLongDistance()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    return v0
.end method

.method public final setPoints(Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Landroid/graphics/PointF;",
            ">;)V"
        }
    .end annotation

    .line 0
    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "ScanResultSuccess(text="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->text:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", barcodeFormat="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->barcodeFormat:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", isLongDistance="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->isLongDistance:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", points="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->points:Ljava/util/ArrayList;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", boundingBox="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->boundingBox:Landroid/graphics/RectF;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", modelScanType="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/ScanResultSuccess;->modelScanType:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
