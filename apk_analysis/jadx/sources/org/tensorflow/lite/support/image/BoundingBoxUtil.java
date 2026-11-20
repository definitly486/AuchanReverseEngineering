package org.tensorflow.lite.support.image;

import android.graphics.RectF;
import java.nio.ByteBuffer;
import java.nio.FloatBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import org.tensorflow.lite.DataType;
import org.tensorflow.lite.support.common.internal.SupportPreconditions;
import org.tensorflow.lite.support.tensorbuffer.TensorBuffer;

/* JADX INFO: loaded from: classes4.dex */
public final class BoundingBoxUtil {

    public enum CoordinateType {
        RATIO,
        PIXEL
    }

    public enum Type {
        BOUNDARIES,
        UPPER_LEFT,
        CENTER
    }

    public static List<RectF> convert(TensorBuffer tensorBuffer, int[] iArr, int i, Type type, CoordinateType coordinateType, int i2, int i3) {
        int[] iArr2 = iArr;
        int length = i;
        int[] shape = tensorBuffer.getShape();
        SupportPreconditions.checkArgument(length >= (-shape.length) && length < shape.length, String.format("Axis %d is not in range (-(D+1), D), where D is the number of dimensions of input tensor (shape=%s)", Integer.valueOf(length), Arrays.toString(shape)));
        if (length < 0) {
            length += shape.length;
        }
        SupportPreconditions.checkArgument(shape[length] == 4, String.format("Size of bounding box dimension %d is not 4. Got %d in shape %s", Integer.valueOf(length), Integer.valueOf(shape[length]), Arrays.toString(shape)));
        SupportPreconditions.checkArgument(iArr2.length == 4, String.format("Bounding box index array length %d is not 4. Got index array %s", Integer.valueOf(iArr2.length), Arrays.toString(iArr2)));
        SupportPreconditions.checkArgument(tensorBuffer.getDataType() == DataType.FLOAT32, "Bounding Boxes only create from FLOAT32 buffers. Got: " + tensorBuffer.getDataType().name());
        ArrayList arrayList = new ArrayList();
        int i4 = 1;
        for (int i5 = 0; i5 < length; i5++) {
            i4 *= shape[i5];
        }
        int i6 = 1;
        for (int i7 = length + 1; i7 < shape.length; i7++) {
            i6 *= shape[i7];
        }
        float[] fArr = new float[4];
        ByteBuffer buffer = tensorBuffer.getBuffer();
        buffer.rewind();
        FloatBuffer floatBufferAsFloatBuffer = buffer.asFloatBuffer();
        int i8 = 0;
        while (i8 < i4) {
            int i9 = 0;
            while (i9 < i6) {
                for (int i10 = 0; i10 < 4; i10++) {
                    fArr[i10] = floatBufferAsFloatBuffer.get((((i8 * 4) + i10) * i6) + i9);
                }
                arrayList.add(convertOneBoundingBox(fArr, iArr2, type, coordinateType, i2, i3));
                i9++;
                iArr2 = iArr;
            }
            i8++;
            iArr2 = iArr;
        }
        buffer.rewind();
        return arrayList;
    }

    private static RectF convertOneBoundingBox(float[] fArr, int[] iArr, Type type, CoordinateType coordinateType, int i, int i2) {
        float[] fArr2 = new float[4];
        for (int i3 = 0; i3 < 4; i3++) {
            fArr2[i3] = fArr[iArr[i3]];
        }
        return convertOneBoundingBox(fArr2, type, coordinateType, i, i2);
    }

    /* JADX INFO: renamed from: org.tensorflow.lite.support.image.BoundingBoxUtil$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$org$tensorflow$lite$support$image$BoundingBoxUtil$Type;

        static {
            int[] iArr = new int[Type.values().length];
            $SwitchMap$org$tensorflow$lite$support$image$BoundingBoxUtil$Type = iArr;
            try {
                iArr[Type.BOUNDARIES.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$org$tensorflow$lite$support$image$BoundingBoxUtil$Type[Type.UPPER_LEFT.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$org$tensorflow$lite$support$image$BoundingBoxUtil$Type[Type.CENTER.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
        }
    }

    private static RectF convertOneBoundingBox(float[] fArr, Type type, CoordinateType coordinateType, int i, int i2) {
        int i3 = AnonymousClass1.$SwitchMap$org$tensorflow$lite$support$image$BoundingBoxUtil$Type[type.ordinal()];
        if (i3 == 1) {
            return convertFromBoundaries(fArr, coordinateType, i, i2);
        }
        if (i3 == 2) {
            return convertFromUpperLeft(fArr, coordinateType, i, i2);
        }
        if (i3 == 3) {
            return convertFromCenter(fArr, coordinateType, i, i2);
        }
        throw new IllegalArgumentException("Cannot recognize BoundingBox.Type " + type);
    }

    private static RectF convertFromBoundaries(float[] fArr, CoordinateType coordinateType, int i, int i2) {
        return getRectF(fArr[0], fArr[1], fArr[2], fArr[3], i, i2, coordinateType);
    }

    private static RectF convertFromUpperLeft(float[] fArr, CoordinateType coordinateType, int i, int i2) {
        float f = fArr[0];
        float f2 = fArr[1];
        return getRectF(f, f2, f + fArr[2], f2 + fArr[3], i, i2, coordinateType);
    }

    private static RectF convertFromCenter(float[] fArr, CoordinateType coordinateType, int i, int i2) {
        float f = fArr[0];
        float f2 = fArr[1];
        float f3 = fArr[2] / 2.0f;
        float f4 = fArr[3] / 2.0f;
        return getRectF(f - f3, f2 - f4, f + f3, f2 + f4, i, i2, coordinateType);
    }

    private static RectF getRectF(float f, float f2, float f3, float f4, int i, int i2, CoordinateType coordinateType) {
        if (coordinateType == CoordinateType.PIXEL) {
            return new RectF(f, f2, f3, f4);
        }
        if (coordinateType == CoordinateType.RATIO) {
            float f5 = i2;
            float f6 = i;
            return new RectF(f * f5, f2 * f6, f3 * f5, f4 * f6);
        }
        throw new IllegalArgumentException("Cannot convert coordinate type " + coordinateType);
    }

    private BoundingBoxUtil() {
    }
}
