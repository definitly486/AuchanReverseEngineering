.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;
.super Ljava/lang/Object;
.source "EigenvalueSmall_F64.java"


# instance fields
.field public value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

.field public value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 28
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    .line 29
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    return-void
.end method


# virtual methods
.method public symm2x2_fast(DDD)V
    .locals 4

    add-double v0, p1, p5

    const-wide/high16 v2, 0x3fe0000000000000L    # 0.5

    mul-double/2addr v0, v2

    sub-double/2addr p1, p5

    mul-double/2addr p1, v2

    mul-double/2addr p1, p1

    mul-double/2addr p3, p3

    add-double/2addr p1, p3

    .line 124
    invoke-static {p1, p2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p1

    .line 125
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    add-double p4, v0, p1

    iput-wide p4, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    .line 126
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    sub-double/2addr v0, p1

    iput-wide v0, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    return-void
.end method
