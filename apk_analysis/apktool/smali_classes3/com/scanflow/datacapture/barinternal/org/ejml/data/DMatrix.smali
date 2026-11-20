.class public interface abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;
.super Ljava/lang/Object;
.source "DMatrix.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;


# virtual methods
.method public abstract get(II)D
.end method

.method public getNumElements()I
    .locals 2

    .line 76
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    mul-int/2addr v0, v1

    return v0
.end method

.method public abstract set(IID)V
.end method

.method public abstract unsafe_get(II)D
.end method

.method public abstract unsafe_set(IID)V
.end method
