package com.scanflow.datacapture.config;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: loaded from: classes3.dex */
public enum TextCaptureConfig {
    TYRE_NUMBER,
    TYRE_DOT,
    CONTAINER_VERTICAL,
    CONTAINER_HORIZONTAL,
    HANDWRITTEN_DIGIT,
    GENERIC_TEXT;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<TextCaptureConfig> getEntries() {
        return $ENTRIES;
    }
}
