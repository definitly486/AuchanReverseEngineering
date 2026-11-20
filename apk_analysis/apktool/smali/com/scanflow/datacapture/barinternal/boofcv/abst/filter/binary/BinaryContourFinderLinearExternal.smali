.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;
.super Ljava/lang/Object;
.source "BinaryContourFinderLinearExternal.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;


# instance fields
.field adjustX:I

.field adjustY:I

.field alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

.field contours:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field copyForPadding:Z

.field work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 42
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->copyForPadding:Z

    .line 45
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-direct {v1, v0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->contours:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    return-void
.end method


# virtual methods
.method public getContours()Ljava/util/List;
    .locals 1

    .line 76
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->contours:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 1

    if-nez p1, :cond_0

    .line 106
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;-><init>()V

    .line 107
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->getMinContourLength()Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-object p1
.end method

.method public isCreatePaddedCopy()Z
    .locals 1

    .line 141
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->copyForPadding:Z

    return v0
.end method

.method public loadContour(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 1

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->getExternalContours()Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->getSet(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    return-void
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 11

    .line 55
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->copyForPadding:Z

    if-eqz v0, :cond_0

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v1, v1, 0x2

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    add-int/lit8 v2, v2, 0x2

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 57
    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x1

    const/4 v6, 0x1

    move-object v9, p1

    invoke-static/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->copy(IIIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    .line 58
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v1, 0x1

    invoke-virtual {p1, v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V

    goto :goto_0

    :cond_0
    move-object v9, p1

    .line 60
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->adjustX:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->adjustY:I

    invoke-virtual {p1, v9, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V

    .line 64
    :goto_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->contours:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 65
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->getExternalContours()Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object p1

    const/4 v0, 0x0

    .line 67
    :goto_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->size()I

    move-result v1

    if-ge v0, v1, :cond_1

    .line 68
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->contours:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;

    .line 69
    iput v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;->externalIndex:I

    .line 70
    iput v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;->id:I

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method public setConnectRule(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
    .locals 1

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->setConnectRule(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    return-void
.end method

.method public setCoordinateAdjustment(II)V
    .locals 0

    .line 146
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->adjustX:I

    .line 147
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->adjustY:I

    return-void
.end method

.method public setCreatePaddedCopy(Z)V
    .locals 0

    .line 136
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->copyForPadding:Z

    return-void
.end method

.method public setMaxContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 1

    .line 113
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->setMaxContourLength(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    return-void
.end method

.method public setMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 1

    .line 100
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->setMinContourLength(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    return-void
.end method

.method public setSaveInnerContour(Z)V
    .locals 0

    .line 91
    return-void
.end method
