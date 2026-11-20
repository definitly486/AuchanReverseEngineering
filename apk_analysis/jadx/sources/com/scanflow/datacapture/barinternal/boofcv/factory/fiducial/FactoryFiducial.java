package com.scanflow.datacapture.barinternal.boofcv.factory.fiducial;

import com.scanflow.datacapture.barinternal.boofcv.abst.fiducial.QrCodePreciseDetector;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternDetector;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.FactoryThresholdBinary;
import com.scanflow.datacapture.barinternal.boofcv.factory.shape.FactoryShapeDetector;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryFiducial {
    public static QrCodePreciseDetector qrcode(ConfigQrCode configQrCode, Class cls) {
        if (configQrCode == null) {
            configQrCode = new ConfigQrCode();
        }
        configQrCode.checkValidity();
        QrCodePreciseDetector qrCodePreciseDetector = new QrCodePreciseDetector(FactoryThresholdBinary.threshold(configQrCode.threshold, cls), new QrCodePositionPatternDetector(FactoryShapeDetector.polygon(configQrCode.polygon, cls)), configQrCode.forceEncoding, configQrCode.defaultEncoding, false, cls);
        qrCodePreciseDetector.getGraphPositionPatterns().setMaxVersionQR(configQrCode.versionMaximum);
        qrCodePreciseDetector.getDecoder().considerTransposed = configQrCode.considerTransposed;
        qrCodePreciseDetector.getDecoder().getDecoder().ignorePaddingBytes = configQrCode.ignorePaddingBytes;
        return qrCodePreciseDetector;
    }
}
