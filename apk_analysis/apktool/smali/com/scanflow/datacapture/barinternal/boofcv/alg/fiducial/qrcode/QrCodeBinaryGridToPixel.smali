.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;
.super Ljava/lang/Object;
.source "QrCodeBinaryGridToPixel.java"


# instance fields
.field final H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

.field final H32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

.field public final Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

.field final Hinv32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

.field adjustWithFeatures:Z

.field final adjustments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field final dlt:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

.field final generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/fitting/modelset/ModelGenerator;

.field final pairs2D:Ljava/util/List;

.field final storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field final storagePairs3D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field final tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;-><init>(Z)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/fitting/modelset/ModelGenerator;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;-><init>(Z)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->dlt:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs3D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 52
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    .line 54
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    .line 59
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method

.method private set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V
    .locals 10

    .line 195
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 196
    invoke-virtual {p3, p4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p3

    .line 197
    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v4, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    float-to-double v6, p2

    float-to-double v8, p1

    invoke-virtual/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->setTo(DDDD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 198
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {p1, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private setLine(FFFFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;ILcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V
    .locals 14

    .line 203
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs3D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;

    .line 204
    invoke-virtual/range {p5 .. p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    .line 205
    invoke-virtual/range {p7 .. p8}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    .line 207
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v3, v5

    iget-wide v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v7, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v5, v7

    sub-float v0, p4, p2

    float-to-double v8, v0

    sub-float p1, p3, p1

    float-to-double v10, p1

    const-wide/16 v12, 0x0

    move-wide v2, v3

    move-wide v4, v5

    const-wide/16 v6, 0x0

    invoke-virtual/range {v1 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->setTo(DDDDDD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;

    .line 209
    iget-object p1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->norm()D

    move-result-wide v2

    invoke-virtual {p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->divideIP(D)V

    .line 210
    iget-object p1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->norm()D

    move-result-wide v0

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->divideIP(D)V

    return-void
.end method


# virtual methods
.method public addAllFeatures(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 12

    const/4 v0, 0x0

    .line 110
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustWithFeatures:Z

    .line 111
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 112
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->clear()V

    .line 114
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->getNumberOfModules()I

    move-result v1

    .line 116
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v3, 0x0

    invoke-direct {p0, v3, v3, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 117
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/high16 v4, 0x40e00000    # 7.0f

    const/4 v5, 0x1

    invoke-direct {p0, v3, v4, v2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 118
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v6, 0x2

    invoke-direct {p0, v4, v4, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 119
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v7, 0x3

    invoke-direct {p0, v4, v3, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    add-int/lit8 v2, v1, -0x7

    int-to-float v2, v2

    .line 121
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v3, v2, v8, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    int-to-float v1, v1

    .line 122
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v3, v1, v8, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 123
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v4, v1, v8, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 124
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v4, v2, v8, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 126
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v2, v3, v8, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 127
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v2, v4, v8, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 128
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v1, v4, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 129
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {p0, v1, v3, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 131
    :goto_0
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v0, v2, :cond_0

    .line 132
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    .line 133
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v2

    move-object v3, v2

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 134
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v4, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v6, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    int-to-float v2, v2

    const/high16 v8, 0x3f000000    # 0.5f

    add-float/2addr v2, v8

    float-to-double v9, v2

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    int-to-float v1, v1

    add-float/2addr v1, v8

    float-to-double v1, v1

    move-wide v8, v9

    move-wide v10, v1

    invoke-virtual/range {v3 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->setTo(DDDD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 135
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v1, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public computeTransform()V
    .locals 9

    .line 176
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/fitting/modelset/ModelGenerator;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/fitting/modelset/ModelGenerator;->generate(Ljava/util/List;Ljava/lang/Object;)Z

    .line 177
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->invert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 178
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/ConvertFloatType;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    .line 179
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/ConvertFloatType;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    .line 181
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 182
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustWithFeatures:Z

    if-eqz v0, :cond_0

    const/4 v0, 0x0

    .line 183
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 184
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 185
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 187
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-object v6, v4

    iget-wide v4, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F64;->transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 188
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v6, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v3, v6

    iput-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 189
    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v3, v5

    iput-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V
    .locals 9

    .line 222
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-static {v0, p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F32;->transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    .line 226
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustWithFeatures:Z

    if-eqz v0, :cond_2

    const/4 v0, -0x1

    const-wide v1, 0x7fefffffffffffffL    # Double.MAX_VALUE

    const/4 v3, 0x0

    .line 229
    :goto_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v4}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 230
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v4, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    float-to-double v5, p2

    float-to-double v7, p1

    invoke-virtual {v4, v5, v6, v7, v8}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance2(DD)D

    move-result-wide v4

    cmpg-double v6, v4, v1

    if-gez v6, :cond_0

    move v0, v3

    move-wide v1, v4

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 237
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 239
    iget p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v0, v0

    add-float/2addr p2, v0

    iput p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    .line 240
    iget p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float p1, v0

    add-float/2addr p2, p1

    iput p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    :cond_2
    return-void
.end method

.method public final imageToGrid(DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 6

    .line 218
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    move-wide v1, p1

    move-wide v3, p3

    move-object v5, p5

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F64;->transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method

.method public removeFeatureWithLargestError()Z
    .locals 13

    const/4 v0, -0x1

    const-wide/16 v1, 0x0

    const/4 v3, 0x0

    move v5, v0

    move v4, v3

    .line 155
    :goto_0
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result v6

    if-ge v4, v6, :cond_1

    .line 156
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v6, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 157
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v8, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-object v10, v8

    iget-wide v8, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v10, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-object v12, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F64;->transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 158
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->tmp64:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v8, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v10, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v8, v10

    .line 159
    iget-wide v10, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v10, v6

    mul-double/2addr v8, v8

    mul-double/2addr v10, v10

    add-double/2addr v8, v10

    cmpl-double v6, v8, v1

    if-lez v6, :cond_0

    move v5, v4

    move-wide v1, v8

    :cond_0
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    if-eq v5, v0, :cond_2

    const-wide/high16 v6, 0x4010000000000000L    # 4.0

    cmpl-double v0, v1, v6

    if-lez v0, :cond_2

    .line 168
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v0, v5}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    const/4 v0, 0x1

    return v0

    :cond_2
    return v3
.end method

.method public removeOutsideCornerFeatures()V
    .locals 2

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ne v0, v1, :cond_0

    .line 146
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    const/16 v1, 0xb

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    const/4 v1, 0x5

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    .line 148
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void

    .line 144
    :cond_0
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "This can only be called when all the features have been added"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public setTransformFromLinesSquare(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 10

    .line 85
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 86
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs3D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 90
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v2, 0x1

    const/4 v3, 0x0

    const/high16 v4, 0x40e00000    # 7.0f

    invoke-direct {p0, v3, v4, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 91
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v2, 0x2

    invoke-direct {p0, v4, v4, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 92
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v9, 0x3

    invoke-direct {p0, v4, v3, v1, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 96
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v8, 0x0

    const/4 v1, 0x0

    const/high16 v2, 0x40e00000    # 7.0f

    const/high16 v4, 0x41600000    # 14.0f

    const/4 v6, 0x1

    move-object v0, p0

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setLine(FFFFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;ILcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 97
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v8, 0x3

    const/high16 v1, 0x40e00000    # 7.0f

    const/high16 v3, 0x40e00000    # 7.0f

    const/4 v6, 0x2

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setLine(FFFFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;ILcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 98
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v8, 0x1

    const/high16 v3, 0x41600000    # 14.0f

    const/high16 v4, 0x40e00000    # 7.0f

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setLine(FFFFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;ILcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 99
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v8, 0x0

    const/4 v2, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x3

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setLine(FFFFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;ILcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 101
    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v1, v9, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 102
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->dlt:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v3

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs3D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v4

    const/4 v5, 0x0

    invoke-virtual {v2, v3, v4, v5, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->process(Ljava/util/List;Ljava/util/List;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    .line 103
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 104
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->invert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 105
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/ConvertFloatType;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    .line 106
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->H32:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/ConvertFloatType;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    return-void
.end method

.method public setTransformFromSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V
    .locals 3

    const/4 v0, 0x0

    .line 66
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->adjustWithFeatures:Z

    .line 67
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->storagePairs2D:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 68
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->pairs2D:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->clear()V

    const/4 v1, 0x0

    .line 70
    invoke-direct {p0, v1, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    const/4 v0, 0x1

    const/high16 v2, 0x40e00000    # 7.0f

    .line 71
    invoke-direct {p0, v1, v2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    const/4 v0, 0x2

    .line 72
    invoke-direct {p0, v2, v2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    const/4 v0, 0x3

    .line 73
    invoke-direct {p0, v2, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->set(FFLcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;I)V

    .line 75
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->computeTransform()V

    return-void
.end method
