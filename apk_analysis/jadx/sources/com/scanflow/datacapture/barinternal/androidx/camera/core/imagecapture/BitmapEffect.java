package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.graphics.Bitmap;
import androidx.camera.core.ImageProxy;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Exif;
import com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.ImageUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.ImageProcessorRequest;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.InternalImageProcessor;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Packet;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class BitmapEffect implements Operation {
    private final InternalImageProcessor mProcessor;

    BitmapEffect(InternalImageProcessor internalImageProcessor) {
        this.mProcessor = internalImageProcessor;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation
    public Packet apply(Packet packet) {
        ImageProxy outputImage = this.mProcessor.safeProcess(new ImageProcessorRequest(new RgbaImageProxy(packet), 1)).getOutputImage();
        Objects.requireNonNull(outputImage);
        Bitmap bitmapCreateBitmapFromPlane = ImageUtil.createBitmapFromPlane(outputImage.getPlanes(), outputImage.getWidth(), outputImage.getHeight());
        Exif exif = packet.getExif();
        Objects.requireNonNull(exif);
        return Packet.of(bitmapCreateBitmapFromPlane, exif, packet.getCropRect(), packet.getRotationDegrees(), packet.getSensorToBufferTransform(), packet.getCameraCaptureResult());
    }
}
