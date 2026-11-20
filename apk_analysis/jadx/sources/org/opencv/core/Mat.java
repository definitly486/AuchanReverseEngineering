package org.opencv.core;

import com.scanflow.datacapture.barinternal.org.opencv.core.CvType;
import com.scanflow.datacapture.barinternal.org.opencv.core.Range;
import com.scanflow.datacapture.barinternal.org.opencv.core.Size;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public class Mat {
    public final long nativeObj;

    private static native void locateROI_0(long j, double[] dArr, double[] dArr2);

    private static native String nDump(long j);

    private static native double[] nGet(long j, int i, int i2);

    private static native int nGetB(long j, int i, int i2, int i3, byte[] bArr);

    private static native int nGetBIdx(long j, int[] iArr, int i, byte[] bArr);

    private static native int nGetD(long j, int i, int i2, int i3, double[] dArr);

    private static native int nGetDIdx(long j, int[] iArr, int i, double[] dArr);

    private static native int nGetF(long j, int i, int i2, int i3, float[] fArr);

    private static native int nGetFIdx(long j, int[] iArr, int i, float[] fArr);

    private static native int nGetI(long j, int i, int i2, int i3, int[] iArr);

    private static native int nGetIIdx(long j, int[] iArr, int i, int[] iArr2);

    private static native double[] nGetIdx(long j, int[] iArr);

    private static native int nGetS(long j, int i, int i2, int i3, short[] sArr);

    private static native int nGetSIdx(long j, int[] iArr, int i, short[] sArr);

    private static native int nPutB(long j, int i, int i2, int i3, byte[] bArr);

    private static native int nPutBIdx(long j, int[] iArr, int i, byte[] bArr);

    private static native int nPutBwIdxOffset(long j, int[] iArr, int i, int i2, byte[] bArr);

    private static native int nPutBwOffset(long j, int i, int i2, int i3, int i4, byte[] bArr);

    private static native int nPutD(long j, int i, int i2, int i3, double[] dArr);

    private static native int nPutDIdx(long j, int[] iArr, int i, double[] dArr);

    private static native int nPutF(long j, int i, int i2, int i3, float[] fArr);

    private static native int nPutFIdx(long j, int[] iArr, int i, float[] fArr);

    private static native int nPutI(long j, int i, int i2, int i3, int[] iArr);

    private static native int nPutIIdx(long j, int[] iArr, int i, int[] iArr2);

    private static native int nPutS(long j, int i, int i2, int i3, short[] sArr);

    private static native int nPutSIdx(long j, int[] iArr, int i, short[] sArr);

    private static native long n_Mat();

    private static native long n_Mat(double d, double d2, int i);

    private static native long n_Mat(double d, double d2, int i, double d3, double d4, double d5, double d6);

    private static native long n_Mat(int i, int i2, int i3);

    private static native long n_Mat(int i, int i2, int i3, double d, double d2, double d3, double d4);

    private static native long n_Mat(int i, int i2, int i3, ByteBuffer byteBuffer);

    private static native long n_Mat(int i, int i2, int i3, ByteBuffer byteBuffer, long j);

    private static native long n_Mat(int i, int[] iArr, int i2);

    private static native long n_Mat(int i, int[] iArr, int i2, double d, double d2, double d3, double d4);

    private static native long n_Mat(long j, int i, int i2);

    private static native long n_Mat(long j, int i, int i2, int i3, int i4);

    private static native long n_Mat(long j, Range[] rangeArr);

    private static native long n_adjustROI(long j, int i, int i2, int i3, int i4);

    private static native void n_assignTo(long j, long j2);

    private static native void n_assignTo(long j, long j2, int i);

    private static native int n_channels(long j);

    private static native int n_checkVector(long j, int i);

    private static native int n_checkVector(long j, int i, int i2);

    private static native int n_checkVector(long j, int i, int i2, boolean z);

    private static native long n_clone(long j);

    private static native long n_col(long j, int i);

    private static native long n_colRange(long j, int i, int i2);

    private static native int n_cols(long j);

    private static native void n_convertTo(long j, long j2, int i);

    private static native void n_convertTo(long j, long j2, int i, double d);

    private static native void n_convertTo(long j, long j2, int i, double d, double d2);

    private static native void n_copySize(long j, long j2);

    private static native void n_copyTo(long j, long j2);

    private static native void n_copyTo(long j, long j2, long j3);

    private static native void n_create(long j, double d, double d2, int i);

    private static native void n_create(long j, int i, int i2, int i3);

    private static native void n_create(long j, int i, int[] iArr, int i2);

    private static native long n_cross(long j, long j2);

    private static native long n_dataAddr(long j);

    private static native void n_delete(long j);

    private static native int n_depth(long j);

    private static native long n_diag(long j);

    private static native long n_diag(long j, int i);

    private static native int n_dims(long j);

    private static native double n_dot(long j, long j2);

    private static native long n_elemSize(long j);

    private static native long n_elemSize1(long j);

    private static native boolean n_empty(long j);

    private static native long n_eye(double d, double d2, int i);

    private static native long n_eye(int i, int i2, int i3);

    private static native long n_inv(long j);

    private static native long n_inv(long j, int i);

    private static native boolean n_isContinuous(long j);

    private static native boolean n_isSubmatrix(long j);

    private static native long n_matMul(long j, long j2);

    private static native long n_mul(long j, long j2);

    private static native long n_mul(long j, long j2, double d);

    private static native long n_ones(double d, double d2, int i);

    private static native long n_ones(int i, int i2, int i3);

    private static native long n_ones(int i, int[] iArr, int i2);

    private static native void n_push_back(long j, long j2);

    private static native void n_release(long j);

    private static native long n_reshape(long j, int i);

    private static native long n_reshape(long j, int i, int i2);

    private static native long n_reshape_1(long j, int i, int i2, int[] iArr);

    private static native long n_row(long j, int i);

    private static native long n_rowRange(long j, int i, int i2);

    private static native int n_rows(long j);

    private static native long n_setTo(long j, double d, double d2, double d3, double d4);

    private static native long n_setTo(long j, double d, double d2, double d3, double d4, long j2);

    private static native long n_setTo(long j, long j2);

    private static native long n_setTo(long j, long j2, long j3);

    private static native double[] n_size(long j);

    private static native int n_size_i(long j, int i);

    private static native long n_step1(long j);

    private static native long n_step1(long j, int i);

    private static native long n_submat(long j, int i, int i2, int i3, int i4);

    private static native long n_submat_ranges(long j, Range[] rangeArr);

    private static native long n_submat_rr(long j, int i, int i2, int i3, int i4);

    private static native long n_t(long j);

    private static native long n_total(long j);

    private static native int n_type(long j);

    private static native long n_zeros(double d, double d2, int i);

    private static native long n_zeros(int i, int i2, int i3);

    private static native long n_zeros(int i, int[] iArr, int i2);

    public Mat(long j) {
        if (j == 0) {
            throw new UnsupportedOperationException("Native object address is NULL");
        }
        this.nativeObj = j;
    }

    public Mat() {
        this.nativeObj = n_Mat();
    }

    public Mat(int i, int i2, int i3) {
        this.nativeObj = n_Mat(i, i2, i3);
    }

    public Mat(Mat mat, Range range) {
        this.nativeObj = n_Mat(mat.nativeObj, range.start, range.end);
    }

    public int channels() {
        return n_channels(this.nativeObj);
    }

    public int checkVector(int i, int i2) {
        return n_checkVector(this.nativeObj, i, i2);
    }

    public Mat clone() {
        return new Mat(n_clone(this.nativeObj));
    }

    public int dims() {
        return n_dims(this.nativeObj);
    }

    public int cols() {
        return n_cols(this.nativeObj);
    }

    public long dataAddr() {
        return n_dataAddr(this.nativeObj);
    }

    public boolean empty() {
        return n_empty(this.nativeObj);
    }

    public boolean isContinuous() {
        return n_isContinuous(this.nativeObj);
    }

    public boolean isSubmatrix() {
        return n_isSubmatrix(this.nativeObj);
    }

    public void release() {
        n_release(this.nativeObj);
    }

    public int rows() {
        return n_rows(this.nativeObj);
    }

    public Size size() {
        return new Size(n_size(this.nativeObj));
    }

    public int size(int i) {
        return n_size_i(this.nativeObj, i);
    }

    public long total() {
        return n_total(this.nativeObj);
    }

    public int type() {
        return n_type(this.nativeObj);
    }

    public static Mat zeros(Size size, int i) {
        return new Mat(n_zeros(size.width, size.height, i));
    }

    protected void finalize() throws Throwable {
        n_delete(this.nativeObj);
        super.finalize();
    }

    public String toString() {
        String str = dims() > 0 ? "" : "-1*-1*";
        for (int i = 0; i < dims(); i++) {
            str = str + size(i) + "*";
        }
        return "Mat [ " + str + CvType.typeToString(type()) + ", isCont=" + isContinuous() + ", isSubmat=" + isSubmatrix() + ", nativeObj=0x" + Long.toHexString(this.nativeObj) + ", dataAddr=0x" + Long.toHexString(dataAddr()) + " ]";
    }

    public int put(int i, int i2, double... dArr) {
        int iType = type();
        if (dArr == null || dArr.length % CvType.channels(iType) != 0) {
            StringBuilder sb = new StringBuilder();
            sb.append("Provided data element number (");
            sb.append(dArr == null ? 0 : dArr.length);
            sb.append(") should be multiple of the Mat channels count (");
            sb.append(CvType.channels(iType));
            sb.append(")");
            throw new UnsupportedOperationException(sb.toString());
        }
        return nPutD(this.nativeObj, i, i2, dArr.length, dArr);
    }

    public int put(int i, int i2, int[] iArr) {
        int iType = type();
        if (iArr == null || iArr.length % CvType.channels(iType) != 0) {
            StringBuilder sb = new StringBuilder();
            sb.append("Provided data element number (");
            sb.append(iArr == null ? 0 : iArr.length);
            sb.append(") should be multiple of the Mat channels count (");
            sb.append(CvType.channels(iType));
            sb.append(")");
            throw new UnsupportedOperationException(sb.toString());
        }
        if (CvType.depth(iType) == 4) {
            return nPutI(this.nativeObj, i, i2, iArr.length, iArr);
        }
        throw new UnsupportedOperationException("Mat data type is not compatible: " + iType);
    }

    public int put(int i, int i2, byte[] bArr) {
        int iType = type();
        if (bArr == null || bArr.length % CvType.channels(iType) != 0) {
            StringBuilder sb = new StringBuilder();
            sb.append("Provided data element number (");
            sb.append(bArr == null ? 0 : bArr.length);
            sb.append(") should be multiple of the Mat channels count (");
            sb.append(CvType.channels(iType));
            sb.append(")");
            throw new UnsupportedOperationException(sb.toString());
        }
        if (CvType.depth(iType) == 0 || CvType.depth(iType) == 1) {
            return nPutB(this.nativeObj, i, i2, bArr.length, bArr);
        }
        throw new UnsupportedOperationException("Mat data type is not compatible: " + iType);
    }

    public int get(int i, int i2, int[] iArr) {
        int iType = type();
        if (iArr == null || iArr.length % CvType.channels(iType) != 0) {
            StringBuilder sb = new StringBuilder();
            sb.append("Provided data element number (");
            sb.append(iArr == null ? 0 : iArr.length);
            sb.append(") should be multiple of the Mat channels count (");
            sb.append(CvType.channels(iType));
            sb.append(")");
            throw new UnsupportedOperationException(sb.toString());
        }
        if (CvType.depth(iType) == 4) {
            return nGetI(this.nativeObj, i, i2, iArr.length, iArr);
        }
        throw new UnsupportedOperationException("Mat data type is not compatible: " + iType);
    }

    public double[] get(int i, int i2) {
        return nGet(this.nativeObj, i, i2);
    }
}
