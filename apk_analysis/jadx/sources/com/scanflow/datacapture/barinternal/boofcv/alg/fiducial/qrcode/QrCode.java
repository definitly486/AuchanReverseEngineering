package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: loaded from: classes.dex */
public class QrCode implements Cloneable {
    public static final List[] LOCATION_BITS = new ArrayList[41];
    public static final VersionInfo[] VERSION_INFO;
    public boolean bitsTransposed;
    public byte[] corrected;
    public ErrorLevel error;
    public QrCodeMaskPattern mask;
    public byte[] rawbits;
    public double threshCorner;
    public double threshDown;
    public double threshDownRight;
    public double threshRight;
    public int totalBitErrors;
    public int version;
    public Polygon2D_F64 ppRight = new Polygon2D_F64(4);
    public Polygon2D_F64 ppCorner = new Polygon2D_F64(4);
    public Polygon2D_F64 ppDown = new Polygon2D_F64(4);
    public DogArray alignment = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCode$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new QrCode.Alignment();
        }
    });
    public Mode mode = Mode.UNKNOWN;
    public String byteEncoding = "";
    public String message = "";
    public Failure failureCause = Failure.NONE;
    public Polygon2D_F64 bounds = new Polygon2D_F64(4);
    public Homography2D_F64 Hinv = new Homography2D_F64();

    public enum Failure {
        NONE,
        FORMAT,
        VERSION,
        ALIGNMENT,
        READING_BITS,
        ERROR_CORRECTION,
        UNKNOWN_MODE,
        READING_PADDING,
        MESSAGE_OVERFLOW,
        DECODING_MESSAGE,
        KANJI_UNAVAILABLE,
        STRING_ENCODING_UNAVAILABLE
    }

    static {
        VersionInfo[] versionInfoArr = new VersionInfo[41];
        VERSION_INFO = versionInfoArr;
        VersionInfo versionInfo = new VersionInfo(26, new int[0]);
        versionInfoArr[1] = versionInfo;
        ErrorLevel errorLevel = ErrorLevel.L;
        versionInfo.add(errorLevel, 26, 19, 1);
        VersionInfo versionInfo2 = versionInfoArr[1];
        ErrorLevel errorLevel2 = ErrorLevel.M;
        versionInfo2.add(errorLevel2, 26, 16, 1);
        VersionInfo versionInfo3 = versionInfoArr[1];
        ErrorLevel errorLevel3 = ErrorLevel.Q;
        versionInfo3.add(errorLevel3, 26, 13, 1);
        VersionInfo versionInfo4 = versionInfoArr[1];
        ErrorLevel errorLevel4 = ErrorLevel.H;
        versionInfo4.add(errorLevel4, 26, 9, 1);
        VersionInfo versionInfo5 = new VersionInfo(44, new int[]{6, 18});
        versionInfoArr[2] = versionInfo5;
        versionInfo5.add(errorLevel, 44, 34, 1);
        versionInfoArr[2].add(errorLevel2, 44, 28, 1);
        versionInfoArr[2].add(errorLevel3, 44, 22, 1);
        versionInfoArr[2].add(errorLevel4, 44, 16, 1);
        VersionInfo versionInfo6 = new VersionInfo(70, new int[]{6, 22});
        versionInfoArr[3] = versionInfo6;
        versionInfo6.add(errorLevel, 70, 55, 1);
        versionInfoArr[3].add(errorLevel2, 70, 44, 1);
        versionInfoArr[3].add(errorLevel3, 35, 17, 2);
        versionInfoArr[3].add(errorLevel4, 35, 13, 2);
        VersionInfo versionInfo7 = new VersionInfo(100, new int[]{6, 26});
        versionInfoArr[4] = versionInfo7;
        versionInfo7.add(errorLevel, 100, 80, 1);
        versionInfoArr[4].add(errorLevel2, 50, 32, 2);
        versionInfoArr[4].add(errorLevel3, 50, 24, 2);
        versionInfoArr[4].add(errorLevel4, 25, 9, 4);
        VersionInfo versionInfo8 = new VersionInfo(BuiltinOperator.REAL, new int[]{6, 30});
        versionInfoArr[5] = versionInfo8;
        versionInfo8.add(errorLevel, BuiltinOperator.REAL, 108, 1);
        versionInfoArr[5].add(errorLevel2, 67, 43, 2);
        versionInfoArr[5].add(errorLevel3, 33, 15, 2);
        versionInfoArr[5].add(errorLevel4, 33, 11, 2);
        VersionInfo versionInfo9 = new VersionInfo(172, new int[]{6, 34});
        versionInfoArr[6] = versionInfo9;
        versionInfo9.add(errorLevel, 86, 68, 2);
        versionInfoArr[6].add(errorLevel2, 43, 27, 4);
        versionInfoArr[6].add(errorLevel3, 43, 19, 4);
        versionInfoArr[6].add(errorLevel4, 43, 15, 4);
        VersionInfo versionInfo10 = new VersionInfo(196, new int[]{6, 22, 38});
        versionInfoArr[7] = versionInfo10;
        versionInfo10.add(errorLevel, 98, 78, 2);
        versionInfoArr[7].add(errorLevel2, 49, 31, 4);
        versionInfoArr[7].add(errorLevel3, 32, 14, 2);
        versionInfoArr[7].add(errorLevel4, 39, 13, 4);
        VersionInfo versionInfo11 = new VersionInfo(242, new int[]{6, 24, 42});
        versionInfoArr[8] = versionInfo11;
        versionInfo11.add(errorLevel, 121, 97, 2);
        versionInfoArr[8].add(errorLevel2, 60, 38, 2);
        versionInfoArr[8].add(errorLevel3, 40, 18, 4);
        versionInfoArr[8].add(errorLevel4, 40, 14, 4);
        VersionInfo versionInfo12 = new VersionInfo(292, new int[]{6, 26, 46});
        versionInfoArr[9] = versionInfo12;
        versionInfo12.add(errorLevel, BuiltinOperator.RANDOM_STANDARD_NORMAL, 116, 2);
        versionInfoArr[9].add(errorLevel2, 58, 36, 3);
        versionInfoArr[9].add(errorLevel3, 36, 16, 4);
        versionInfoArr[9].add(errorLevel4, 36, 12, 4);
        VersionInfo versionInfo13 = new VersionInfo(346, new int[]{6, 28, 50});
        versionInfoArr[10] = versionInfo13;
        versionInfo13.add(errorLevel, 86, 68, 2);
        versionInfoArr[10].add(errorLevel2, 69, 43, 4);
        versionInfoArr[10].add(errorLevel3, 43, 19, 6);
        versionInfoArr[10].add(errorLevel4, 43, 15, 6);
        VersionInfo versionInfo14 = new VersionInfo(404, new int[]{6, 30, 54});
        versionInfoArr[11] = versionInfo14;
        versionInfo14.add(errorLevel, 101, 81, 4);
        versionInfoArr[11].add(errorLevel2, 80, 50, 1);
        versionInfoArr[11].add(errorLevel3, 50, 22, 4);
        versionInfoArr[11].add(errorLevel4, 36, 12, 3);
        VersionInfo versionInfo15 = new VersionInfo(466, new int[]{6, 32, 58});
        versionInfoArr[12] = versionInfo15;
        versionInfo15.add(errorLevel, 116, 92, 2);
        versionInfoArr[12].add(errorLevel2, 58, 36, 6);
        versionInfoArr[12].add(errorLevel3, 46, 20, 4);
        versionInfoArr[12].add(errorLevel4, 42, 14, 7);
        VersionInfo versionInfo16 = new VersionInfo(532, new int[]{6, 34, 62});
        versionInfoArr[13] = versionInfo16;
        versionInfo16.add(errorLevel, BuiltinOperator.IMAG, 107, 4);
        versionInfoArr[13].add(errorLevel2, 59, 37, 8);
        versionInfoArr[13].add(errorLevel3, 44, 20, 8);
        versionInfoArr[13].add(errorLevel4, 33, 11, 12);
        VersionInfo versionInfo17 = new VersionInfo(581, new int[]{6, 26, 46, 66});
        versionInfoArr[14] = versionInfo17;
        versionInfo17.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 3);
        versionInfoArr[14].add(errorLevel2, 64, 40, 4);
        versionInfoArr[14].add(errorLevel3, 36, 16, 11);
        versionInfoArr[14].add(errorLevel4, 36, 12, 11);
        VersionInfo versionInfo18 = new VersionInfo(655, new int[]{6, 26, 48, 70});
        versionInfoArr[15] = versionInfo18;
        versionInfo18.add(errorLevel, 109, 87, 5);
        versionInfoArr[15].add(errorLevel2, 65, 41, 5);
        versionInfoArr[15].add(errorLevel3, 54, 24, 5);
        versionInfoArr[15].add(errorLevel4, 36, 12, 11);
        VersionInfo versionInfo19 = new VersionInfo(733, new int[]{6, 26, 50, 74});
        versionInfoArr[16] = versionInfo19;
        versionInfo19.add(errorLevel, 122, 98, 5);
        versionInfoArr[16].add(errorLevel2, 73, 45, 7);
        versionInfoArr[16].add(errorLevel3, 43, 19, 15);
        versionInfoArr[16].add(errorLevel4, 45, 15, 3);
        VersionInfo versionInfo20 = new VersionInfo(815, new int[]{6, 30, 54, 78});
        versionInfoArr[17] = versionInfo20;
        versionInfo20.add(errorLevel, BuiltinOperator.COMPLEX_ABS, 107, 1);
        versionInfoArr[17].add(errorLevel2, 74, 46, 10);
        versionInfoArr[17].add(errorLevel3, 50, 22, 1);
        versionInfoArr[17].add(errorLevel4, 42, 14, 2);
        VersionInfo versionInfo21 = new VersionInfo(901, new int[]{6, 30, 56, 82});
        versionInfoArr[18] = versionInfo21;
        versionInfo21.add(errorLevel, BuiltinOperator.GELU, 120, 5);
        versionInfoArr[18].add(errorLevel2, 69, 43, 9);
        versionInfoArr[18].add(errorLevel3, 50, 22, 17);
        versionInfoArr[18].add(errorLevel4, 42, 14, 2);
        VersionInfo versionInfo22 = new VersionInfo(991, new int[]{6, 30, 58, 86});
        versionInfoArr[19] = versionInfo22;
        versionInfo22.add(errorLevel, BuiltinOperator.CONV_3D_TRANSPOSE, 113, 3);
        versionInfoArr[19].add(errorLevel2, 70, 44, 3);
        versionInfoArr[19].add(errorLevel3, 47, 21, 17);
        versionInfoArr[19].add(errorLevel4, 39, 13, 9);
        VersionInfo versionInfo23 = new VersionInfo(1085, new int[]{6, 34, 62, 90});
        versionInfoArr[20] = versionInfo23;
        versionInfo23.add(errorLevel, BuiltinOperator.COMPLEX_ABS, 107, 3);
        versionInfoArr[20].add(errorLevel2, 67, 41, 3);
        versionInfoArr[20].add(errorLevel3, 54, 24, 15);
        versionInfoArr[20].add(errorLevel4, 43, 15, 15);
        VersionInfo versionInfo24 = new VersionInfo(1156, new int[]{6, 28, 50, 72, 94});
        versionInfoArr[21] = versionInfo24;
        versionInfo24.add(errorLevel, BuiltinOperator.ASSIGN_VARIABLE, 116, 4);
        versionInfoArr[21].add(errorLevel2, 68, 42, 17);
        versionInfoArr[21].add(errorLevel3, 50, 22, 17);
        versionInfoArr[21].add(errorLevel4, 46, 16, 19);
        VersionInfo versionInfo25 = new VersionInfo(1258, new int[]{6, 26, 50, 74, 98});
        versionInfoArr[22] = versionInfo25;
        versionInfo25.add(errorLevel, BuiltinOperator.HASHTABLE_SIZE, 111, 2);
        versionInfoArr[22].add(errorLevel2, 74, 46, 17);
        versionInfoArr[22].add(errorLevel3, 54, 24, 7);
        versionInfoArr[22].add(errorLevel4, 37, 13, 34);
        VersionInfo versionInfo26 = new VersionInfo(1364, new int[]{6, 30, 54, 78, 102});
        versionInfoArr[23] = versionInfo26;
        versionInfo26.add(errorLevel, BuiltinOperator.DYNAMIC_UPDATE_SLICE, 121, 4);
        versionInfoArr[23].add(errorLevel2, 75, 47, 4);
        versionInfoArr[23].add(errorLevel3, 54, 24, 11);
        versionInfoArr[23].add(errorLevel4, 45, 15, 16);
        VersionInfo versionInfo27 = new VersionInfo(1474, new int[]{6, 28, 54, 80, 106});
        versionInfoArr[24] = versionInfo27;
        versionInfo27.add(errorLevel, BuiltinOperator.BUCKETIZE, 117, 6);
        versionInfoArr[24].add(errorLevel2, 73, 45, 6);
        versionInfoArr[24].add(errorLevel3, 54, 24, 11);
        versionInfoArr[24].add(errorLevel4, 46, 16, 30);
        VersionInfo versionInfo28 = new VersionInfo(1588, new int[]{6, 32, 58, 84, 110});
        versionInfoArr[25] = versionInfo28;
        versionInfo28.add(errorLevel, BuiltinOperator.CONV_3D, 106, 8);
        versionInfoArr[25].add(errorLevel2, 75, 47, 8);
        versionInfoArr[25].add(errorLevel3, 54, 24, 7);
        versionInfoArr[25].add(errorLevel4, 45, 15, 22);
        VersionInfo versionInfo29 = new VersionInfo(1706, new int[]{6, 30, 58, 86, 114});
        versionInfoArr[26] = versionInfo29;
        versionInfo29.add(errorLevel, BuiltinOperator.VAR_HANDLE, 114, 10);
        versionInfoArr[26].add(errorLevel2, 74, 46, 19);
        versionInfoArr[26].add(errorLevel3, 50, 22, 28);
        versionInfoArr[26].add(errorLevel4, 46, 16, 33);
        VersionInfo versionInfo30 = new VersionInfo(1828, new int[]{6, 34, 62, 90, 118});
        versionInfoArr[27] = versionInfo30;
        versionInfo30.add(errorLevel, BuiltinOperator.RELU_0_TO_1, 122, 8);
        versionInfoArr[27].add(errorLevel2, 73, 45, 22);
        versionInfoArr[27].add(errorLevel3, 53, 23, 8);
        versionInfoArr[27].add(errorLevel4, 45, 15, 12);
        VersionInfo versionInfo31 = new VersionInfo(1921, new int[]{6, 26, 50, 74, 98, 122});
        versionInfoArr[28] = versionInfo31;
        versionInfo31.add(errorLevel, BuiltinOperator.BUCKETIZE, 117, 3);
        versionInfoArr[28].add(errorLevel2, 73, 45, 3);
        versionInfoArr[28].add(errorLevel3, 54, 24, 4);
        versionInfoArr[28].add(errorLevel4, 45, 15, 11);
        VersionInfo versionInfo32 = new VersionInfo(2051, new int[]{6, 30, 54, 78, 102, 126});
        versionInfoArr[29] = versionInfo32;
        versionInfo32.add(errorLevel, BuiltinOperator.RANDOM_STANDARD_NORMAL, 116, 7);
        versionInfoArr[29].add(errorLevel2, 73, 45, 21);
        versionInfoArr[29].add(errorLevel3, 53, 23, 1);
        versionInfoArr[29].add(errorLevel4, 45, 15, 19);
        VersionInfo versionInfo33 = new VersionInfo(2185, new int[]{6, 26, 52, 78, 104, BuiltinOperator.BROADCAST_TO});
        versionInfoArr[30] = versionInfo33;
        versionInfo33.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 5);
        versionInfoArr[30].add(errorLevel2, 75, 47, 19);
        versionInfoArr[30].add(errorLevel3, 54, 24, 15);
        versionInfoArr[30].add(errorLevel4, 45, 15, 23);
        VersionInfo versionInfo34 = new VersionInfo(2323, new int[]{6, 30, 56, 82, 108, BuiltinOperator.REAL});
        versionInfoArr[31] = versionInfo34;
        versionInfo34.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 13);
        versionInfoArr[31].add(errorLevel2, 74, 46, 2);
        versionInfoArr[31].add(errorLevel3, 54, 24, 42);
        versionInfoArr[31].add(errorLevel4, 45, 15, 23);
        VersionInfo versionInfo35 = new VersionInfo(2465, new int[]{6, 34, 60, 86, 112, BuiltinOperator.HASHTABLE_IMPORT});
        versionInfoArr[32] = versionInfo35;
        versionInfo35.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 17);
        versionInfoArr[32].add(errorLevel2, 74, 46, 10);
        versionInfoArr[32].add(errorLevel3, 54, 24, 10);
        versionInfoArr[32].add(errorLevel4, 45, 15, 19);
        VersionInfo versionInfo36 = new VersionInfo(2611, new int[]{6, 30, 58, 86, 114, BuiltinOperator.VAR_HANDLE});
        versionInfoArr[33] = versionInfo36;
        versionInfo36.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 17);
        versionInfoArr[33].add(errorLevel2, 74, 46, 14);
        versionInfoArr[33].add(errorLevel3, 54, 24, 29);
        versionInfoArr[33].add(errorLevel4, 45, 15, 11);
        VersionInfo versionInfo37 = new VersionInfo(2761, new int[]{6, 34, 62, 90, 118, BuiltinOperator.RANDOM_STANDARD_NORMAL});
        versionInfoArr[34] = versionInfo37;
        versionInfo37.add(errorLevel, BuiltinOperator.BROADCAST_ARGS, 115, 13);
        versionInfoArr[34].add(errorLevel2, 74, 46, 14);
        versionInfoArr[34].add(errorLevel3, 54, 24, 44);
        versionInfoArr[34].add(errorLevel4, 46, 16, 59);
        VersionInfo versionInfo38 = new VersionInfo(2876, new int[]{6, 30, 54, 78, 102, 126, BuiltinOperator.GELU});
        versionInfoArr[35] = versionInfo38;
        versionInfo38.add(errorLevel, BuiltinOperator.DYNAMIC_UPDATE_SLICE, 121, 12);
        versionInfoArr[35].add(errorLevel2, 75, 47, 12);
        versionInfoArr[35].add(errorLevel3, 54, 24, 39);
        versionInfoArr[35].add(errorLevel4, 45, 15, 22);
        VersionInfo versionInfo39 = new VersionInfo(3034, new int[]{6, 24, 50, 76, 102, 128, BuiltinOperator.UNSORTED_SEGMENT_MAX});
        versionInfoArr[36] = versionInfo39;
        versionInfo39.add(errorLevel, BuiltinOperator.DYNAMIC_UPDATE_SLICE, 121, 6);
        versionInfoArr[36].add(errorLevel2, 75, 47, 6);
        versionInfoArr[36].add(errorLevel3, 54, 24, 46);
        versionInfoArr[36].add(errorLevel4, 45, 15, 2);
        VersionInfo versionInfo40 = new VersionInfo(3196, new int[]{6, 28, 54, 80, 106, BuiltinOperator.CONV_3D, BuiltinOperator.SIGN});
        versionInfoArr[37] = versionInfo40;
        versionInfo40.add(errorLevel, BuiltinOperator.RELU_0_TO_1, 122, 17);
        versionInfoArr[37].add(errorLevel2, 74, 46, 29);
        versionInfoArr[37].add(errorLevel3, 54, 24, 49);
        versionInfoArr[37].add(errorLevel4, 45, 15, 24);
        VersionInfo versionInfo41 = new VersionInfo(3362, new int[]{6, 32, 58, 84, 110, BuiltinOperator.HASHTABLE, 162});
        versionInfoArr[38] = versionInfo41;
        versionInfo41.add(errorLevel, BuiltinOperator.RELU_0_TO_1, 122, 4);
        versionInfoArr[38].add(errorLevel2, 74, 46, 13);
        versionInfoArr[38].add(errorLevel3, 54, 24, 48);
        versionInfoArr[38].add(errorLevel4, 45, 15, 42);
        VersionInfo versionInfo42 = new VersionInfo(3532, new int[]{6, 26, 54, 82, 110, BuiltinOperator.HASHTABLE_IMPORT, 166});
        versionInfoArr[39] = versionInfo42;
        versionInfo42.add(errorLevel, BuiltinOperator.BUCKETIZE, 117, 20);
        versionInfoArr[39].add(errorLevel2, 75, 47, 40);
        versionInfoArr[39].add(errorLevel3, 54, 24, 43);
        versionInfoArr[39].add(errorLevel4, 45, 15, 10);
        VersionInfo versionInfo43 = new VersionInfo(3706, new int[]{6, 30, 58, 86, 114, BuiltinOperator.VAR_HANDLE, 170});
        versionInfoArr[40] = versionInfo43;
        versionInfo43.add(errorLevel, BuiltinOperator.RANDOM_UNIFORM, 118, 19);
        versionInfoArr[40].add(errorLevel2, 75, 47, 18);
        versionInfoArr[40].add(errorLevel3, 54, 24, 34);
        versionInfoArr[40].add(errorLevel4, 45, 15, 20);
        for (int i = 1; i <= 40; i++) {
            LOCATION_BITS[i] = QrCodeCodeWordLocations.qrcode(i).bits;
        }
    }

    public QrCode() {
        reset();
    }

    public int getNumberOfModules() {
        return totalModules(this.version);
    }

    public static int totalModules(int i) {
        return (i * 4) + 17;
    }

    public void reset() {
        for (int i = 0; i < 4; i++) {
            this.ppCorner.get(i).setTo(0.0d, 0.0d);
            this.ppDown.get(i).setTo(0.0d, 0.0d);
            this.ppRight.get(i).setTo(0.0d, 0.0d);
        }
        this.threshCorner = 0.0d;
        this.threshDown = 0.0d;
        this.threshRight = 0.0d;
        this.version = -1;
        this.error = ErrorLevel.L;
        this.mask = QrCodeMaskPattern.M111;
        this.alignment.reset();
        this.mode = Mode.UNKNOWN;
        this.failureCause = Failure.NONE;
        this.byteEncoding = "";
        this.rawbits = null;
        this.corrected = null;
        this.message = null;
        this.bitsTransposed = false;
        this.totalBitErrors = 0;
    }

    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public QrCode m626clone() {
        return new QrCode().setTo(this);
    }

    public QrCode setTo(QrCode qrCode) {
        this.version = qrCode.version;
        this.error = qrCode.error;
        this.mask = qrCode.mask;
        this.mode = qrCode.mode;
        byte[] bArr = qrCode.rawbits;
        this.rawbits = bArr == null ? null : (byte[]) bArr.clone();
        byte[] bArr2 = qrCode.corrected;
        this.corrected = bArr2 != null ? (byte[]) bArr2.clone() : null;
        this.message = qrCode.message;
        this.threshCorner = qrCode.threshCorner;
        this.threshDown = qrCode.threshDown;
        this.threshRight = qrCode.threshRight;
        this.ppCorner.setTo(qrCode.ppCorner);
        this.ppDown.setTo(qrCode.ppDown);
        this.ppRight.setTo(qrCode.ppRight);
        this.failureCause = qrCode.failureCause;
        this.bounds.setTo(qrCode.bounds);
        this.alignment.reset();
        for (int i = 0; i < qrCode.alignment.size; i++) {
            ((Alignment) this.alignment.grow()).set((Alignment) qrCode.alignment.get(i));
        }
        this.Hinv.setTo(qrCode.Hinv);
        this.bitsTransposed = qrCode.bitsTransposed;
        this.totalBitErrors = qrCode.totalBitErrors;
        return this;
    }

    public enum ErrorLevel {
        L(1),
        M(0),
        Q(3),
        H(2);

        final int value;

        ErrorLevel(int i) {
            this.value = i;
        }

        public static ErrorLevel lookup(int i) {
            if (i == 0) {
                return M;
            }
            if (i == 1) {
                return L;
            }
            if (i == 2) {
                return H;
            }
            if (i == 3) {
                return Q;
            }
            throw new IllegalArgumentException("Unknown");
        }
    }

    public static class Alignment {
        public int moduleX;
        public int moduleY;
        public Point2D_F64 pixel = new Point2D_F64();
        Point2D_F64 moduleFound = new Point2D_F64();

        public void set(Alignment alignment) {
            this.pixel.setTo(alignment.pixel);
            this.moduleX = alignment.moduleX;
            this.moduleY = alignment.moduleY;
            this.moduleFound.setTo(alignment.moduleFound);
        }
    }

    public static class VersionInfo {
        public final int[] alignment;
        public final int codewords;
        public final Map levels = new HashMap();

        public VersionInfo(int i, int[] iArr) {
            this.codewords = i;
            this.alignment = iArr;
        }

        public void add(ErrorLevel errorLevel, int i, int i2, int i3) {
            this.levels.put(errorLevel, new BlockInfo(i, i2, i3));
        }
    }

    public static class BlockInfo {
        public final int blocks;
        public final int codewords;
        public final int dataCodewords;

        public BlockInfo(int i, int i2, int i3) {
            this.codewords = i;
            this.dataCodewords = i2;
            this.blocks = i3;
        }
    }

    public enum Mode {
        NUMERIC(1),
        ALPHANUMERIC(2),
        BYTE(4),
        KANJI(8),
        ECI(7),
        STRUCTURE_APPENDED(3),
        FNC1_FIRST(5),
        FNC1_SECOND(9),
        UNKNOWN(-1),
        MIXED(-2);

        final int bits;

        Mode(int i) {
            this.bits = i;
        }

        public static Mode lookup(int i) {
            Mode mode = NUMERIC;
            if (mode.bits == i) {
                return mode;
            }
            Mode mode2 = ALPHANUMERIC;
            if (mode2.bits == i) {
                return mode2;
            }
            Mode mode3 = BYTE;
            if (mode3.bits == i) {
                return mode3;
            }
            Mode mode4 = KANJI;
            if (mode4.bits == i) {
                return mode4;
            }
            Mode mode5 = ECI;
            if (mode5.bits == i) {
                return mode5;
            }
            Mode mode6 = STRUCTURE_APPENDED;
            if (mode6.bits == i) {
                return mode6;
            }
            Mode mode7 = FNC1_FIRST;
            if (mode7.bits == i) {
                return mode7;
            }
            Mode mode8 = FNC1_SECOND;
            return mode8.bits == i ? mode8 : UNKNOWN;
        }
    }
}
