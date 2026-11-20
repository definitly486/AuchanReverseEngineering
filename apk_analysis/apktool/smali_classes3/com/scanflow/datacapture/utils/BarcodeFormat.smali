.class public final enum Lcom/scanflow/datacapture/utils/BarcodeFormat;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/utils/BarcodeFormat;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum AZTEC:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum CODABAR:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum CODE_128:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum CODE_39:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum CODE_93:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum DATA_MATRIX:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum EAN_13:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum EAN_8:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum ITF:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum MAXICODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum PDF_417:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum RSS_14:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum RSS_EXPANDED:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum UPC_A:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum UPC_E:Lcom/scanflow/datacapture/utils/BarcodeFormat;

.field public static final enum UPC_EAN_EXTENSION:Lcom/scanflow/datacapture/utils/BarcodeFormat;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 18

    .line 0
    sget-object v1, Lcom/scanflow/datacapture/utils/BarcodeFormat;->AZTEC:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v2, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODABAR:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v3, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_39:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v4, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_93:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v5, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_128:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v6, Lcom/scanflow/datacapture/utils/BarcodeFormat;->DATA_MATRIX:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v7, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_8:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v8, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_13:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v9, Lcom/scanflow/datacapture/utils/BarcodeFormat;->ITF:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v10, Lcom/scanflow/datacapture/utils/BarcodeFormat;->MAXICODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v11, Lcom/scanflow/datacapture/utils/BarcodeFormat;->PDF_417:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v12, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v13, Lcom/scanflow/datacapture/utils/BarcodeFormat;->RSS_14:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v14, Lcom/scanflow/datacapture/utils/BarcodeFormat;->RSS_EXPANDED:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v15, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_A:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v16, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_E:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    sget-object v17, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_EAN_EXTENSION:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    filled-new-array/range {v1 .. v17}, [Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "AZTEC"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->AZTEC:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "CODABAR"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODABAR:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "CODE_39"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_39:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "CODE_93"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_93:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "CODE_128"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_128:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "DATA_MATRIX"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->DATA_MATRIX:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "EAN_8"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_8:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "EAN_13"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_13:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "ITF"

    const/16 v2, 0x8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->ITF:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "MAXICODE"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->MAXICODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "PDF_417"

    const/16 v2, 0xa

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->PDF_417:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "QR_CODE"

    const/16 v2, 0xb

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "RSS_14"

    const/16 v2, 0xc

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->RSS_14:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "RSS_EXPANDED"

    const/16 v2, 0xd

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->RSS_EXPANDED:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "UPC_A"

    const/16 v2, 0xe

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_A:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "UPC_E"

    const/16 v2, 0xf

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_E:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    const-string v1, "UPC_EAN_EXTENSION"

    const/16 v2, 0x10

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/utils/BarcodeFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_EAN_EXTENSION:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    invoke-static {}, Lcom/scanflow/datacapture/utils/BarcodeFormat;->$values()[Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->$VALUES:[Lcom/scanflow/datacapture/utils/BarcodeFormat;

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

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->$VALUES:[Lcom/scanflow/datacapture/utils/BarcodeFormat;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/utils/BarcodeFormat;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object v0
.end method
