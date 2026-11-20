.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;
.super Ljava/lang/Object;
.source "NormalizationPoint2D.java"


# instance fields
.field public meanX:D

.field public meanY:D

.field public stdX:D

.field public stdY:D

.field private work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;


# direct methods
.method public constructor <init>()V
    .locals 4

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/16 v0, 0x0

    .line 48
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanX:D

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    .line 49
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanY:D

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    return-void
.end method


# virtual methods
.method public apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 4

    .line 111
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanX:D

    sub-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    div-double/2addr v0, v2

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 112
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanY:D

    sub-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    div-double/2addr v0, v2

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-void
.end method

.method public apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)V
    .locals 6

    .line 116
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanX:D

    mul-double/2addr v4, v2

    sub-double/2addr v0, v4

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    div-double/2addr v0, v4

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    .line 117
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanY:D

    mul-double/2addr v2, v4

    sub-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    div-double/2addr v0, v2

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    return-void
.end method

.method public matrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 9

    const/4 v0, 0x3

    if-nez p1, :cond_0

    .line 164
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    goto :goto_0

    .line 166
    :cond_0
    invoke-virtual {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 167
    :goto_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    div-double v0, v2, v0

    const/4 v4, 0x0

    invoke-virtual {p1, v4, v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 168
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    div-double v0, v2, v0

    const/4 v5, 0x1

    invoke-virtual {p1, v5, v5, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 169
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanX:D

    neg-double v0, v0

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    div-double/2addr v0, v6

    const/4 v6, 0x2

    invoke-virtual {p1, v4, v6, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 170
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanY:D

    neg-double v0, v0

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    div-double/2addr v0, v7

    invoke-virtual {p1, v5, v6, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 171
    invoke-virtual {p1, v6, v6, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    return-object p1
.end method

.method public matrixInv(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 5

    const/4 v0, 0x3

    if-nez p1, :cond_0

    .line 177
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    goto :goto_0

    .line 179
    :cond_0
    invoke-virtual {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 180
    :goto_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdX:D

    const/4 v2, 0x0

    invoke-virtual {p1, v2, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 181
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->stdY:D

    const/4 v3, 0x1

    invoke-virtual {p1, v3, v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 182
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanX:D

    const/4 v4, 0x2

    invoke-virtual {p1, v2, v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 183
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->meanY:D

    invoke-virtual {p1, v3, v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 184
    invoke-virtual {p1, v4, v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    return-object p1
.end method
