package com.scanflow.datacapture.config;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: loaded from: classes3.dex */
public enum SwitchCategory {
    DASHBOARD,
    DUP,
    GRID,
    TWO,
    TOP;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<SwitchCategory> getEntries() {
        return $ENTRIES;
    }
}
