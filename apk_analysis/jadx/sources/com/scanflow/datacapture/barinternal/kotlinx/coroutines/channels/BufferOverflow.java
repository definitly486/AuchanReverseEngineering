package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: compiled from: BufferOverflow.kt */
/* JADX INFO: loaded from: classes3.dex */
public enum BufferOverflow {
    SUSPEND,
    DROP_OLDEST,
    DROP_LATEST;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());
}
