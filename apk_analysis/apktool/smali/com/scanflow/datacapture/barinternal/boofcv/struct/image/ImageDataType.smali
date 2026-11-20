.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
.super Ljava/lang/Enum;
.source "ImageDataType.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum F:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum I:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum I16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum I8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field public static final enum U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;


# instance fields
.field private final createArray:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;

.field private final dataType:Ljava/lang/Class;

.field private final isAbstract:Z

.field private final isInteger:Z

.field private final isSigned:Z

.field private final maxValue:D

.field private final minValue:D

.field private final numBits:I

.field private final sumType:Ljava/lang/Class;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 12

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v10, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    sget-object v11, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    filled-new-array/range {v0 .. v11}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 19

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v1, "U8"

    const/4 v2, 0x0

    const/4 v3, 0x0

    sget-object v4, Ljava/lang/Byte;->TYPE:Ljava/lang/Class;

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 34
    new-instance v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v11, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {v11}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v7, "S8"

    const/4 v8, 0x1

    const/4 v9, 0x1

    move-object v10, v4

    invoke-direct/range {v6 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 36
    new-instance v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v12, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {v12}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v8, "U16"

    const/4 v9, 0x2

    const/4 v10, 0x0

    sget-object v17, Ljava/lang/Short;->TYPE:Ljava/lang/Class;

    move-object/from16 v11, v17

    invoke-direct/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 38
    new-instance v13, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v18, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct/range {v18 .. v18}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v14, "S16"

    const/4 v15, 0x3

    const/16 v16, 0x1

    invoke-direct/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v13, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 40
    new-instance v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v10, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v6, "S32"

    const/4 v7, 0x4

    const/4 v8, 0x1

    sget-object v9, Ljava/lang/Integer;->TYPE:Ljava/lang/Class;

    invoke-direct/range {v5 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 42
    new-instance v12, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v17, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct/range {v17 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v13, "S64"

    const/4 v14, 0x5

    const/4 v15, 0x1

    sget-object v16, Ljava/lang/Long;->TYPE:Ljava/lang/Class;

    invoke-direct/range {v12 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v12, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 44
    new-instance v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v10, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v6, "F32"

    const/4 v7, 0x6

    sget-object v9, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    invoke-direct/range {v5 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 46
    new-instance v12, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    new-instance v17, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct/range {v17 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    const-string v13, "F64"

    const/4 v14, 0x7

    sget-object v16, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    invoke-direct/range {v12 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V

    sput-object v12, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    const-string v1, "I8"

    const/16 v2, 0x8

    invoke-direct {v0, v1, v2, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;ILjava/lang/Class;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    const-string v1, "I16"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;ILjava/lang/Class;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    const-string v1, "I"

    const/16 v2, 0xa

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 54
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    const-string v1, "F"

    const/16 v2, 0xb

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;-><init>(Ljava/lang/String;IZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 28
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;ILjava/lang/Class;)V
    .locals 0

    .line 88
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    const/4 p1, 0x1

    .line 89
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isAbstract:Z

    .line 90
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->dataType:Ljava/lang/Class;

    const/4 p1, 0x0

    .line 91
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    .line 92
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectNumBits(Ljava/lang/Class;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    .line 93
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectInteger(Ljava/lang/Class;)Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    .line 94
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectSumType(Ljava/lang/Class;)Ljava/lang/Class;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->sumType:Ljava/lang/Class;

    .line 95
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->createArray:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;

    const-wide/high16 p1, 0x7ff8000000000000L    # Double.NaN

    .line 96
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->minValue:D

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->maxValue:D

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;IZ)V
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    const/4 p1, 0x1

    .line 78
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isAbstract:Z

    .line 79
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    const/4 p1, 0x0

    .line 80
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    const/4 p1, -0x1

    .line 81
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    .line 82
    const-class p1, Ljava/lang/Object;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->dataType:Ljava/lang/Class;

    .line 83
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->sumType:Ljava/lang/Class;

    const-wide/high16 p1, 0x7ff8000000000000L    # Double.NaN

    .line 84
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->minValue:D

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->maxValue:D

    .line 85
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$$ExternalSyntheticLambda0;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->createArray:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;IZLjava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;)V
    .locals 0

    .line 99
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    const/4 p1, 0x0

    .line 100
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isAbstract:Z

    .line 101
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    .line 102
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->dataType:Ljava/lang/Class;

    .line 103
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->createArray:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType$CreateArray;

    .line 104
    invoke-direct {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectNumBits(Ljava/lang/Class;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    .line 105
    invoke-direct {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectInteger(Ljava/lang/Class;)Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    .line 106
    invoke-direct {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectSumType(Ljava/lang/Class;)Ljava/lang/Class;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->sumType:Ljava/lang/Class;

    .line 107
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectMinValue()D

    move-result-wide p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->minValue:D

    .line 108
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->selectMaxValue()D

    move-result-wide p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->maxValue:D

    return-void
.end method

.method public static classToType(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 3

    .line 114
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_0

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 115
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_1

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 116
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_2

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 117
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_3

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 118
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_4

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 119
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_5

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 120
    :cond_5
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_6

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 121
    :cond_6
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_7

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 122
    :cond_7
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_8

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 123
    :cond_8
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_9

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 124
    :cond_9
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_a

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 125
    :cond_a
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_b

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 126
    :cond_b
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_c

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 127
    :cond_c
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_d

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 128
    :cond_d
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_e

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 129
    :cond_e
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_f

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 130
    :cond_f
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_10

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 131
    :cond_10
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_11

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 132
    :cond_11
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_12

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 133
    :cond_12
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_13

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 134
    :cond_13
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_14

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 135
    :cond_14
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;

    invoke-virtual {v0, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_15

    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->I16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0

    .line 137
    :cond_15
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Class;->getCanonicalName()Ljava/lang/String;

    move-result-object p0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown image type. class="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method private selectInteger(Ljava/lang/Class;)Z
    .locals 1

    .line 194
    sget-object v0, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    if-eq p1, v0, :cond_0

    sget-object v0, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    if-eq p1, v0, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method private selectMaxValue()D
    .locals 5

    .line 229
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    const/16 v1, 0x40

    const/16 v2, 0x20

    if-eqz v0, :cond_8

    .line 230
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    const/16 v3, 0x8

    const/4 v4, 0x0

    if-eq v0, v3, :cond_6

    const/16 v3, 0x10

    if-eq v0, v3, :cond_4

    if-eq v0, v2, :cond_2

    if-ne v0, v1, :cond_1

    .line 234
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    if-eqz v0, :cond_0

    const-wide/16 v0, 0x0

    goto :goto_0

    :cond_0
    const-wide/high16 v0, -0x8000000000000000L

    :goto_0
    long-to-double v0, v0

    const-wide/high16 v2, 0x43e0000000000000L    # 9.223372036854776E18

    :goto_1
    sub-double/2addr v2, v0

    return-wide v2

    .line 235
    :cond_1
    new-instance v0, Ljava/lang/RuntimeException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected number of bits for integer type: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 233
    :cond_2
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    if-eqz v0, :cond_3

    goto :goto_2

    :cond_3
    const/high16 v4, -0x80000000

    :goto_2
    int-to-double v0, v4

    const-wide v2, 0x41dfffffffc00000L    # 2.147483647E9

    goto :goto_1

    .line 232
    :cond_4
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    if-eqz v0, :cond_5

    goto :goto_3

    :cond_5
    const/16 v4, -0x8000

    :goto_3
    int-to-double v0, v4

    const-wide v2, 0x40dfffc000000000L    # 32767.0

    goto :goto_1

    .line 231
    :cond_6
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    if-eqz v0, :cond_7

    goto :goto_4

    :cond_7
    const/16 v4, -0x80

    :goto_4
    int-to-double v0, v4

    const-wide v2, 0x405fc00000000000L    # 127.0

    goto :goto_1

    .line 238
    :cond_8
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    if-eq v0, v2, :cond_a

    if-ne v0, v1, :cond_9

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    return-wide v0

    .line 241
    :cond_9
    new-instance v0, Ljava/lang/RuntimeException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected number of bits for float type: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_a
    const-wide v0, 0x47efffffe0000000L    # 3.4028234663852886E38

    return-wide v0
.end method

.method private selectMinValue()D
    .locals 4

    .line 209
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    if-eqz v0, :cond_0

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isSigned:Z

    if-nez v1, :cond_0

    const-wide/16 v0, 0x0

    return-wide v0

    :cond_0
    const/16 v1, 0x40

    const/16 v2, 0x20

    if-eqz v0, :cond_5

    .line 212
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    const/16 v3, 0x8

    if-eq v0, v3, :cond_4

    const/16 v3, 0x10

    if-eq v0, v3, :cond_3

    if-eq v0, v2, :cond_2

    if-ne v0, v1, :cond_1

    const-wide/high16 v0, -0x3c20000000000000L    # -9.223372036854776E18

    return-wide v0

    .line 217
    :cond_1
    new-instance v0, Ljava/lang/RuntimeException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected number of bits for integer type: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_2
    const-wide/high16 v0, -0x3e20000000000000L    # -2.147483648E9

    return-wide v0

    :cond_3
    const-wide/high16 v0, -0x3f20000000000000L    # -32768.0

    return-wide v0

    :cond_4
    const-wide/high16 v0, -0x3fa0000000000000L    # -128.0

    return-wide v0

    .line 220
    :cond_5
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    if-eq v0, v2, :cond_7

    if-ne v0, v1, :cond_6

    const-wide v0, -0x10000000000001L

    return-wide v0

    .line 223
    :cond_6
    new-instance v0, Ljava/lang/RuntimeException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected number of bits for float type: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_7
    const-wide v0, -0x3810000020000000L    # -3.4028234663852886E38

    return-wide v0
.end method

.method private selectNumBits(Ljava/lang/Class;)I
    .locals 4

    const/16 v0, 0x40

    const/16 v1, 0x20

    .line 175
    sget-object v2, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    if-eq p1, v2, :cond_5

    sget-object v3, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    if-ne p1, v3, :cond_0

    goto :goto_0

    .line 181
    :cond_0
    sget-object v2, Ljava/lang/Byte;->TYPE:Ljava/lang/Class;

    if-ne p1, v2, :cond_1

    const/16 p1, 0x8

    return p1

    .line 183
    :cond_1
    sget-object v2, Ljava/lang/Short;->TYPE:Ljava/lang/Class;

    if-ne p1, v2, :cond_2

    const/16 p1, 0x10

    return p1

    .line 185
    :cond_2
    sget-object v2, Ljava/lang/Integer;->TYPE:Ljava/lang/Class;

    if-ne p1, v2, :cond_3

    return v1

    .line 187
    :cond_3
    sget-object v1, Ljava/lang/Long;->TYPE:Ljava/lang/Class;

    if-ne p1, v1, :cond_4

    return v0

    :cond_4
    const/4 p1, -0x1

    return p1

    :cond_5
    :goto_0
    if-ne p1, v2, :cond_6

    return v1

    :cond_6
    return v0
.end method

.method private selectSumType(Ljava/lang/Class;)Ljava/lang/Class;
    .locals 1

    .line 198
    sget-object v0, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    if-eq p1, v0, :cond_2

    sget-object v0, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    if-ne p1, v0, :cond_0

    goto :goto_0

    .line 201
    :cond_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    const/16 v0, 0x20

    if-gt p1, v0, :cond_1

    .line 202
    sget-object p1, Ljava/lang/Integer;->TYPE:Ljava/lang/Class;

    return-object p1

    .line 204
    :cond_1
    sget-object p1, Ljava/lang/Long;->TYPE:Ljava/lang/Class;

    :cond_2
    :goto_0
    return-object p1
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 28
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method


# virtual methods
.method public getDataType()Ljava/lang/Class;
    .locals 1

    .line 69
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->dataType:Ljava/lang/Class;

    return-object v0
.end method

.method public getNumBits()I
    .locals 1

    .line 57
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->numBits:I

    return v0
.end method

.method public isInteger()Z
    .locals 1

    .line 63
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger:Z

    return v0
.end method
