package com.google.mediapipe.framework;

import android.graphics.Bitmap;
import android.media.Image;
import com.google.mediapipe.framework.image.BitmapExtractor;
import com.google.mediapipe.framework.image.ByteBufferExtractor;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.framework.image.MPImageProperties;
import com.google.mediapipe.framework.image.MediaImageExtractor;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public class AndroidPacketCreator extends PacketCreator {
    private native long nativeCreateRgbImageFrame(long j, Bitmap bitmap);

    private native long nativeCreateRgbaImage(long j, Bitmap bitmap);

    private native long nativeCreateRgbaImageFrame(long j, Bitmap bitmap);

    public AndroidPacketCreator(Graph graph) {
        super(graph);
    }

    public Packet createRgbImageFrame(Bitmap bitmap) {
        if (bitmap.getConfig() != Bitmap.Config.ARGB_8888) {
            throw new RuntimeException("bitmap must use ARGB_8888 config.");
        }
        return Packet.create(nativeCreateRgbImageFrame(this.mediapipeGraph.getNativeHandle(), bitmap));
    }

    public Packet createRgbaImageFrame(Bitmap bitmap) {
        if (bitmap.getConfig() != Bitmap.Config.ARGB_8888) {
            throw new RuntimeException("bitmap must use ARGB_8888 config.");
        }
        return Packet.create(nativeCreateRgbaImageFrame(this.mediapipeGraph.getNativeHandle(), bitmap));
    }

    public Packet createRgbaImage(Bitmap bitmap) {
        if (bitmap.getConfig() != Bitmap.Config.ARGB_8888) {
            throw new RuntimeException("bitmap must use ARGB_8888 config.");
        }
        return Packet.create(nativeCreateRgbaImage(this.mediapipeGraph.getNativeHandle(), bitmap));
    }

    public Packet createImage(MPImage mPImage) {
        int i = 0;
        MPImageProperties mPImageProperties = mPImage.getContainedImageProperties().get(0);
        if (mPImageProperties.getStorageType() == 2) {
            ByteBuffer byteBufferExtract = ByteBufferExtractor.extract(mPImage);
            int imageFormat = mPImageProperties.getImageFormat();
            if (imageFormat == 1) {
                i = 4;
            } else if (imageFormat == 2) {
                i = 3;
            } else if (imageFormat == 8) {
                i = 1;
            }
            if (i == 0) {
                throw new UnsupportedOperationException("Unsupported MediaPipe Image image format: " + mPImageProperties.getImageFormat());
            }
            return createImage(byteBufferExtract, mPImage.getWidth(), mPImage.getHeight(), i);
        }
        if (mPImageProperties.getStorageType() == 1) {
            Bitmap bitmapExtract = BitmapExtractor.extract(mPImage);
            if (bitmapExtract.getConfig() != Bitmap.Config.ARGB_8888) {
                throw new UnsupportedOperationException("bitmap must use ARGB_8888 config.");
            }
            return Packet.create(nativeCreateRgbaImage(this.mediapipeGraph.getNativeHandle(), bitmapExtract));
        }
        if (mPImageProperties.getStorageType() == 3) {
            Image imageExtract = MediaImageExtractor.extract(mPImage);
            if (imageExtract.getFormat() != 1) {
                throw new UnsupportedOperationException("Android media image must use RGBA_8888 config.");
            }
            return createImage(imageExtract.getPlanes()[0].getBuffer(), imageExtract.getWidth(), imageExtract.getHeight(), 4);
        }
        throw new UnsupportedOperationException("Unsupported Image container type: " + mPImageProperties.getStorageType());
    }
}
