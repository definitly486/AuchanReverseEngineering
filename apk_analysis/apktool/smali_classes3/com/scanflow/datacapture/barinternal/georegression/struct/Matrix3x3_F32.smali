.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;
.source "Matrix3x3_F32.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 30
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;-><init>()V

    return-void
.end method


# virtual methods
.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;)V
    .locals 1

    .line 38
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    .line 39
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    .line 40
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    return-void
.end method
