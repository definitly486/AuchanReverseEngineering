package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 com.scanflow.datacapture.barinternal.D[], still in use, count: 1, list:
  (r0v1 com.scanflow.datacapture.barinternal.D[]) from 0x003c: INVOKE (r0v1 com.scanflow.datacapture.barinternal.D[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m)]
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
/* JADX INFO: loaded from: classes3.dex */
public final class D {
    INITIAL,
    /* JADX INFO: Fake field, exist only in values array */
    SUCCESS,
    LONG_DISTANCE,
    TILT,
    /* JADX INFO: Fake field, exist only in values array */
    DAMAGED,
    /* JADX INFO: Fake field, exist only in values array */
    FAILED;

    static {
        EnumEntriesKt.enumEntries(dArr);
    }

    public D() {
        super(str, i);
    }

    public static D valueOf(String str) {
        return (D) Enum.valueOf(D.class, str);
    }

    public static D[] values() {
        return (D[]) d.clone();
    }
}
