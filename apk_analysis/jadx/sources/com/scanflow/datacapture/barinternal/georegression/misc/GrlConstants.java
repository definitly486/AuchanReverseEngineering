package com.scanflow.datacapture.barinternal.georegression.misc;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;

/* JADX INFO: loaded from: classes3.dex */
public abstract class GrlConstants {
    public static float F_PI = 3.1415927f;
    public static double PI2 = 6.283185307179586d;
    public static double TEST_SQ_F64 = Math.sqrt(1.0E-8d);
    public static float TEST_F32 = 1.0E-4f;
    public static float TEST_SQ_F32 = (float) Math.sqrt(TEST_F32);
    public static float FCONV_TOL_A = 1.0E-5f;
    public static double DCONV_TOL_A = 1.0E-10d;
    public static float FCONV_TOL_B = 1.0E-6f;
    public static double DCONV_TOL_B = 1.0E-12d;
    public static float F_EPS = (float) Math.pow(2.0d, -21.0d);
    public static double EPS = UtilEjml.EPS;
}
