.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "TextScanResult"
.end annotation


# instance fields
.field private confidence:Ljava/lang/Float;

.field private image:Landroid/graphics/Bitmap;

.field private latitudeObj:Ljava/lang/Double;

.field private longitudeObj:Ljava/lang/Double;

.field private rawtext:Ljava/lang/String;

.field private text:Ljava/lang/String;

.field private unprocessResult:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 10

    const/16 v8, 0x7f

    const/4 v9, 0x0

    const/4 v1, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    move-object v0, p0

    .line 1
    invoke-direct/range {v0 .. v9}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;-><init>(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V
    .locals 0

    .line 2
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    iput-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    iput-object p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    iput-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    return-void
.end method

.method public synthetic constructor <init>(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;ILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 1

    and-int/lit8 p9, p8, 0x1

    const/4 v0, 0x0

    if-eqz p9, :cond_0

    move-object p1, v0

    :cond_0
    and-int/lit8 p9, p8, 0x2

    if-eqz p9, :cond_1

    move-object p2, v0

    :cond_1
    and-int/lit8 p9, p8, 0x4

    if-eqz p9, :cond_2

    move-object p3, v0

    :cond_2
    and-int/lit8 p9, p8, 0x8

    if-eqz p9, :cond_3

    move-object p4, v0

    :cond_3
    and-int/lit8 p9, p8, 0x10

    if-eqz p9, :cond_4

    move-object p5, v0

    :cond_4
    and-int/lit8 p9, p8, 0x20

    if-eqz p9, :cond_5

    move-object p6, v0

    :cond_5
    and-int/lit8 p8, p8, 0x40

    if-eqz p8, :cond_6

    move-object p8, v0

    :goto_0
    move-object p7, p6

    move-object p6, p5

    move-object p5, p4

    move-object p4, p3

    move-object p3, p2

    move-object p2, p1

    move-object p1, p0

    goto :goto_1

    :cond_6
    move-object p8, p7

    goto :goto_0

    .line 3
    :goto_1
    invoke-direct/range {p1 .. p8}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;-><init>(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;ILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;
    .locals 0

    .line 0
    and-int/lit8 p9, p8, 0x1

    if-eqz p9, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    :cond_0
    and-int/lit8 p9, p8, 0x2

    if-eqz p9, :cond_1

    iget-object p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    :cond_1
    and-int/lit8 p9, p8, 0x4

    if-eqz p9, :cond_2

    iget-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    :cond_2
    and-int/lit8 p9, p8, 0x8

    if-eqz p9, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    :cond_3
    and-int/lit8 p9, p8, 0x10

    if-eqz p9, :cond_4

    iget-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    :cond_4
    and-int/lit8 p9, p8, 0x20

    if-eqz p9, :cond_5

    iget-object p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    :cond_5
    and-int/lit8 p8, p8, 0x40

    if-eqz p8, :cond_6

    iget-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    :cond_6
    move-object p8, p6

    move-object p9, p7

    move-object p6, p4

    move-object p7, p5

    move-object p4, p2

    move-object p5, p3

    move-object p2, p0

    move-object p3, p1

    invoke-virtual/range {p2 .. p9}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->copy(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    return-object v0
.end method

.method public final component2()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final component3()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    return-object v0
.end method

.method public final component4()Ljava/lang/Float;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    return-object v0
.end method

.method public final component5()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    return-object v0
.end method

.method public final component6()Ljava/lang/Double;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    return-object v0
.end method

.method public final component7()Ljava/lang/Double;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    return-object v0
.end method

.method public final copy(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;
    .locals 8

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move-object v6, p6

    move-object v7, p7

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;-><init>(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_7

    return v2

    :cond_7
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    iget-object p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_8

    return v2

    :cond_8
    return v0
.end method

.method public final getConfidence()Ljava/lang/Float;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    return-object v0
.end method

.method public final getImage()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final getLatitudeObj()Ljava/lang/Double;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    return-object v0
.end method

.method public final getLongitudeObj()Ljava/lang/Double;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    return-object v0
.end method

.method public final getRawtext()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    return-object v0
.end method

.method public final getText()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    return-object v0
.end method

.method public final getUnprocessResult()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    move v0, v1

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    :goto_0
    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    if-nez v2, :cond_1

    move v2, v1

    goto :goto_1

    :cond_1
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_1
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    if-nez v2, :cond_2

    move v2, v1

    goto :goto_2

    :cond_2
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_2
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    if-nez v2, :cond_3

    move v2, v1

    goto :goto_3

    :cond_3
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_3
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    if-nez v2, :cond_4

    move v2, v1

    goto :goto_4

    :cond_4
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_4
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    if-nez v2, :cond_5

    move v2, v1

    goto :goto_5

    :cond_5
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_5
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    if-nez v2, :cond_6

    goto :goto_6

    :cond_6
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v1

    :goto_6
    add-int/2addr v0, v1

    return v0
.end method

.method public final setConfidence(Ljava/lang/Float;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    return-void
.end method

.method public final setImage(Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    return-void
.end method

.method public final setLatitudeObj(Ljava/lang/Double;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    return-void
.end method

.method public final setLongitudeObj(Ljava/lang/Double;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    return-void
.end method

.method public final setRawtext(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    return-void
.end method

.method public final setText(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    return-void
.end method

.method public final setUnprocessResult(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "TextScanResult(text="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->text:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", image="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->image:Landroid/graphics/Bitmap;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", rawtext="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->rawtext:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", confidence="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->confidence:Ljava/lang/Float;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", unprocessResult="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->unprocessResult:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", latitudeObj="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->latitudeObj:Ljava/lang/Double;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", longitudeObj="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;->longitudeObj:Ljava/lang/Double;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
