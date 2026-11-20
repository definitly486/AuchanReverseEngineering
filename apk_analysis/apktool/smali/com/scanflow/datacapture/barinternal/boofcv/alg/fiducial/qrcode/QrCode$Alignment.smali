.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;
.super Ljava/lang/Object;
.source "QrCode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Alignment"
.end annotation


# instance fields
.field moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field public moduleX:I

.field public moduleY:I

.field public pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 495
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 497
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 503
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method


# virtual methods
.method public set(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;)V
    .locals 2

    .line 509
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 510
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    .line 511
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    .line 512
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method
