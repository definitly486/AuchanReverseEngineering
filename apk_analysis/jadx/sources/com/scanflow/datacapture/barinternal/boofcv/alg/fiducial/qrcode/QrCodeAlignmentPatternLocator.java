package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.FastArray;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeAlignmentPatternLocator {
    QrCode qr;
    QrCodeBinaryGridReader reader;
    float threshold;
    private final FastArray lookup = new FastArray(QrCode.Alignment.class);
    float[] arrayX = new float[12];
    float[] arrayY = new float[12];
    float[] samples = new float[9];

    public QrCodeAlignmentPatternLocator(Class cls) {
        this.reader = new QrCodeBinaryGridReader(cls);
    }

    public boolean process(ImageGray imageGray, QrCode qrCode) {
        this.qr = qrCode;
        qrCode.alignment.reset();
        this.reader.setImage(imageGray);
        this.reader.setMarker(qrCode);
        this.threshold = (float) qrCode.threshCorner;
        initializePatterns(qrCode);
        int i = qrCode.version;
        if (i <= 1) {
            return true;
        }
        return localizePositionPatterns(QrCode.VERSION_INFO[i].alignment);
    }

    void initializePatterns(QrCode qrCode) {
        int[] iArr = QrCode.VERSION_INFO[qrCode.version].alignment;
        qrCode.alignment.reset();
        this.lookup.reset();
        for (int i = 0; i < iArr.length; i++) {
            for (int i2 = 0; i2 < iArr.length; i2++) {
                if ((i == 0 && i2 == 0) || ((i == 0 && i2 == iArr.length - 1) || (i == iArr.length - 1 && i2 == 0))) {
                    this.lookup.add(null);
                } else {
                    QrCode.Alignment alignment = (QrCode.Alignment) qrCode.alignment.grow();
                    alignment.moduleX = iArr[i2];
                    alignment.moduleY = iArr[i];
                    this.lookup.add(alignment);
                }
            }
        }
    }

    boolean localizePositionPatterns(int[] iArr) {
        QrCode.Alignment alignment;
        QrCode.Alignment alignment2;
        int length = iArr.length;
        int i = 0;
        while (i < length) {
            for (int i2 = 0; i2 < length; i2++) {
                int i3 = (i * length) + i2;
                QrCode.Alignment alignment3 = (QrCode.Alignment) this.lookup.get(i3);
                if (alignment3 != null) {
                    double d = 0.0d;
                    double d2 = (i <= 0 || (alignment2 = (QrCode.Alignment) this.lookup.get(((i + (-1)) * length) + i2)) == null) ? 0.0d : (((double) alignment2.moduleY) + 0.5d) - alignment2.moduleFound.y;
                    if (i2 > 0 && (alignment = (QrCode.Alignment) this.lookup.get(i3 - 1)) != null) {
                        d = (((double) alignment.moduleX) + 0.5d) - alignment.moduleFound.x;
                    }
                    if (!centerOnSquare(alignment3, (float) (((double) alignment3.moduleY) + 0.5d + d2), (float) (((double) alignment3.moduleX) + 0.5d + d))) {
                        return false;
                    }
                    Point2D_F64 point2D_F64 = alignment3.moduleFound;
                    if (!meanshift(alignment3, (float) point2D_F64.y, (float) point2D_F64.x)) {
                        return false;
                    }
                }
            }
            i++;
        }
        return true;
    }

    boolean centerOnSquare(QrCode.Alignment alignment, float f, float f2) {
        boolean z;
        float f3 = 1.0f;
        float f4 = f;
        float f5 = f2;
        float f6 = f5;
        float f7 = 1.0f;
        float f8 = Float.MAX_VALUE;
        int i = 0;
        float f9 = f4;
        while (i < 10) {
            int i2 = 0;
            while (i2 < 3) {
                float f10 = (f9 - f3) + i2;
                int i3 = 0;
                while (i3 < 3) {
                    this.samples[(i2 * 3) + i3] = this.reader.read(f10, (f5 - f3) + i3);
                    i3++;
                    f3 = 1.0f;
                }
                i2++;
                f3 = 1.0f;
            }
            z = true;
            float[] fArr = this.samples;
            float f11 = fArr[2];
            float f12 = fArr[5] + f11;
            float f13 = fArr[8];
            float f14 = fArr[0];
            float f15 = fArr[3] + f14;
            float f16 = fArr[6];
            float f17 = (f12 + f13) - (f15 + f16);
            float f18 = ((f16 + fArr[7]) + f13) - ((f14 + fArr[1]) + f11);
            float fSqrt = (float) Math.sqrt((f17 * f17) + (f18 * f18));
            if (f8 > fSqrt) {
                f8 = fSqrt;
                f4 = f9;
                f6 = f5;
            } else {
                f7 *= 0.75f;
            }
            if (fSqrt <= 0.0f) {
                Point2D_F64 point2D_F64 = alignment.moduleFound;
                double d = f6;
                point2D_F64.x = d;
                double d2 = f4;
                point2D_F64.y = d2;
                this.reader.gridToImage((float) d2, (float) d, alignment.pixel);
                return z;
            }
            f5 = f6 + ((f17 * f7) / fSqrt);
            f9 = f4 + ((f18 * f7) / fSqrt);
            i++;
            f3 = 1.0f;
        }
        z = true;
        Point2D_F64 point2D_F65 = alignment.moduleFound;
        double d3 = f6;
        point2D_F65.x = d3;
        double d4 = f4;
        point2D_F65.y = d4;
        this.reader.gridToImage((float) d4, (float) d3, alignment.pixel);
        return z;
    }

    boolean meanshift(QrCode.Alignment alignment, float f, float f2) {
        float f3 = f2;
        float f4 = 1.0f;
        int i = 0;
        float f5 = f;
        while (i < 10) {
            float f6 = 0.0f;
            float fAbs = 0.0f;
            float f7 = 0.0f;
            int i2 = 0;
            while (true) {
                int i3 = 8;
                if (i2 < 8) {
                    float f8 = 7.0f;
                    float f9 = -1.5f;
                    float f10 = ((i2 * 3.0f) / 7.0f) - 1.5f;
                    float f11 = f5 + f10;
                    int i4 = 0;
                    while (i4 < i3) {
                        float f12 = ((i4 * 3.0f) / f8) + f9;
                        float f13 = this.reader.read(f11, f3 + f12);
                        float f14 = f4;
                        int i5 = i;
                        float fMax = Math.max(-10.0f, ((double) ((float) Math.sqrt((double) ((f12 * f12) + (f10 * f10))))) > 0.5d ? f13 - this.threshold : this.threshold - f13);
                        fAbs += Math.abs(fMax);
                        f6 += f12 * fMax;
                        f7 += fMax * f10;
                        i4++;
                        f4 = f14;
                        i = i5;
                        i3 = 8;
                        f8 = 7.0f;
                        f9 = -1.5f;
                    }
                    i2++;
                }
            }
            float f15 = f4;
            f3 += (f15 * f6) / fAbs;
            f5 += (f15 * f7) / fAbs;
            f4 = f15 * 0.7f;
            i++;
        }
        Point2D_F64 point2D_F64 = alignment.moduleFound;
        double d = f3;
        point2D_F64.x = d;
        double d2 = f5;
        point2D_F64.y = d2;
        this.reader.gridToImage((float) d2, (float) d, alignment.pixel);
        return true;
    }
}
