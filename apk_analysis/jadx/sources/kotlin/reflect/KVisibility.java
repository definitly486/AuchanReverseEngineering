package kotlin.reflect;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: compiled from: KVisibility.kt */
/* JADX INFO: loaded from: classes3.dex */
public enum KVisibility {
    PUBLIC,
    PROTECTED,
    INTERNAL,
    PRIVATE;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<KVisibility> getEntries() {
        return $ENTRIES;
    }
}
