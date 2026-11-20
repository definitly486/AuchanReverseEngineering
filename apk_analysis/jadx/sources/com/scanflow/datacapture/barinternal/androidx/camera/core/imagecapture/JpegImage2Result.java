package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import androidx.camera.core.ImageProxy;
import androidx.camera.core.ImmutableImageInfo;
import androidx.camera.core.SettableImageProxy;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Packet;

/* JADX INFO: loaded from: classes.dex */
public class JpegImage2Result implements Operation {
    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation
    public ImageProxy apply(Packet packet) {
        ImageProxy imageProxy = (ImageProxy) packet.getData();
        SettableImageProxy settableImageProxy = new SettableImageProxy(imageProxy, packet.getSize(), ImmutableImageInfo.create(imageProxy.getImageInfo().getTagBundle(), imageProxy.getImageInfo().getTimestamp(), packet.getRotationDegrees(), packet.getSensorToBufferTransform()));
        settableImageProxy.setCropRect(packet.getCropRect());
        return settableImageProxy;
    }
}
