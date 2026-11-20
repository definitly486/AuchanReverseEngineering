.class Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern$M001;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;
.source "QrCodeMaskPattern.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "M001"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x1

    .line 116
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;-><init>(I)V

    return-void
.end method


# virtual methods
.method public apply(III)I
    .locals 0

    .line 119
    rem-int/lit8 p1, p1, 0x2

    not-int p1, p1

    and-int/lit8 p1, p1, 0x1

    xor-int/2addr p1, p3

    return p1
.end method
