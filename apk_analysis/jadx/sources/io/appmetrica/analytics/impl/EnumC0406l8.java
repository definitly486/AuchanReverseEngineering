package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.impl.l8[], still in use, count: 1, list:
  (r0v1 io.appmetrica.analytics.impl.l8[]) from 0x002e: INVOKE (r0v1 io.appmetrica.analytics.impl.l8[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m)]
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
/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class EnumC0406l8 {
    c("UNDEFINED"),
    d("APP"),
    e("SATELLITE"),
    f("RETAIL");

    public static final C0380k8 b;
    public final String a;

    static {
        EnumEntriesKt.enumEntries(enumC0406l8Arr);
        b = new C0380k8();
    }

    public EnumC0406l8(String str) {
        super(str, i);
        this.a = str;
    }

    public static EnumC0406l8 valueOf(String str) {
        return (EnumC0406l8) Enum.valueOf(EnumC0406l8.class, str);
    }

    public static EnumC0406l8[] values() {
        return (EnumC0406l8[]) g.clone();
    }
}
