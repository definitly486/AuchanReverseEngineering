.class public final enum Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
.super Ljava/lang/Enum;
.source "MatrixType.java"


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum CDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum CSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum DSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum DTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum FDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum FSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum FTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum ZDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

.field public static final enum ZSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;


# instance fields
.field final bits:I

.field final classType:Ljava/lang/Class;

.field final dense:Z

.field final fixed:Z

.field final real:Z


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 11

    .line 26
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    sget-object v10, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    filled-new-array/range {v0 .. v10}, [Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 14

    .line 28
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v5, 0x40

    const-class v6, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const-string v1, "DDRM"

    const/4 v2, 0x0

    const/4 v3, 0x1

    const/4 v4, 0x1

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 29
    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v6, 0x20

    const-class v7, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    const-string v2, "FDRM"

    const/4 v5, 0x1

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 30
    new-instance v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v7, 0x40

    const-class v8, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    const-string v3, "ZDRM"

    const/4 v4, 0x2

    const/4 v5, 0x0

    const/4 v6, 0x1

    invoke-direct/range {v2 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 31
    new-instance v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v8, 0x20

    const-class v9, Lorg/ejml/data/CMatrixRMaj;

    const-string v4, "CDRM"

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v7, 0x1

    invoke-direct/range {v3 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 32
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v9, 0x40

    const-class v10, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    const-string v5, "DSCC"

    const/4 v6, 0x4

    const/4 v8, 0x0

    invoke-direct/range {v4 .. v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 33
    new-instance v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v10, 0x20

    const-class v11, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    const-string v6, "FSCC"

    const/4 v7, 0x5

    const/4 v8, 0x1

    const/4 v9, 0x0

    invoke-direct/range {v5 .. v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 34
    new-instance v6, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v11, 0x40

    const-class v12, Ljava/lang/Object;

    const-string v7, "ZSCC"

    const/4 v8, 0x6

    const/4 v10, 0x0

    invoke-direct/range {v6 .. v12}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v6, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 35
    new-instance v7, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v12, 0x20

    const-class v13, Ljava/lang/Object;

    const-string v8, "CSCC"

    const/4 v9, 0x7

    const/4 v11, 0x0

    invoke-direct/range {v7 .. v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v7, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 36
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v5, 0x40

    const-class v6, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseTriplet;

    const-string v1, "DTRIPLET"

    const/16 v2, 0x8

    const/4 v3, 0x0

    const/4 v4, 0x0

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 37
    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/16 v6, 0x40

    const-class v7, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseTriplet;

    const-string v2, "FTRIPLET"

    const/16 v3, 0x9

    const/4 v5, 0x0

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FTRIPLET:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 38
    new-instance v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    const/4 v7, 0x0

    const-class v8, Ljava/lang/Object;

    const-string v3, "UNSPECIFIED"

    const/16 v4, 0xa

    const/4 v6, 0x0

    invoke-direct/range {v2 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZILjava/lang/Class;)V

    sput-object v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    .line 26
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->$values()[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;IZZILjava/lang/Class;)V
    .locals 8

    const/4 v3, 0x0

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move v4, p3

    move v5, p4

    move v6, p5

    move-object v7, p6

    .line 47
    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;-><init>(Ljava/lang/String;IZZZILjava/lang/Class;)V

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;IZZZILjava/lang/Class;)V
    .locals 0

    .line 50
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 51
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->real:Z

    .line 52
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->fixed:Z

    .line 53
    iput-boolean p5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->dense:Z

    .line 54
    iput p6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->bits:I

    .line 55
    iput-object p7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->classType:Ljava/lang/Class;

    return-void
.end method

.method public static lookup(ZZI)Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    const/16 v0, 0x40

    if-eqz p0, :cond_3

    if-eqz p1, :cond_1

    if-ne p2, v0, :cond_0

    .line 82
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    .line 84
    :cond_0
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    :cond_1
    if-ne p2, v0, :cond_2

    .line 88
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    .line 90
    :cond_2
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    :cond_3
    if-eqz p1, :cond_5

    if-ne p2, v0, :cond_4

    .line 96
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    .line 98
    :cond_4
    sget-object p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0

    .line 101
    :cond_5
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Complex sparse not yet supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 26
    const-class v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 26
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method


# virtual methods
.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 2

    .line 127
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType$1;->$SwitchMap$org$ejml$data$MatrixType:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_0

    .line 137
    new-instance p1, Ljava/lang/RuntimeException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unknown Matrix Type "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 133
    :pswitch_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    return-object v0

    .line 132
    :pswitch_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    return-object v0

    .line 131
    :pswitch_2
    new-instance v0, Lorg/ejml/data/CMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    return-object v0

    .line 130
    :pswitch_3
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    return-object v0

    .line 129
    :pswitch_4
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    return-object v0

    .line 128
    :pswitch_5
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object v0

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

.method public getBits()I
    .locals 1

    .line 119
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->bits:I

    return v0
.end method

.method public getClassType()Ljava/lang/Class;
    .locals 1

    .line 123
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->classType:Ljava/lang/Class;

    return-object v0
.end method

.method public isDense()Z
    .locals 1

    .line 115
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->dense:Z

    return v0
.end method

.method public isReal()Z
    .locals 1

    .line 107
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->real:Z

    return v0
.end method
