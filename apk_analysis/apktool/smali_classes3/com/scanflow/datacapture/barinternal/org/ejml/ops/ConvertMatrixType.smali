.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixType;
.super Ljava/lang/Object;
.source "ConvertMatrixType.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 5

    .line 39
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixType$1;->$SwitchMap$org$ejml$data$MatrixType:[I

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v1, v0, v1

    const/4 v2, 0x4

    const/4 v3, 0x3

    const/4 v4, 0x0

    packed-switch v1, :pswitch_data_0

    goto/16 :goto_0

    .line 166
    :pswitch_0
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_1

    goto/16 :goto_0

    .line 168
    :pswitch_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    goto/16 :goto_0

    .line 191
    :pswitch_2
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    .line 192
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    goto/16 :goto_0

    .line 186
    :pswitch_3
    new-instance v4, Lorg/ejml/data/CMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 187
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V

    goto/16 :goto_0

    .line 181
    :pswitch_4
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 182
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V

    goto/16 :goto_0

    .line 176
    :pswitch_5
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    .line 177
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/FConvertMatrixStruct;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    goto/16 :goto_0

    .line 171
    :pswitch_6
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 172
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    goto/16 :goto_0

    .line 133
    :pswitch_7
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_2

    goto/16 :goto_0

    .line 158
    :pswitch_8
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    .line 159
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    goto/16 :goto_0

    .line 135
    :pswitch_9
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    goto/16 :goto_0

    .line 153
    :pswitch_a
    new-instance v4, Lorg/ejml/data/CMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 154
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V

    goto/16 :goto_0

    .line 148
    :pswitch_b
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 149
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V

    goto/16 :goto_0

    .line 143
    :pswitch_c
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    .line 144
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    goto/16 :goto_0

    .line 138
    :pswitch_d
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 139
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/DConvertMatrixStruct;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    goto/16 :goto_0

    .line 120
    :pswitch_e
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    if-eq v0, v3, :cond_1

    if-eq v0, v2, :cond_0

    goto/16 :goto_0

    .line 122
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    goto/16 :goto_0

    .line 125
    :cond_1
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 126
    move-object v0, p0

    check-cast v0, Lorg/ejml/data/CMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V

    goto/16 :goto_0

    .line 107
    :pswitch_f
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    if-eq v0, v3, :cond_3

    if-eq v0, v2, :cond_2

    goto/16 :goto_0

    .line 112
    :cond_2
    new-instance v4, Lorg/ejml/data/CMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 113
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V

    goto/16 :goto_0

    .line 109
    :cond_3
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    goto/16 :goto_0

    .line 74
    :pswitch_10
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_3

    goto/16 :goto_0

    .line 99
    :pswitch_11
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    .line 100
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/FConvertMatrixStruct;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    goto/16 :goto_0

    .line 94
    :pswitch_12
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    .line 95
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    goto/16 :goto_0

    .line 89
    :pswitch_13
    new-instance v4, Lorg/ejml/data/CMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 90
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V

    goto/16 :goto_0

    .line 84
    :pswitch_14
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 85
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    goto/16 :goto_0

    .line 76
    :pswitch_15
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    goto/16 :goto_0

    .line 79
    :pswitch_16
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 80
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    goto/16 :goto_0

    .line 41
    :pswitch_17
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_4

    goto :goto_0

    .line 66
    :pswitch_18
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    .line 67
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    goto :goto_0

    .line 61
    :pswitch_19
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    .line 62
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/DConvertMatrixStruct;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    goto :goto_0

    .line 56
    :pswitch_1a
    new-instance v4, Lorg/ejml/data/CMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 57
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V

    goto :goto_0

    .line 51
    :pswitch_1b
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 52
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    goto :goto_0

    .line 46
    :pswitch_1c
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    invoke-direct {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    .line 47
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V

    goto :goto_0

    .line 43
    :pswitch_1d
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v4

    :goto_0
    if-eqz v4, :cond_4

    return-object v4

    .line 200
    :cond_4
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string p0, " "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_17
        :pswitch_10
        :pswitch_f
        :pswitch_e
        :pswitch_7
        :pswitch_0
    .end packed-switch

    :pswitch_data_1
    .packed-switch 0x1
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
    .end packed-switch

    :pswitch_data_2
    .packed-switch 0x1
        :pswitch_d
        :pswitch_c
        :pswitch_b
        :pswitch_a
        :pswitch_9
        :pswitch_8
    .end packed-switch

    :pswitch_data_3
    .packed-switch 0x1
        :pswitch_16
        :pswitch_15
        :pswitch_14
        :pswitch_13
        :pswitch_12
        :pswitch_11
    .end packed-switch

    :pswitch_data_4
    .packed-switch 0x1
        :pswitch_1d
        :pswitch_1c
        :pswitch_1b
        :pswitch_1a
        :pswitch_19
        :pswitch_18
    .end packed-switch
.end method
