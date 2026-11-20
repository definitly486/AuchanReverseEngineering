package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import android.util.Log;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__BuildersKt;
import com.scanflow.datacapture.barinternal.org.opencv.core.CvType;
import com.scanflow.datacapture.barinternal.org.opencv.core.MatOfPoint;
import com.scanflow.datacapture.barinternal.org.opencv.core.Point;
import com.scanflow.datacapture.barinternal.org.opencv.core.Scalar;
import com.scanflow.datacapture.barinternal.org.opencv.core.Size;
import java.util.ArrayList;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.android.Utils;
import org.opencv.core.Core;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: loaded from: classes3.dex */
public abstract class r {
    public static Bitmap a(Bitmap inputBitmap) {
        Intrinsics.checkNotNullParameter(inputBitmap, "inputBitmap");
        Log.v("DotMatrixPreProcessing", "applyDotMatrixArea - Started");
        Mat mat = new Mat();
        Utils.bitmapToMat(inputBitmap, mat);
        Mat mat2 = new Mat();
        Imgproc.cvtColor(mat, mat2, 6);
        Mat mat3 = new Mat();
        Imgproc.GaussianBlur(mat2, mat3, new Size(5.0d, 5.0d), 0.0d);
        Mat mat4 = new Mat();
        Imgproc.Canny(mat3, mat4, 50.0d, 150.0d);
        ArrayList arrayList = new ArrayList();
        Imgproc.findContours(mat4, arrayList, new Mat(), 0, 2);
        ArrayList arrayList2 = new ArrayList();
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            if (Imgproc.contourArea((MatOfPoint) obj) > 5.0d) {
                arrayList2.add(obj);
            }
        }
        Mat matZeros = Mat.zeros(mat2.size(), CvType.CV_8UC3);
        Imgproc.drawContours(matZeros, arrayList2, -1, new Scalar(255.0d, 255.0d, 255.0d), 7);
        Mat mat5 = new Mat();
        Imgproc.cvtColor(matZeros, mat5, 6);
        Mat mat6 = new Mat();
        Imgproc.threshold(mat5, mat6, 128.0d, 255.0d, 0);
        Mat mat7 = new Mat();
        Core.bitwise_not(mat6, mat7);
        Mat mat8 = new Mat();
        Mat mat9 = new Mat();
        int iConnectedComponentsWithStats = Imgproc.connectedComponentsWithStats(mat7, mat9, mat8, new Mat(), 8, 4);
        Mat mat10 = mat7;
        int iRows = mat2.rows();
        int iCols = mat2.cols();
        int i2 = 1;
        while (i2 < iConnectedComponentsWithStats) {
            if (mat8.get(i2, 4)[0] < 10.0d) {
                Mat mat11 = mat9;
                mat9 = mat11;
                BuildersKt__BuildersKt.runBlocking$default(null, new C0097o(iRows, iCols, i2, null, mat11, mat10), 1, null);
            }
            i2++;
            mat10 = mat10;
        }
        Mat mat12 = mat10;
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap((int) mat12.size().width, (int) mat12.size().height, Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        Utils.matToBitmap(mat12, bitmapCreateBitmap);
        Log.v("DotMatrixPreProcessing", "applyDotMatrixArea - Completed");
        return bitmapCreateBitmap;
    }

    public static Bitmap b(Bitmap inputBitmap) {
        int i;
        Intrinsics.checkNotNullParameter(inputBitmap, "inputBitmap");
        Log.v("DotMatrixPreProcessing", "applyDotMatrixArea - Started");
        Mat mat = new Mat();
        Utils.bitmapToMat(inputBitmap, mat);
        Mat mat2 = new Mat();
        Imgproc.cvtColor(mat, mat2, 11);
        Mat mat3 = new Mat();
        Imgproc.GaussianBlur(mat2, mat3, new Size(5.0d, 5.0d), 0.0d);
        Mat mat4 = new Mat();
        Imgproc.Canny(mat3, mat4, 0.0d, 50.0d);
        ArrayList arrayList = new ArrayList();
        Imgproc.findContours(mat4, arrayList, new Mat(), 0, 2);
        ArrayList arrayList2 = new ArrayList();
        int size = arrayList.size();
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            if (Imgproc.contourArea((MatOfPoint) obj) > 0.0d) {
                arrayList2.add(obj);
            }
        }
        Mat matZeros = Mat.zeros(mat.size(), CvType.CV_8UC1);
        Imgproc.drawContours(matZeros, arrayList2, -1, new Scalar(255.0d), 2);
        Mat mat5 = new Mat();
        Imgproc.threshold(matZeros, mat5, 128.0d, 255.0d, 0);
        Mat structuringElement = Imgproc.getStructuringElement(0, new Size(1.0d, 1.0d));
        Mat mat6 = new Mat();
        Imgproc.dilate(mat5, mat6, structuringElement, new Point(-1.0d, -1.0d), 1);
        Mat mat7 = new Mat();
        Core.bitwise_not(mat6, mat7);
        Mat mat8 = new Mat();
        Mat mat9 = new Mat();
        Mat mat10 = mat8;
        int iConnectedComponentsWithStats = Imgproc.connectedComponentsWithStats(mat7, mat10, mat9, new Mat(), 8, 4);
        Mat mat11 = mat7;
        int iRows = mat2.rows();
        int iCols = mat2.cols();
        int i3 = 1;
        while (i3 < iConnectedComponentsWithStats) {
            if (mat9.get(i3, 4)[0] < 1500.0d) {
                Mat mat12 = mat10;
                int i4 = iRows;
                C0102q c0102q = new C0102q(i4, iCols, i3, null, mat12, mat11);
                i = i4;
                mat10 = mat12;
                BuildersKt__BuildersKt.runBlocking$default(null, c0102q, 1, null);
            } else {
                i = iRows;
            }
            i3++;
            iRows = i;
            mat11 = mat11;
        }
        Mat mat13 = mat11;
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap((int) mat13.size().width, (int) mat13.size().height, Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        Utils.matToBitmap(mat13, bitmapCreateBitmap);
        Log.v("DotMatrixPreProcessing", "applyDotMatrixArea - Completed");
        return bitmapCreateBitmap;
    }
}
