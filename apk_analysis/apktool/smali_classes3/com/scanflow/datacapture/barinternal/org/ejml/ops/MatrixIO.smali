.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;
.super Ljava/lang/Object;
.source "MatrixIO.java"


# static fields
.field public static MATLAB_FORMAT:Ljava/lang/String; = "%.8E"

.field public static local:Ljava/util/Locale;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 51
    sget-object v0, Ljava/util/Locale;->US:Ljava/util/Locale;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    return-void
.end method

.method private static getMatrixType(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;
    .locals 2

    .line 1037
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    sget-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    if-ne v0, v1, :cond_0

    .line 1038
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    return-object p0

    .line 1040
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;Ljava/lang/String;)V
    .locals 7

    .line 1018
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 1020
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, " "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    .line 1022
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;-><init>()V

    const/4 v1, 0x0

    move v2, v1

    .line 1023
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v3

    if-ge v2, v3, :cond_2

    move v3, v1

    .line 1024
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 1025
    invoke-interface {p1, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->get(IILcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;)V

    .line 1026
    sget-object v4, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->real:F

    invoke-static {v5}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v5

    iget v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->imaginary:F

    invoke-static {v6}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v6

    filled-new-array {v5, v6}, [Ljava/lang/Object;

    move-result-object v5

    invoke-virtual {p0, v4, p2, v5}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 1027
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v4

    add-int/lit8 v4, v4, -0x1

    if-ge v3, v4, :cond_0

    .line 1028
    const-string v4, " , "

    invoke-virtual {p0, v4}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 1031
    :cond_1
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V
    .locals 1

    .line 735
    const-string v0, "%11.4E"

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Ljava/lang/String;)V

    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Ljava/lang/String;)V
    .locals 6

    .line 748
    const-string v0, "matlab"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 749
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    return-void

    .line 750
    :cond_0
    const-string v0, "java"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 751
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printJava(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Ljava/lang/String;)V

    return-void

    .line 753
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 755
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, " "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    const/4 v0, 0x0

    move v1, v0

    .line 757
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    move v2, v0

    .line 758
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_2

    .line 759
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v3, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 761
    :cond_2
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Ljava/lang/String;)V
    .locals 9

    .line 810
    const-string v0, "matlab"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 811
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    return-void

    .line 813
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    const-wide v0, -0x400e3404ea4a8c15L    # -1.1123

    .line 815
    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {p2, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    .line 816
    new-array v1, v0, [C

    const/16 v2, 0x20

    .line 817
    invoke-static {v1, v2}, Ljava/util/Arrays;->fill([CC)V

    .line 818
    div-int/lit8 v0, v0, 0x2

    const/16 v2, 0x2a

    aput-char v2, v1, v0

    const/4 v0, 0x0

    move v2, v0

    .line 820
    :goto_0
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    if-ge v2, v3, :cond_4

    move v3, v0

    .line 821
    :goto_1
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-ge v3, v4, :cond_3

    .line 822
    invoke-virtual {p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_index(II)I

    move-result v4

    if-ltz v4, :cond_1

    .line 824
    sget-object v5, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v7, v6, v4

    invoke-static {v7, v8}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v5, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    goto :goto_2

    .line 826
    :cond_1
    invoke-virtual {p0, v1}, Ljava/io/PrintStream;->print([C)V

    .line 827
    :goto_2
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    add-int/lit8 v4, v4, -0x1

    if-eq v3, v4, :cond_2

    .line 828
    const-string v4, " "

    invoke-virtual {p0, v4}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    :cond_2
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 830
    :cond_3
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseTriplet;Ljava/lang/String;)V
    .locals 0

    .line 862
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    const/4 p0, 0x0

    .line 864
    throw p0
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V
    .locals 1

    .line 918
    const-string v0, "%11.4E"

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Ljava/lang/String;)V

    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Ljava/lang/String;)V
    .locals 5

    .line 922
    const-string v0, "matlab"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 923
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    return-void

    .line 924
    :cond_0
    const-string v0, "java"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 925
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printJava(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Ljava/lang/String;)V

    return-void

    .line 927
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 929
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, " "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    const/4 v0, 0x0

    move v1, v0

    .line 931
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    move v2, v0

    .line 932
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_2

    .line 933
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->get(II)F

    move-result v4

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v3, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 935
    :cond_2
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Ljava/lang/String;)V
    .locals 7

    .line 836
    const-string v0, "matlab"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 837
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    return-void

    .line 839
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    const-wide v0, -0x400e3404ea4a8c15L    # -1.1123

    .line 841
    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {p2, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    .line 842
    new-array v1, v0, [C

    const/16 v2, 0x20

    .line 843
    invoke-static {v1, v2}, Ljava/util/Arrays;->fill([CC)V

    .line 844
    div-int/lit8 v0, v0, 0x2

    const/16 v2, 0x2a

    aput-char v2, v1, v0

    const/4 v0, 0x0

    move v2, v0

    .line 846
    :goto_0
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    if-ge v2, v3, :cond_4

    move v3, v0

    .line 847
    :goto_1
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-ge v3, v4, :cond_3

    .line 848
    invoke-virtual {p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_index(II)I

    move-result v4

    if-ltz v4, :cond_1

    .line 850
    sget-object v5, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v4, v6, v4

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v5, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    goto :goto_2

    .line 852
    :cond_1
    invoke-virtual {p0, v1}, Ljava/io/PrintStream;->print([C)V

    .line 853
    :goto_2
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    add-int/lit8 v4, v4, -0x1

    if-eq v3, v4, :cond_2

    .line 854
    const-string v4, " "

    invoke-virtual {p0, v4}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    :cond_2
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 856
    :cond_3
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseTriplet;Ljava/lang/String;)V
    .locals 0

    .line 879
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    const/4 p0, 0x0

    .line 881
    throw p0
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 3

    .line 721
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO$1;->$SwitchMap$org$ejml$data$MatrixType:[I

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x0

    const-string v2, "%11.4E"

    packed-switch v0, :pswitch_data_0

    .line 730
    new-instance p0, Ljava/lang/RuntimeException;

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unknown type "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 729
    :pswitch_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseTriplet;Ljava/lang/String;)V

    return-void

    .line 728
    :pswitch_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Ljava/lang/String;)V

    return-void

    .line 727
    :pswitch_2
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseTriplet;Ljava/lang/String;)V

    return-void

    .line 726
    :pswitch_3
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Ljava/lang/String;)V

    return-void

    .line 725
    :pswitch_4
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;Ljava/lang/String;)V

    return-void

    .line 724
    :pswitch_5
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;Ljava/lang/String;)V

    return-void

    .line 723
    :pswitch_6
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Ljava/lang/String;)V

    return-void

    .line 722
    :pswitch_7
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;

    invoke-static {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Ljava/lang/String;)V

    return-void

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;Ljava/lang/String;)V
    .locals 8

    .line 990
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 992
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " + "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, "i"

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    .line 994
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;-><init>()V

    const/4 v1, 0x0

    move v2, v1

    .line 995
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v3

    if-ge v2, v3, :cond_2

    move v3, v1

    .line 996
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 997
    invoke-interface {p1, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->get(IILcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;)V

    .line 998
    sget-object v4, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    invoke-static {v5, v6}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v5

    iget-wide v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->imaginary:D

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    filled-new-array {v5, v6}, [Ljava/lang/Object;

    move-result-object v5

    invoke-virtual {p0, v4, p2, v5}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 999
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v4

    add-int/lit8 v4, v4, -0x1

    if-ge v3, v4, :cond_0

    .line 1000
    const-string v4, " , "

    invoke-virtual {p0, v4}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 1003
    :cond_1
    invoke-virtual {p0}, Ljava/io/PrintStream;->println()V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static printJava(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Ljava/lang/String;)V
    .locals 6

    .line 897
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->getBits()I

    move-result v0

    const/16 v1, 0x40

    if-ne v0, v1, :cond_0

    const-string v0, "double"

    goto :goto_0

    :cond_0
    const-string v0, "float"

    .line 899
    :goto_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "new "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "[][]{"

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 901
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, " "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    const/4 v0, 0x0

    move v1, v0

    .line 903
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_4

    .line 904
    const-string v2, "{"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    move v2, v0

    .line 905
    :cond_1
    :goto_2
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_2

    .line 906
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v3, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    .line 907
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_1

    .line 908
    const-string v3, ", "

    invoke-virtual {p0, v3}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    goto :goto_2

    :cond_2
    add-int/lit8 v1, v1, 0x1

    .line 910
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    .line 911
    const-string v2, "},"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    .line 913
    :cond_3
    const-string v2, "}};"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    :cond_4
    return-void
.end method

.method public static printJava(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Ljava/lang/String;)V
    .locals 5

    .line 955
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->getBits()I

    move-result v0

    const/16 v1, 0x40

    if-ne v0, v1, :cond_0

    const-string v0, "double"

    goto :goto_0

    :cond_0
    const-string v0, "float"

    .line 957
    :goto_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "new "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "[][]{"

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 959
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, " "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    const/4 v0, 0x0

    move v1, v0

    .line 961
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_4

    .line 962
    const-string v2, "{"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    move v2, v0

    .line 963
    :cond_1
    :goto_2
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_2

    .line 964
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->get(II)F

    move-result v4

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {p0, v3, p2, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    .line 965
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_1

    .line 966
    const-string v3, ", "

    invoke-virtual {p0, v3}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    goto :goto_2

    :cond_2
    add-int/lit8 v1, v1, 0x1

    .line 968
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    .line 969
    const-string v2, "},"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    .line 971
    :cond_3
    const-string v2, "}};"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    :cond_4
    return-void
.end method

.method public static printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V
    .locals 6

    .line 767
    const-string v0, "[ "

    invoke-virtual {p0, v0}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    const/4 v0, 0x0

    move v1, v0

    .line 769
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    move v2, v0

    .line 770
    :cond_0
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_1

    .line 771
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    filled-new-array {v4}, [Ljava/lang/Object;

    move-result-object v4

    const-string v5, "%.12E"

    invoke-virtual {p0, v3, v5, v4}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    .line 772
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 773
    const-string v3, " , "

    invoke-virtual {p0, v3}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    .line 776
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_2

    .line 777
    const-string v2, " ;"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_0

    .line 779
    :cond_2
    const-string v2, " ]"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static printMatlab(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V
    .locals 6

    .line 784
    const-string v0, "[ "

    invoke-virtual {p0, v0}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    const/4 v0, 0x0

    move v1, v0

    .line 786
    :goto_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_3

    move v2, v0

    .line 787
    :cond_0
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_1

    .line 788
    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->local:Ljava/util/Locale;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->MATLAB_FORMAT:Ljava/lang/String;

    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->get(II)F

    move-result v5

    invoke-static {v5}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v5

    filled-new-array {v5}, [Ljava/lang/Object;

    move-result-object v5

    invoke-virtual {p0, v3, v4, v5}, Ljava/io/PrintStream;->printf(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    add-int/lit8 v2, v2, 0x1

    .line 789
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 790
    const-string v3, " , "

    invoke-virtual {p0, v3}, Ljava/io/PrintStream;->print(Ljava/lang/String;)V

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    .line 793
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_2

    .line 794
    const-string v2, " ;"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_0

    .line 796
    :cond_2
    const-string v2, " ]"

    invoke-virtual {p0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_0

    :cond_3
    return-void
.end method

.method private static printTypeSize(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 7

    .line 1008
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;

    const-string v1, " , cols = "

    const-string v2, " , rows = "

    const-string v3, "Type = "

    if-eqz v0, :cond_0

    .line 1009
    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;

    .line 1010
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->getMatrixType(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;

    move-result-object v4

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v5

    .line 1011
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;->getNonZeroLength()I

    move-result v0

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " , nz_length = "

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 1010
    invoke-virtual {p0, p1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    return-void

    .line 1013
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->getMatrixType(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;

    move-result-object v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v4

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    return-void
.end method
