package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barcode.config.DecodeConfig;

/* JADX INFO: loaded from: classes3.dex */
public abstract /* synthetic */ class z {
    public static final /* synthetic */ int[] a;

    static {
        int[] iArr = new int[y.values().length];
        try {
            iArr[0] = 1;
        } catch (NoSuchFieldError unused) {
        }
        try {
            y yVar = y.INITIAL;
            iArr[2] = 2;
        } catch (NoSuchFieldError unused2) {
        }
        try {
            y yVar2 = y.INITIAL;
            iArr[3] = 3;
        } catch (NoSuchFieldError unused3) {
        }
        try {
            y yVar3 = y.INITIAL;
            iArr[4] = 4;
        } catch (NoSuchFieldError unused4) {
        }
        int[] iArr2 = new int[DecodeConfig.values().length];
        try {
            iArr2[DecodeConfig.QRCODE.ordinal()] = 1;
        } catch (NoSuchFieldError unused5) {
        }
        try {
            iArr2[DecodeConfig.BARCODE.ordinal()] = 2;
        } catch (NoSuchFieldError unused6) {
        }
        try {
            iArr2[DecodeConfig.ANY.ordinal()] = 3;
        } catch (NoSuchFieldError unused7) {
        }
        try {
            iArr2[DecodeConfig.BATCH_INVENTORY.ordinal()] = 4;
        } catch (NoSuchFieldError unused8) {
        }
        try {
            iArr2[DecodeConfig.ONE_OF_MANY.ordinal()] = 5;
        } catch (NoSuchFieldError unused9) {
        }
        try {
            iArr2[DecodeConfig.PIVOT_VIEW.ordinal()] = 6;
        } catch (NoSuchFieldError unused10) {
        }
        try {
            iArr2[DecodeConfig.DOTMATRIX_WHITE.ordinal()] = 7;
        } catch (NoSuchFieldError unused11) {
        }
        try {
            iArr2[DecodeConfig.DOTMATRIX_METAL.ordinal()] = 8;
        } catch (NoSuchFieldError unused12) {
        }
        a = iArr2;
    }
}
