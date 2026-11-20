.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final process(Ljava/lang/Object;)V
    .locals 0

    .line 0
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->reset()V

    return-void
.end method
