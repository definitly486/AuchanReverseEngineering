.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
.super Ljava/lang/Enum;
.source "QrCode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Mode"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum ALPHANUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum BYTE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum ECI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum FNC1_FIRST:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum FNC1_SECOND:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum KANJI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum MIXED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum NUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum STRUCTURE_APPENDED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public static final enum UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;


# instance fields
.field final bits:I


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
    .locals 10

    .line 579
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->NUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ALPHANUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->BYTE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->KANJI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ECI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->STRUCTURE_APPENDED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_FIRST:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_SECOND:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->MIXED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    filled-new-array/range {v0 .. v9}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 6

    .line 580
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "NUMERIC"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->NUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 581
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "ALPHANUMERIC"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ALPHANUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 582
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "BYTE"

    const/4 v3, 0x4

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->BYTE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 583
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "KANJI"

    const/4 v2, 0x3

    const/16 v4, 0x8

    invoke-direct {v0, v1, v2, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->KANJI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 584
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "ECI"

    const/4 v5, 0x7

    invoke-direct {v0, v1, v3, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ECI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 585
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "STRUCTURE_APPENDED"

    const/4 v3, 0x5

    invoke-direct {v0, v1, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->STRUCTURE_APPENDED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 586
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "FNC1_FIRST"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_FIRST:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 587
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "FNC1_SECOND"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v5, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_SECOND:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 589
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "UNKNOWN"

    const/4 v3, -0x1

    invoke-direct {v0, v1, v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 591
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    const-string v1, "MIXED"

    const/4 v3, -0x2

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->MIXED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 579
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0

    .line 596
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 597
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    return-void
.end method

.method public static lookup(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
    .locals 2

    .line 601
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->NUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_0

    return-object v0

    .line 603
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ALPHANUMERIC:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_1

    return-object v0

    .line 605
    :cond_1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->BYTE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_2

    return-object v0

    .line 607
    :cond_2
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->KANJI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_3

    return-object v0

    .line 609
    :cond_3
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->ECI:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_4

    return-object v0

    .line 611
    :cond_4
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->STRUCTURE_APPENDED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_5

    return-object v0

    .line 613
    :cond_5
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_FIRST:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_6

    return-object v0

    .line 615
    :cond_6
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->FNC1_SECOND:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->bits:I

    if-ne v1, p0, :cond_7

    return-object v0

    .line 618
    :cond_7
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    return-object p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
    .locals 1

    .line 579
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
    .locals 1

    .line 579
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    return-object v0
.end method
