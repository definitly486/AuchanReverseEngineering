package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.impl.oe[], still in use, count: 1, list:
  (r0v1 io.appmetrica.analytics.impl.oe[]) from 0x002a: INVOKE (r0v1 io.appmetrica.analytics.impl.oe[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m)]
	at jadx.core.utils.InsnRemover.removeSsaVar(InsnRemover.java:164)
	at jadx.core.utils.InsnRemover.unbindResult(InsnRemover.java:129)
	at jadx.core.utils.InsnRemover.lambda$unbindInsns$1(InsnRemover.java:101)
	at java.base/java.util.ArrayList.forEach(ArrayList.java:1511)
	at jadx.core.utils.InsnRemover.unbindInsns(InsnRemover.java:100)
	at jadx.core.utils.InsnRemover.removeAllAndUnbind(InsnRemover.java:257)
	at jadx.core.dex.visitors.EnumVisitor.convertToEnum(EnumVisitor.java:187)
	at jadx.core.dex.visitors.EnumVisitor.visit(EnumVisitor.java:102)
 */
/* JADX WARN: Failed to restore enum class, 'enum' modifier and super class removed */
/* JADX INFO: renamed from: io.appmetrica.analytics.impl.oe, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class EnumC0490oe {
    REPORT,
    /* JADX INFO: Fake field, exist only in values array */
    LOCATION,
    STARTUP,
    /* JADX INFO: Fake field, exist only in values array */
    DIAGNOSTIC;

    static {
        EnumEntriesKt.enumEntries(enumC0490oeArr);
    }

    public EnumC0490oe() {
        super(str, i);
    }

    public static EnumC0490oe valueOf(String str) {
        return (EnumC0490oe) Enum.valueOf(EnumC0490oe.class, str);
    }

    public static EnumC0490oe[] values() {
        return (EnumC0490oe[]) c.clone();
    }
}
