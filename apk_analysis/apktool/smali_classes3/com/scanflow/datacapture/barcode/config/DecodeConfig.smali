.class public final enum Lcom/scanflow/datacapture/barcode/config/DecodeConfig;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/barcode/config/DecodeConfig;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum ANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum BARCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum BATCH_INVENTORY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum DOTMATRIX_METAL:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum DOTMATRIX_WHITE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum ONE_OF_MANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum PIVOT_VIEW:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

.field public static final enum QRCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;
    .locals 8

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->QRCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v1, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->BARCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v2, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->ANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v3, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->BATCH_INVENTORY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v4, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->ONE_OF_MANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v5, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->PIVOT_VIEW:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v6, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_WHITE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    sget-object v7, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_METAL:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    filled-new-array/range {v0 .. v7}, [Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "QRCODE"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->QRCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "BARCODE"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->BARCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "ANY"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->ANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "BATCH_INVENTORY"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->BATCH_INVENTORY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "ONE_OF_MANY"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->ONE_OF_MANY:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "PIVOT_VIEW"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->PIVOT_VIEW:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "DOTMATRIX_WHITE"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_WHITE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    new-instance v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    const-string v1, "DOTMATRIX_METAL"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_METAL:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    invoke-static {}, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->$values()[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->$VALUES:[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 0
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static getEntries()Lkotlin/enums/EnumEntries;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lkotlin/enums/EnumEntries<",
            "Lcom/scanflow/datacapture/barcode/config/DecodeConfig;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barcode/config/DecodeConfig;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->$VALUES:[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    return-object v0
.end method
