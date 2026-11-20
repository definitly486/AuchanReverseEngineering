.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;
.super Ljava/lang/Enum;
.source "QrCode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "ErrorLevel"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

.field public static final enum H:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

.field public static final enum L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

.field public static final enum M:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

.field public static final enum Q:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;


# instance fields
.field final value:I


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;
    .locals 4

    .line 453
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->M:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->Q:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->H:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    filled-new-array {v0, v1, v2, v3}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 4

    .line 455
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const-string v1, "L"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 457
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const-string v1, "M"

    invoke-direct {v0, v1, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->M:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 459
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const-string v1, "Q"

    const/4 v2, 0x2

    const/4 v3, 0x3

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->Q:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 461
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const-string v1, "H"

    invoke-direct {v0, v1, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->H:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 453
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0

    .line 463
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 464
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->value:I

    return-void
.end method

.method public static lookup(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;
    .locals 1

    if-eqz p0, :cond_3

    const/4 v0, 0x1

    if-eq p0, v0, :cond_2

    const/4 v0, 0x2

    if-eq p0, v0, :cond_1

    const/4 v0, 0x3

    if-ne p0, v0, :cond_0

    .line 475
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->Q:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object p0

    .line 477
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string v0, "Unknown"

    invoke-direct {p0, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 476
    :cond_1
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->H:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object p0

    .line 473
    :cond_2
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object p0

    .line 474
    :cond_3
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->M:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;
    .locals 1

    .line 453
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;
    .locals 1

    .line 453
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    return-object v0
.end method
