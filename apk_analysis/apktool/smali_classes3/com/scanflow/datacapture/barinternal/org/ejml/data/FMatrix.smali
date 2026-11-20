.class public interface abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;
.super Ljava/lang/Object;
.source "FMatrix.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;


# virtual methods
.method public abstract get(II)F
.end method

.method public getNumElements()I
    .locals 2

    .line 78
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    mul-int/2addr v0, v1

    return v0
.end method

.method public abstract unsafe_get(II)F
.end method

.method public abstract unsafe_set(IIF)V
.end method
