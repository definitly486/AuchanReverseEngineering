package com.scanflow.datacapture.barinternal.org.ejml;

import com.google.android.gms.common.ConnectionResult;

/* JADX INFO: loaded from: classes3.dex */
public abstract class EjmlParameters {
    public static MemoryUsage MEMORY = MemoryUsage.FASTER;
    public static int BLOCK_WIDTH = 60;
    public static int BLOCK_WIDTH_CHOL = 20;
    public static int TRANSPOSE_SWITCH = 375;
    public static int MULT_COLUMN_SWITCH = 15;
    public static int MULT_TRANAB_COLUMN_SWITCH = 40;
    public static int MULT_INNER_SWITCH = 100;
    public static int CMULT_COLUMN_SWITCH = 7;
    public static int CMULT_TRANAB_COLUMN_SWITCH = 20;
    public static int SWITCH_BLOCK64_CHOLESKY = 1000;
    public static int SWITCH_BLOCK64_QR = ConnectionResult.DRIVE_EXTERNAL_STORAGE_REQUIRED;

    public enum MemoryUsage {
        LOW_MEMORY,
        FASTER
    }
}
