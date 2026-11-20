.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/UtilHomography_F64;
.super Ljava/lang/Object;
.source "UtilHomography_F64.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;
    .locals 5

    .line 41
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ne v0, v1, :cond_1

    if-nez p1, :cond_0

    .line 45
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>()V

    :cond_0
    const/4 v0, 0x0

    .line 47
    invoke-virtual {p0, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v1

    iput-wide v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    const/4 v1, 0x1

    .line 48
    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v2

    iput-wide v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    const/4 v2, 0x2

    .line 49
    invoke-virtual {p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v3

    iput-wide v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    .line 50
    invoke-virtual {p0, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v3

    iput-wide v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    .line 51
    invoke-virtual {p0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v3

    iput-wide v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    .line 52
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v3

    iput-wide v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    .line 53
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v3

    iput-wide v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    .line 54
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    .line 55
    invoke-virtual {p0, v2, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-object p1

    .line 42
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Expected a 3 by 3 matrix."

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
