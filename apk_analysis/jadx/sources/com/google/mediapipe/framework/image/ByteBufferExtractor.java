package com.google.mediapipe.framework.image;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import com.google.auto.value.AutoValue;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.Locale;

/* JADX INFO: loaded from: classes3.dex */
public class ByteBufferExtractor {
    @SuppressLint({"SwitchIntDef"})
    public static ByteBuffer extract(MPImage mPImage) {
        MPImageContainer container = mPImage.getContainer();
        if (container.getImageProperties().getStorageType() == 2) {
            return ((ByteBufferImageContainer) container).getByteBuffer().asReadOnlyBuffer().order(ByteOrder.nativeOrder());
        }
        throw new IllegalArgumentException("Extract ByteBuffer from a MPImage created by objects other than Bytebuffer is not supported");
    }

    public static ByteBuffer extract(MPImage mPImage, int i) {
        MPImageContainer container = mPImage.getContainer(MPImageProperties.builder().setStorageType(2).setImageFormat(i).build());
        if (container != null) {
            return ((ByteBufferImageContainer) container).getByteBuffer().asReadOnlyBuffer().order(ByteOrder.nativeOrder());
        }
        MPImageContainer container2 = mPImage.getContainer(2);
        if (container2 != null) {
            ByteBufferImageContainer byteBufferImageContainer = (ByteBufferImageContainer) container2;
            return convertByteBuffer(byteBufferImageContainer.getByteBuffer(), byteBufferImageContainer.getImageFormat(), i).asReadOnlyBuffer().order(ByteOrder.nativeOrder());
        }
        MPImageContainer container3 = mPImage.getContainer(1);
        if (container3 != null) {
            ByteBuffer byteBufferAsReadOnlyBuffer = extractByteBufferFromBitmap(((BitmapImageContainer) container3).getBitmap(), i).asReadOnlyBuffer();
            mPImage.addContainer(new ByteBufferImageContainer(byteBufferAsReadOnlyBuffer, i));
            return byteBufferAsReadOnlyBuffer;
        }
        throw new IllegalArgumentException("Extracting ByteBuffer from a MPImage created by objects other than Bitmap or Bytebuffer is not supported");
    }

    @AutoValue
    static abstract class Result {
        public abstract ByteBuffer buffer();

        public abstract int format();

        Result() {
        }

        static Result create(ByteBuffer byteBuffer, int i) {
            return new AutoValue_ByteBufferExtractor_Result(byteBuffer, i);
        }
    }

    static Result extractInRecommendedFormat(MPImage mPImage) {
        MPImageContainer container = mPImage.getContainer(1);
        if (container != null) {
            Bitmap bitmap = ((BitmapImageContainer) container).getBitmap();
            int iAdviseImageFormat = adviseImageFormat(bitmap);
            Result resultCreate = Result.create(extractByteBufferFromBitmap(bitmap, iAdviseImageFormat).asReadOnlyBuffer(), iAdviseImageFormat);
            mPImage.addContainer(new ByteBufferImageContainer(resultCreate.buffer(), resultCreate.format()));
            return resultCreate;
        }
        MPImageContainer container2 = mPImage.getContainer(2);
        if (container2 != null) {
            ByteBufferImageContainer byteBufferImageContainer = (ByteBufferImageContainer) container2;
            return Result.create(byteBufferImageContainer.getByteBuffer().asReadOnlyBuffer(), byteBufferImageContainer.getImageFormat());
        }
        throw new IllegalArgumentException("Extract ByteBuffer from a MPImage created by objects other than Bitmap or Bytebuffer is not supported");
    }

    private static int adviseImageFormat(Bitmap bitmap) {
        if (bitmap.getConfig() == Bitmap.Config.ARGB_8888) {
            return 1;
        }
        throw new IllegalArgumentException(String.format("Extracting ByteBuffer from a MPImage created by a Bitmap in config %s is not supported", bitmap.getConfig()));
    }

