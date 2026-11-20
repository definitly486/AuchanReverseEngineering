.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
.source "SimpleMatrix.java"


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 262
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;-><init>()V

    return-void
.end method

.method public constructor <init>(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)V
    .locals 1

    .line 217
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;-><init>()V

    .line 218
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix$1;->$SwitchMap$org$ejml$data$MatrixType:[I

    invoke-virtual {p3}, Ljava/lang/Enum;->ordinal()I

    move-result p3

    aget p3, v0, p3

    packed-switch p3, :pswitch_data_0

    .line 225
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Unknown matrix type"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 224
    :pswitch_0
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-direct {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    .line 223
    :pswitch_1
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-direct {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    .line 222
    :pswitch_2
    new-instance p3, Lorg/ejml/data/CMatrixRMaj;

    invoke-direct {p3, p1, p2}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    .line 221
    :pswitch_3
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-direct {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    .line 220
    :pswitch_4
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-direct {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    .line 219
    :pswitch_5
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 243
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;-><init>()V

    .line 254
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p1

    .line 256
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void
.end method

.method public static wrap(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;
    .locals 1

    .line 271
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;-><init>()V

    .line 272
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-object v0
.end method


# virtual methods
.method protected bridge synthetic createMatrix(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
    .locals 0

    .line 88
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;->createMatrix(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    move-result-object p1

    return-object p1
.end method

.method protected createMatrix(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;
    .locals 1

    .line 450
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    invoke-direct {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;-><init>(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)V

    return-object v0
.end method

.method protected bridge synthetic wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
    .locals 0

    .line 88
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;->wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    move-result-object p1

    return-object p1
.end method

.method protected wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;
    .locals 1

    .line 455
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-object v0
.end method
