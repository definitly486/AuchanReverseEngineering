package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.impl.ea[], still in use, count: 1, list:
  (r0v1 io.appmetrica.analytics.impl.ea[]) from 0x004a: INVOKE (r0v1 io.appmetrica.analytics.impl.ea[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m)]
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
/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ea, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class EnumC0227ea {
    /* JADX INFO: Fake field, exist only in values array */
    UNKNOWN,
    APPSFLYER,
    ADJUST,
    KOCHAVA,
    TENJIN,
    AIRBRIDGE,
    SINGULAR;

    static {
        EnumEntriesKt.enumEntries(enumC0227eaArr);
    }

    public EnumC0227ea() {
        super(str, i);
    }

    public static EnumC0227ea valueOf(String str) {
        return (EnumC0227ea) Enum.valueOf(EnumC0227ea.class, str);
    }

    public static EnumC0227ea[] values() {
        return (EnumC0227ea[]) g.clone();
    }
}
