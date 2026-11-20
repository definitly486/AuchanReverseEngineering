.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;
.super Ljava/lang/Enum;
.source "QrCode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Failure"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum ALIGNMENT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum DECODING_MESSAGE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum ERROR_CORRECTION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum FORMAT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum KANJI_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum READING_BITS:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum READING_PADDING:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum STRING_ENCODING_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum UNKNOWN_MODE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public static final enum VERSION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;
    .locals 12

    .line 636
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->FORMAT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->VERSION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ALIGNMENT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_BITS:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ERROR_CORRECTION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->UNKNOWN_MODE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_PADDING:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->DECODING_MESSAGE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v10, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->KANJI_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v11, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->STRING_ENCODING_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    filled-new-array/range {v0 .. v11}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 637
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "NONE"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 638
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "FORMAT"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->FORMAT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 639
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "VERSION"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->VERSION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 640
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "ALIGNMENT"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ALIGNMENT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 641
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "READING_BITS"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_BITS:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 642
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "ERROR_CORRECTION"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ERROR_CORRECTION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 643
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "UNKNOWN_MODE"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->UNKNOWN_MODE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 644
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "READING_PADDING"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_PADDING:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 645
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "MESSAGE_OVERFLOW"

    const/16 v2, 0x8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 646
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "DECODING_MESSAGE"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->DECODING_MESSAGE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 647
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "KANJI_UNAVAILABLE"

    const/16 v2, 0xa

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->KANJI_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 648
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    const-string v1, "STRING_ENCODING_UNAVAILABLE"

    const/16 v2, 0xb

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->STRING_ENCODING_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 636
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 636
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;
    .locals 1

    .line 636
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;
    .locals 1

    .line 636
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return-object v0
.end method
