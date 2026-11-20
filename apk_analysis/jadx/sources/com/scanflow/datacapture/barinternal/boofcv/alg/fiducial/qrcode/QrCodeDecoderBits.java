package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I8;
import java.io.PrintStream;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeDecoderBits {
    String encodingEci;
    int totalErrorBits;
    final QrCodeCodecBitsUtils utils;
    ReedSolomonCodes_U8 rscodes = new ReedSolomonCodes_U8(8, 285, 0);
    DogArray_I8 message = new DogArray_I8();
    DogArray_I8 ecc = new DogArray_I8();
    public boolean ignorePaddingBytes = false;
    PrintStream verbose = null;

    public QrCodeDecoderBits(String str, String str2) {
        this.utils = new QrCodeCodecBitsUtils(str, str2);
    }

    public boolean applyErrorCorrection(QrCode qrCode) {
        QrCode.VersionInfo versionInfo = QrCode.VERSION_INFO[qrCode.version];
        QrCode.BlockInfo blockInfo = (QrCode.BlockInfo) versionInfo.levels.get(qrCode.error);
        Objects.requireNonNull(blockInfo);
        int i = blockInfo.codewords;
        int i2 = blockInfo.dataCodewords;
        int i3 = i - i2;
        int i4 = blockInfo.blocks;
        int i5 = i2 + 1;
        int i6 = (versionInfo.codewords - (i * i4)) / (i + 1);
        int i7 = i4 + i6;
        int i8 = i2 * i4;
        int i9 = i8 + (i5 * i6);
        qrCode.corrected = new byte[i9];
        this.ecc.resize(i3);
        this.rscodes.generator(i3);
        this.totalErrorBits = 0;
        if (!decodeBlocks(qrCode, i2, i4, 0, 0, i9, i7) || !decodeBlocks(qrCode, i5, i6, i8, i4, i9, i7)) {
            return false;
        }
        qrCode.totalBitErrors = this.totalErrorBits;
        return true;
    }

    private boolean decodeBlocks(QrCode qrCode, int i, int i2, int i3, int i4, int i5, int i6) {
        this.message.resize(i);
        int i7 = 0;
        while (i7 < i2) {
            int i8 = i5;
            int i9 = i6;
            copyFromRawData(qrCode.rawbits, this.message, this.ecc, i4 + i7, i9, i8);
            QrCodeCodecBitsUtils.flipBits8(this.message);
            QrCodeCodecBitsUtils.flipBits8(this.ecc);
            if (!this.rscodes.correct(this.message, this.ecc)) {
                return false;
            }
            this.totalErrorBits += this.rscodes.getTotalErrors();
            QrCodeCodecBitsUtils.flipBits8(this.message);
            DogArray_I8 dogArray_I8 = this.message;
            System.arraycopy(dogArray_I8.data, 0, qrCode.corrected, i3, dogArray_I8.size);
            i3 += this.message.size;
            i7++;
            i6 = i9;
            i5 = i8;
        }
        return true;
    }

    private void copyFromRawData(byte[] bArr, DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, int i, int i2, int i3) {
        for (int i4 = 0; i4 < dogArray_I8.size; i4++) {
            dogArray_I8.data[i4] = bArr[(i4 * i2) + i];
        }
        for (int i5 = 0; i5 < dogArray_I9.size; i5++) {
            dogArray_I9.data[i5] = bArr[(i5 * i2) + i + i3];
        }
    }

    public boolean decodeMessage(QrCode qrCode) {
        PrintStream printStream = this.verbose;
        if (printStream != null) {
            printStream.println("decodeMessage: qr.corner=" + qrCode.ppCorner.get(0));
        }
        this.encodingEci = null;
        this.utils.workString.setLength(0);
        try {
            int iDecideMessageBits = decideMessageBits(qrCode);
            if (iDecideMessageBits < 0) {
                return false;
            }
            int iAlignToBytes = alignToBytes(iDecideMessageBits) / 8;
            qrCode.message = this.utils.workString.toString();
            if (this.ignorePaddingBytes || checkPaddingBytes(qrCode, iAlignToBytes)) {
                return true;
            }
            qrCode.failureCause = QrCode.Failure.READING_PADDING;
            return false;
        } catch (RuntimeException e) {
            PrintStream printStream2 = this.verbose;
            if (printStream2 != null) {
                e.printStackTrace(printStream2);
            }
            qrCode.failureCause = QrCode.Failure.DECODING_MESSAGE;
            qrCode.message = this.utils.workString.toString();
            return false;
        }
    }

    private int decideMessageBits(QrCode qrCode) {
        qrCode.byteEncoding = "";
        PackedBits8 packedBits8 = new PackedBits8();
        byte[] bArr = qrCode.corrected;
        packedBits8.data = bArr;
        packedBits8.size = bArr.length * 8;
        int iDecodeNumeric = 0;
        do {
            int i = iDecodeNumeric + 4;
            if (i > packedBits8.size) {
                return iDecodeNumeric;
            }
            int i2 = packedBits8.read(iDecodeNumeric, 4, true);
            if (i2 == 0) {
                PrintStream printStream = this.verbose;
                if (printStream != null) {
                    printStream.printf("bit_loc=%d/%d escape mode\n", Integer.valueOf(i), Integer.valueOf(packedBits8.size));
                }
                return i;
            }
            QrCode.Mode modeLookup = QrCode.Mode.lookup(i2);
            PrintStream printStream2 = this.verbose;
            if (printStream2 != null) {
                printStream2.printf("bit_loc=%d/%d mode=%s\n", Integer.valueOf(i), Integer.valueOf(packedBits8.size), modeLookup);
            }
            qrCode.mode = updateModeLogic(qrCode.mode, modeLookup);
            switch (AnonymousClass1.$SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[modeLookup.ordinal()]) {
                case 1:
                    iDecodeNumeric = decodeNumeric(qrCode, packedBits8, i);
                    break;
                case 2:
                    iDecodeNumeric = decodeAlphanumeric(qrCode, packedBits8, i);
                    break;
                case 3:
                    iDecodeNumeric = decodeByte(qrCode, packedBits8, i);
                    if (qrCode.byteEncoding.isEmpty()) {
                        qrCode.byteEncoding = this.utils.selectedByteEncoding;
                    }
                    break;
                case 4:
                    iDecodeNumeric = decodeKanji(qrCode, packedBits8, i);
                    break;
                case 5:
                    iDecodeNumeric = decodeEci(packedBits8, i);
                    break;
                case 6:
                case 7:
                    iDecodeNumeric = i;
                    break;
                default:
                    qrCode.failureCause = QrCode.Failure.UNKNOWN_MODE;
                    return -1;
            }
        } while (iDecodeNumeric >= 0);
        qrCode.failureCause = this.utils.failureCause;
        return -1;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeDecoderBits$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode;

        static {
            int[] iArr = new int[QrCode.Mode.values().length];
            $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode = iArr;
            try {
                iArr[QrCode.Mode.NUMERIC.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.ALPHANUMERIC.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.BYTE.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.KANJI.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.ECI.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.FNC1_FIRST.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode[QrCode.Mode.FNC1_SECOND.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
        }
    }

    private QrCode.Mode updateModeLogic(QrCode.Mode mode, QrCode.Mode mode2) {
        if (mode == mode2) {
            return mode;
        }
        return mode == QrCode.Mode.UNKNOWN ? mode2 : QrCode.Mode.MIXED;
    }

    public static int alignToBytes(int i) {
        return i + ((8 - (i % 8)) % 8);
    }

    boolean checkPaddingBytes(QrCode qrCode, int i) {
        boolean z = true;
        while (true) {
            byte[] bArr = qrCode.corrected;
            if (i >= bArr.length) {
                return true;
            }
            if (z) {
                if (55 != (bArr[i] & UnsignedBytes.MAX_VALUE)) {
                    return false;
                }
            } else {
                byte b = bArr[i];
                if (136 == (b & UnsignedBytes.MAX_VALUE)) {
                    continue;
                } else {
                    if (55 != (b & UnsignedBytes.MAX_VALUE)) {
                        return false;
                    }
                    z = true;
                }
            }
            z = !z;
            i++;
        }
    }

    private int decodeNumeric(QrCode qrCode, PackedBits8 packedBits8, int i) {
        return this.utils.decodeNumeric(packedBits8, i, QrCodeEncoder.getLengthBitsNumeric(qrCode.version));
    }

    private int decodeAlphanumeric(QrCode qrCode, PackedBits8 packedBits8, int i) {
        return this.utils.decodeAlphanumeric(packedBits8, i, QrCodeEncoder.getLengthBitsAlphanumeric(qrCode.version));
    }

    private int decodeByte(QrCode qrCode, PackedBits8 packedBits8, int i) {
        int lengthBitsBytes = QrCodeEncoder.getLengthBitsBytes(qrCode.version);
        QrCodeCodecBitsUtils qrCodeCodecBitsUtils = this.utils;
        qrCodeCodecBitsUtils.encodingEci = this.encodingEci;
        return qrCodeCodecBitsUtils.decodeByte(packedBits8, i, lengthBitsBytes);
    }

    private int decodeKanji(QrCode qrCode, PackedBits8 packedBits8, int i) {
        return this.utils.decodeKanji(packedBits8, i, QrCodeEncoder.getLengthBitsKanji(qrCode.version));
    }

    int decodeEci(PackedBits8 packedBits8, int i) {
        int i2 = packedBits8.read(i, 8, true);
        int i3 = i + 8;
        int i4 = 1;
        while (((1 << (7 - i4)) & i2) != 0) {
            i4++;
        }
        if (i4 > 1) {
            int i5 = i4 - 1;
            i2 = (i2 << i5) >> i5;
        }
        for (int i6 = 1; i6 < i4; i6++) {
            i2 = (i2 << 8) | packedBits8.read(i3, 8, true);
            i3 += 8;
        }
        this.encodingEci = EciEncoding.getEciCharacterSet(i2);
        return i3;
    }
}
