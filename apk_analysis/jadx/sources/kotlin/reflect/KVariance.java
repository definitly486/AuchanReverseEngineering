package kotlin.reflect;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: compiled from: KVariance.kt */
/* JADX INFO: loaded from: classes3.dex */
public enum KVariance {
    INVARIANT,
    IN,
    OUT;

    private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

    public static EnumEntries<KVariance> getEntries() {
        return $ENTRIES;
    }
}
