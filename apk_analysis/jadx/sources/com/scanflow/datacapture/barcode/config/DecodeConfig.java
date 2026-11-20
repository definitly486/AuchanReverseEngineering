package com.scanflow.datacapture.barcode.config;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: loaded from: classes3.dex */
public enum DecodeConfig {
    QRCODE,
    BARCODE,
    ANY,
    BATCH_INVENTORY,
    ONE_OF_MANY,
    PIVOT_VIEW,
    DOTMATRIX_WHITE,
    DOTMATRIX_METAL;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<DecodeConfig> getEntries() {
        return $ENTRIES;
    }
}
