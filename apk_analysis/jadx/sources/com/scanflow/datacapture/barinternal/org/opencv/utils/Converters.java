package com.scanflow.datacapture.barinternal.org.opencv.utils;

import com.scanflow.datacapture.barinternal.org.opencv.core.CvType;
import com.scanflow.datacapture.barinternal.org.opencv.core.MatOfPoint;
import java.util.ArrayList;
import java.util.List;
import org.opencv.core.Mat;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Converters {
    public static Mat vector_Mat_to_Mat(List list) {
        int size = list != null ? list.size() : 0;
        if (size > 0) {
            Mat mat = new Mat(size, 1, CvType.CV_32SC2);
            int[] iArr = new int[size * 2];
            for (int i = 0; i < size; i++) {
                long j = ((Mat) list.get(i)).nativeObj;
                int i2 = i * 2;
                iArr[i2] = (int) (j >> 32);
                iArr[i2 + 1] = (int) j;
            }
            mat.put(0, 0, iArr);
            return mat;
        }
        return new Mat();
    }

    public static void Mat_to_vector_Mat(Mat mat, List list) {
        if (list == null) {
            throw new IllegalArgumentException("mats == null");
        }
        int iRows = mat.rows();
        if (CvType.CV_32SC2 != mat.type() || mat.cols() != 1) {
            throw new IllegalArgumentException("CvType.CV_32SC2 != m.type() ||  m.cols()!=1\n" + mat);
        }
        list.clear();
        int[] iArr = new int[iRows * 2];
        mat.get(0, 0, iArr);
        for (int i = 0; i < iRows; i++) {
            int i2 = i * 2;
            list.add(new Mat((((long) iArr[i2]) << 32) | (((long) iArr[i2 + 1]) & 4294967295L)));
        }
    }

    public static Mat vector_vector_Point_to_Mat(List list, List list2) {
        if ((list != null ? list.size() : 0) > 0) {
            list2.addAll(list);
            return vector_Mat_to_Mat(list2);
        }
        return new Mat();
    }

    public static void Mat_to_vector_vector_Point(Mat mat, List list) {
        if (list == null) {
            throw new IllegalArgumentException("Output List can't be null");
        }
        if (mat == null) {
            throw new IllegalArgumentException("Input Mat can't be null");
        }
        ArrayList arrayList = new ArrayList(mat.rows());
        Mat_to_vector_Mat(mat, arrayList);
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            Mat mat2 = (Mat) obj;
            list.add(new MatOfPoint(mat2));
            mat2.release();
        }
        arrayList.clear();
    }
}
