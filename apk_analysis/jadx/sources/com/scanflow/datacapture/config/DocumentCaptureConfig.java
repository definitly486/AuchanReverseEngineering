package com.scanflow.datacapture.config;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: loaded from: classes3.dex */
public enum DocumentCaptureConfig {
    CAPTURE_DOCUMENT,
    CAPTURED_DOCUMENT_LIST,
    CAPTURED_DOCUMENT_LIST_WITH_CAPTURE;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<DocumentCaptureConfig> getEntries() {
        return $ENTRIES;
    }
}