    private static ByteBuffer extractByteBufferFromBitmap(Bitmap bitmap, int i) {
        if (bitmap.isPremultiplied()) {
            throw new IllegalArgumentException("Extracting ByteBuffer from a MPImage created by a premultiplied Bitmap is not supported");
        }
        if (bitmap.getConfig() == Bitmap.Config.ARGB_8888) {
            if (i == 1) {
                ByteBuffer byteBufferAllocateDirect = ByteBuffer.allocateDirect(bitmap.getByteCount());
                bitmap.copyPixelsToBuffer(byteBufferAllocateDirect);
                byteBufferAllocateDirect.rewind();
                return byteBufferAllocateDirect;
            }
            if (i == 2) {
                int width = bitmap.getWidth();
                int height = bitmap.getHeight();
                int i2 = width * height;
                int[] iArr = new int[i2];
                bitmap.getPixels(iArr, 0, width, 0, 0, width, height);
                ByteBuffer byteBufferAllocateDirect2 = ByteBuffer.allocateDirect(i2 * 3);
                byteBufferAllocateDirect2.order(ByteOrder.nativeOrder());
                for (int i3 = 0; i3 < i2; i3++) {
                    int i4 = iArr[i3];
                    byteBufferAllocateDirect2.put((byte) ((i4 >> 16) & 255));
                    byteBufferAllocateDirect2.put((byte) ((i4 >> 8) & 255));
                    byteBufferAllocateDirect2.put((byte) (i4 & 255));
                }
                byteBufferAllocateDirect2.rewind();
                return byteBufferAllocateDirect2;
            }
        }
        throw new IllegalArgumentException(String.format("Extracting ByteBuffer from a MPImage created by Bitmap and convert from %s to format %d is not supported", bitmap.getConfig(), Integer.valueOf(i)));
    }

    private static ByteBuffer convertByteBuffer(ByteBuffer byteBuffer, int i, int i2) {
        if (i == 2 && i2 == 1) {
            ByteBuffer byteBufferAllocateDirect = ByteBuffer.allocateDirect((byteBuffer.capacity() / 3) * 4);
            byte[] bArr = new byte[byteBufferAllocateDirect.capacity()];
            byteBuffer.get(bArr, 0, byteBuffer.capacity());
            byteBuffer.rewind();
            int iCapacity = byteBuffer.capacity();
            int iCapacity2 = byteBufferAllocateDirect.capacity();
            while (iCapacity != iCapacity2) {
                bArr[iCapacity2 - 1] = -1;
                bArr[iCapacity2 - 2] = bArr[iCapacity - 1];
                bArr[iCapacity2 - 3] = bArr[iCapacity - 2];
                iCapacity2 -= 4;
                iCapacity -= 3;
                bArr[iCapacity2] = bArr[iCapacity];
            }
            byteBufferAllocateDirect.put(bArr, 0, byteBufferAllocateDirect.capacity());
            byteBufferAllocateDirect.rewind();
            return byteBufferAllocateDirect;
        }
        if (i == 1 && i2 == 2) {
            ByteBuffer byteBufferAllocateDirect2 = ByteBuffer.allocateDirect((byteBuffer.capacity() / 4) * 3);
            int iCapacity3 = byteBuffer.capacity();
            byte[] bArr2 = new byte[iCapacity3];
            byteBuffer.get(bArr2, 0, byteBuffer.capacity());
            byteBuffer.rewind();
            int i3 = 0;
            for (int i4 = 0; i4 < iCapacity3; i4 += 4) {
                bArr2[i3] = bArr2[i4];
                int i5 = i3 + 2;
                bArr2[i3 + 1] = bArr2[i4 + 1];
                i3 += 3;
                bArr2[i5] = bArr2[i4 + 2];
            }
            byteBufferAllocateDirect2.put(bArr2, 0, byteBufferAllocateDirect2.capacity());
            byteBufferAllocateDirect2.rewind();
            return byteBufferAllocateDirect2;
        }
        throw new IllegalArgumentException(String.format(Locale.ENGLISH, "Convert bytebuffer image format from %d to %d is not supported", Integer.valueOf(i), Integer.valueOf(i2)));
    }

    private ByteBufferExtractor() {
    }
}
