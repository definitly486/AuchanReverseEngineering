package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 com.scanflow.datacapture.barinternal.y[], still in use, count: 1, list:
  (r0v1 com.scanflow.datacapture.barinternal.y[]) from 0x0038: INVOKE (r0v1 com.scanflow.datacapture.barinternal.y[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m)]
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
public final class y {
    INITIAL,
    /* JADX INFO: Fake field, exist only in values array */
    SUCCESS,
    /* JADX INFO: Fake field, exist only in values array */
    LONG_DISTANCE,
    /* JADX INFO: Fake field, exist only in values array */
    TILT,
    /* JADX INFO: Fake field, exist only in values array */
    DAMAGED,
    /* JADX INFO: Fake field, exist only in values array */
    FAILED;

    static {
        EnumEntriesKt.enumEntries(yVarArr);
    }

    public y() {
        super(str, i);
    }

    public static y valueOf(String str) {
        return (y) Enum.valueOf(y.class, str);
    }

    public static y[] values() {
        return (y[]) b.clone();
    }
}
