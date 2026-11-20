.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;
.source "Matrix3x3_F64.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 28
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    return-void
.end method


# virtual methods
.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;)V
    .locals 2

    .line 36
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    .line 37
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    .line 38
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-void
.end method
