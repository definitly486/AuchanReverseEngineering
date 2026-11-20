package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import androidx.camera.core.ImageProcessingUtil;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.ImageReaderProxys;
import androidx.camera.core.SafeCloseImageReaderProxy;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Exif;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Packet;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class JpegBytes2Image implements Operation {
    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation
    public Packet apply(Packet packet) {
        SafeCloseImageReaderProxy safeCloseImageReaderProxy = new SafeCloseImageReaderProxy(ImageReaderProxys.createIsolatedReader(packet.getSize().getWidth(), packet.getSize().getHeight(), 256, 2));
        ImageProxy imageProxyConvertJpegBytesToImage = ImageProcessingUtil.convertJpegBytesToImage(safeCloseImageReaderProxy, (byte[]) packet.getData());
        safeCloseImageReaderProxy.safeClose();
        Objects.requireNonNull(imageProxyConvertJpegBytesToImage);
        Exif exif = packet.getExif();
        Objects.requireNonNull(exif);
        return Packet.of(imageProxyConvertJpegBytesToImage, exif, packet.getCropRect(), packet.getRotationDegrees(), packet.getSensorToBufferTransform(), packet.getCameraCaptureResult());
    }
}
