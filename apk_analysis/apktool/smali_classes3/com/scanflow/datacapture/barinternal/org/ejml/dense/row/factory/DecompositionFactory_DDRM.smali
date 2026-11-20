.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;
.super Ljava/lang/Object;
.source "DecompositionFactory_DDRM.java"


# direct methods
.method public static qrp(II)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;
    .locals 0

    .line 182
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;-><init>()V

    return-object p0
.end method

.method public static svd(IIZZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;
    .locals 0

    .line 140
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;

    const/4 p1, 0x0

    invoke-direct {p0, p4, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;-><init>(ZZZZ)V

    return-object p0
.end method
