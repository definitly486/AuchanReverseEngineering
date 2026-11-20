package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.graphics.Bitmap;
import android.os.Build;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Exif;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Packet;
import java.io.ByteArrayOutputStream;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
class Bitmap2JpegBytes implements Operation {
    Bitmap2JpegBytes() {
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation
    public Packet apply(In in) {
        Packet packet = in.getPacket();
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        ((Bitmap) packet.getData()).compress(Bitmap.CompressFormat.JPEG, in.getJpegQuality(), byteArrayOutputStream);
        byte[] byteArray = byteArrayOutputStream.toByteArray();
        Exif exif = packet.getExif();
        Objects.requireNonNull(exif);
        return Packet.of(byteArray, exif, getOutputFormat((Bitmap) packet.getData()), packet.getSize(), packet.getCropRect(), packet.getRotationDegrees(), packet.getSensorToBufferTransform(), packet.getCameraCaptureResult());
    }

    private static int getOutputFormat(Bitmap bitmap) {
        return (Build.VERSION.SDK_INT < 34 || !Api34Impl.hasGainmap(bitmap)) ? 256 : 4101;
    }

    private static class Api34Impl {
        static boolean hasGainmap(Bitmap bitmap) {
            return bitmap.hasGainmap();
        }
    }

    static abstract class In {
        abstract int getJpegQuality();

        abstract Packet getPacket();

        In() {
        }

        static In of(Packet packet, int i) {
            return new AutoValue_Bitmap2JpegBytes_In(packet, i);
        }
    }
}
