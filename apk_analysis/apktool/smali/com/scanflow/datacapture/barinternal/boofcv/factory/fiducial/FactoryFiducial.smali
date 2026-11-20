.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/FactoryFiducial;
.super Ljava/lang/Object;
.source "FactoryFiducial.java"


# direct methods
.method public static qrcode(Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;
    .locals 8

    if-nez p0, :cond_0

    .line 220
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;-><init>()V

    .line 222
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->checkValidity()V

    .line 224
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->threshold:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object v2

    .line 226
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryShapeDetector;->polygon(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    move-result-object v0

    .line 227
    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    invoke-direct {v3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;)V

    .line 229
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->forceEncoding:Ljava/lang/String;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->defaultEncoding:Ljava/lang/String;

    const/4 v6, 0x0

    move-object v7, p1

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/Class;)V

    .line 231
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->getGraphPositionPatterns()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

    move-result-object p1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->versionMaximum:I

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->setMaxVersionQR(I)V

    .line 232
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->getDecoder()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    move-result-object p1

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->considerTransposed:Z

    iput-boolean v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->considerTransposed:Z

    .line 233
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->getDecoder()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->getDecoder()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    move-result-object p1

    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->ignorePaddingBytes:Z

    iput-boolean p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ignorePaddingBytes:Z

    return-object v1
.end method
