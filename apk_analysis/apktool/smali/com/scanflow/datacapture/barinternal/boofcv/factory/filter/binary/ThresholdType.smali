.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;
.super Ljava/lang/Enum;
.source "ThresholdType.java"


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum BLOCK_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum BLOCK_MIN_MAX:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum FIXED:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum GLOBAL_ENTROPY:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum GLOBAL_HUANG:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum GLOBAL_LI:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum GLOBAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_GAUSSIAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_NICK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_SAVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public static final enum LOCAL_WOLF:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;


# instance fields
.field final adaptive:Z

.field final global:Z


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;
    .locals 15

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->FIXED:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_ENTROPY:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_LI:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_HUANG:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_GAUSSIAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MIN_MAX:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v10, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v11, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v12, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_SAVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v13, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_WOLF:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    sget-object v14, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_NICK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    filled-new-array/range {v0 .. v14}, [Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 5

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "FIXED"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->FIXED:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 38
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "GLOBAL_ENTROPY"

    invoke-direct {v0, v1, v3, v3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_ENTROPY:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 44
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "GLOBAL_OTSU"

    const/4 v4, 0x2

    invoke-direct {v0, v1, v4, v3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "GLOBAL_LI"

    const/4 v4, 0x3

    invoke-direct {v0, v1, v4, v3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_LI:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "GLOBAL_HUANG"

    const/4 v4, 0x4

    invoke-direct {v0, v1, v4, v3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->GLOBAL_HUANG:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_GAUSSIAN"

    const/4 v4, 0x5

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_GAUSSIAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 68
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_MEAN"

    const/4 v4, 0x6

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 74
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_OTSU"

    const/4 v4, 0x7

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 81
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "BLOCK_MIN_MAX"

    const/16 v4, 0x8

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MIN_MAX:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 88
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "BLOCK_MEAN"

    const/16 v4, 0x9

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MEAN:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 95
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "BLOCK_OTSU"

    const/16 v4, 0xa

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 102
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_NIBLACK"

    const/16 v4, 0xb

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 109
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_SAVOLA"

    const/16 v4, 0xc

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_SAVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 116
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_WOLF"

    const/16 v4, 0xd

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_WOLF:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 123
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    const-string v1, "LOCAL_NICK"

    const/16 v4, 0xe

    invoke-direct {v0, v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;-><init>(Ljava/lang/String;IZZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->LOCAL_NICK:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 28
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;IZZ)V
    .locals 0

    .line 128
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 129
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->adaptive:Z

    .line 130
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->global:Z

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;
    .locals 1

    .line 28
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;
    .locals 1

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    return-object v0
.end method


# virtual methods
.method public isAdaptive()Z
    .locals 1

    .line 134
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->adaptive:Z

    return v0
.end method

.method public isGlobal()Z
    .locals 1

    .line 138
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->global:Z

    return v0
.end method
