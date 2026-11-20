package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ejml.data.BMatrixRMaj;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeCodeWordLocations extends BMatrixRMaj {
    public List bits;

    public static QrCodeCodeWordLocations qrcode(int i) {
        int i2 = QrCode.totalModules(i);
        int[] iArr = QrCode.VERSION_INFO[i].alignment;
        boolean z = i >= 7;
        QrCodeCodeWordLocations qrCodeCodeWordLocations = new QrCodeCodeWordLocations(i2);
        qrCodeCodeWordLocations.featureMaskQrCode(i2, iArr, z);
        qrCodeCodeWordLocations.computeBitLocations(false);
        return qrCodeCodeWordLocations;
    }

    private QrCodeCodeWordLocations(int i) {
        super(i, i);
        this.bits = new ArrayList();
    }

    private void featureMaskQrCode(int i, int[] iArr, boolean z) {
        markSquare(0, 0, 9);
        int i2 = i - 8;
        markRectangle(i2, 0, 9, 8);
        markRectangle(0, i2, 8, 9);
        int i3 = i - 16;
        markRectangle(8, 6, 1, i3);
        markRectangle(6, 8, i3, 1);
        if (z) {
            int i4 = i - 11;
            markRectangle(i4, 0, 6, 3);
            markRectangle(0, i4, 3, 6);
        }
        for (int i5 = 0; i5 < iArr.length; i5++) {
            int i6 = iArr[i5];
            for (int i7 = 0; i7 < iArr.length; i7++) {
                if ((i5 != 0 || i7 != 0) && ((i5 != iArr.length - 1 || i7 != 0) && (i5 != 0 || i7 != iArr.length - 1))) {
                    markSquare(i6 - 2, iArr[i7] - 2, 5);
                }
            }
        }
    }

    private void markSquare(int i, int i2, int i3) {
        for (int i4 = 0; i4 < i3; i4++) {
            for (int i5 = 0; i5 < i3; i5++) {
                set(i + i4, i2 + i5, true);
            }
        }
    }

    private void markRectangle(int i, int i2, int i3, int i4) {
        for (int i5 = 0; i5 < i4; i5++) {
            for (int i6 = 0; i6 < i3; i6++) {
                set(i + i5, i2 + i6, true);
            }
        }
    }

    private void computeBitLocations(boolean z) {
        int i = this.numRows;
        int i2 = i - 1;
        int i3 = -1;
        int i4 = i2;
        while (i2 > 0) {
            if (i2 == 6 && !z) {
                i2--;
            }
            if (!get(i4, i2)) {
                this.bits.add(new Point2D_I32(i2, i4));
            }
            int i5 = i2 - 1;
            if (!get(i4, i5)) {
                this.bits.add(new Point2D_I32(i5, i4));
            }
            i4 += i3;
            if (i4 < 0 || i4 >= i) {
                i3 = -i3;
                i2 -= 2;
                i4 += i3;
            }
        }
    }
}
