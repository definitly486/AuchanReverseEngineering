package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilVector2D_F64 {
    /* JADX WARN: Code duplicated, block: B:4:0x0014 A[PHI: r4
      0x0014: PHI (r4v5 double) = (r4v2 double), (r4v3 double) binds: [B:3:0x0012, B:6:0x001a] A[DONT_GENERATE, DONT_INLINE]] */
    public static double acute(Vector2D_F64 vector2D_F64, Vector2D_F64 vector2D_F65) {
        double dDot = vector2D_F64.dot(vector2D_F65) / (vector2D_F64.norm() * vector2D_F65.norm());
        double d = 1.0d;
        if (dDot > 1.0d) {
            dDot = d;
        } else {
            d = -1.0d;
            if (dDot < -1.0d) {
                dDot = d;
            }
        }
        return Math.acos(dDot);
    }
}
