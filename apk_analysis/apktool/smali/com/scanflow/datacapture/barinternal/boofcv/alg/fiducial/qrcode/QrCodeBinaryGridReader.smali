.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;
.super Ljava/lang/Object;
.source "QrCodeBinaryGridReader.java"


# instance fields
.field imageHeight:I

.field imageWidth:I

.field interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

.field pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

.field qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

.field threshold:F

.field transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;


# direct methods
.method public constructor <init>(Ljava/lang/Class;)V
    .locals 2

    .line 58
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    .line 60
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;->nearestNeighborPixelS(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    .line 61
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    invoke-static {v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder;->single(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    move-result-object p1

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixel;->setBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;)V

    return-void
.end method


# virtual methods
.method public getTransformGrid()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;
    .locals 1

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    return-object v0
.end method

.method public gridToImage(DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 1

    .line 119
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    double-to-float p1, p1

    double-to-float p2, p3

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 120
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget p2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    float-to-double p2, p2

    iput-wide p2, p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 121
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    float-to-double p1, p1

    iput-wide p1, p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-void
.end method

.method public imageToGrid(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 6

    .line 111
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v3, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    move-object v5, p2

    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->imageToGrid(DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    return-void
.end method

.method public read(FF)F
    .locals 2

    .line 125
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 126
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result p1

    return p1
.end method

.method public readBit(II)I
    .locals 6

    .line 164
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    int-to-float p1, p1

    const/high16 v1, 0x3f000000    # 0.5f

    add-float/2addr p1, v1

    const v2, 0x3e4ccccd    # 0.2f

    sub-float v3, p1, v2

    int-to-float p2, p2

    add-float/2addr p2, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, v3, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 165
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v0, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v0

    .line 166
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    add-float v3, p1, v2

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v1, v3, p2, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 167
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v1, v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v1

    .line 168
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    sub-float v4, p2, v2

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v3, p1, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 169
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v3, v5, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v3

    .line 170
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    add-float/2addr v2, p2

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v4, p1, v2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 171
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v2, v5, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v2

    .line 172
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v4, p1, p2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 173
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {p1, v4, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result p1

    .line 178
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->threshold:F

    cmpg-float v0, v0, p2

    const/4 v4, 0x1

    const/4 v5, 0x0

    if-gez v0, :cond_0

    move v0, v4

    goto :goto_0

    :cond_0
    move v0, v5

    :goto_0
    cmpg-float v1, v1, p2

    if-gez v1, :cond_1

    add-int/lit8 v0, v0, 0x1

    :cond_1
    cmpg-float v1, v3, p2

    if-gez v1, :cond_2

    add-int/lit8 v0, v0, 0x1

    :cond_2
    cmpg-float v1, v2, p2

    if-gez v1, :cond_3

    add-int/lit8 v0, v0, 0x1

    :cond_3
    cmpg-float p1, p1, p2

    if-gez p1, :cond_4

    add-int/lit8 v0, v0, 0x1

    :cond_4
    const/4 p1, 0x3

    if-lt v0, p1, :cond_5

    return v4

    :cond_5
    return v5
.end method

.method public readBitIntensity(IILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;)V
    .locals 4

    .line 139
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    int-to-float p1, p1

    const/high16 v1, 0x3f000000    # 0.5f

    add-float/2addr p1, v1

    const v2, 0x3e4ccccd    # 0.2f

    sub-float v3, p1, v2

    int-to-float p2, p2

    add-float/2addr p2, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, v3, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 140
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v0, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v0

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->add(F)V

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    add-float v1, p1, v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, v1, p2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 142
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v0, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v0

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->add(F)V

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    sub-float v1, p2, v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, p1, v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v0, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v0

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->add(F)V

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    add-float/2addr v2, p2

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 146
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v0

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->add(F)V

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-virtual {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->gridToImage(FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)V

    .line 148
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    iget v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-interface {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result p1

    invoke-virtual {p3, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->add(F)V

    return-void
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 65
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixel;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 66
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->imageWidth:I

    .line 67
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->imageHeight:I

    return-void
.end method

.method public setMarker(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 4

    .line 80
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->addAllFeatures(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->removeOutsideCornerFeatures()V

    .line 83
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->computeTransform()V

    .line 84
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    add-double/2addr v0, v2

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    add-double/2addr v0, v2

    double-to-float p1, v0

    const/high16 v0, 0x40400000    # 3.0f

    div-float/2addr p1, v0

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->threshold:F

    return-void
.end method

.method public setMarkerUnknownVersion(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;F)V
    .locals 1

    const/4 v0, 0x0

    .line 94
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    .line 95
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setTransformFromLinesSquare(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 96
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->threshold:F

    return-void
.end method

.method public setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V
    .locals 1

    const/4 v0, 0x0

    .line 88
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->transformGrid:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->setTransformFromSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    .line 90
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->threshold:F

    return-void
.end method
