.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;
.super Ljava/lang/Object;
.source "QrCode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "VersionInfo"
.end annotation


# instance fields
.field public final alignment:[I

.field public final codewords:I

.field public final levels:Ljava/util/Map;


# direct methods
.method public constructor <init>(I[I)V
    .locals 1

    .line 527
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 525
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->levels:Ljava/util/Map;

    .line 528
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->codewords:I

    .line 529
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->alignment:[I

    return-void
.end method


# virtual methods
.method public add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V
    .locals 2

    .line 533
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->levels:Ljava/util/Map;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;

    invoke-direct {v1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;-><init>(III)V

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method
