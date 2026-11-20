.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;
.super Ljava/lang/Object;
.source "BinaryContourHelper.java"


# instance fields
.field binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

.field subimage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;Z)V
    .locals 2

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-nez p2, :cond_0

    .line 41
    instance-of p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    if-eqz p2, :cond_0

    .line 42
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    .line 43
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->subimage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 44
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    const/4 p2, 0x0

    invoke-interface {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;->setCreatePaddedCopy(Z)V

    .line 45
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    invoke-interface {p1, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;->setCoordinateAdjustment(II)V

    :cond_0
    return-void
.end method


# virtual methods
.method public padded()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 65
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v0
.end method

.method public reshape(II)V
    .locals 9

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    if-nez v0, :cond_0

    .line 54
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    return-void

    .line 56
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    add-int/lit8 v1, p1, 0x2

    add-int/lit8 v2, p2, 0x2

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 57
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    add-int/lit8 v6, p1, 0x1

    add-int/lit8 v7, p2, 0x1

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->subimage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v8}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    const/4 v4, 0x1

    const/4 v5, 0x1

    invoke-virtual/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->subimage(IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void
.end method

.method public withoutPadding()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    if-nez v0, :cond_0

    .line 73
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v0

    .line 75
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->subimage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method
