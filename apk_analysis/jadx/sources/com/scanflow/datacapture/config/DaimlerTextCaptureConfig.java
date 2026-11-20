package com.scanflow.datacapture.config;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: loaded from: classes3.dex */
public enum DaimlerTextCaptureConfig {
    COMPONENT_LEAFSUSPENSION,
    COMPONENT_AIRTANK,
    COMPONENT_VINNUMBER,
    COMPONENT_VINPLATE,
    COMPONENT_VINSTICKER,
    UNIVERSAL;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<DaimlerTextCaptureConfig> getEntries() {
        return $ENTRIES;
    }
}
