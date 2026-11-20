package io.appmetrica.analytics.coreapi.internal.identifiers;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.coreapi.internal.identifiers.AppSetIdScope[], still in use, count: 1, list:
  (r0v1 io.appmetrica.analytics.coreapi.internal.identifiers.AppSetIdScope[]) from 0x002a: INVOKE (r0v1 io.appmetrica.analytics.coreapi.internal.identifiers.AppSetIdScope[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m), WRAPPED]
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
public final class AppSetIdScope {
    UNKNOWN(""),
    APP("app"),
    DEVELOPER("developer");

    private static final /* synthetic */ EnumEntries c;
    private final String a;

    static {
        c = EnumEntriesKt.enumEntries(appSetIdScopeArr);
    }

    private AppSetIdScope(String str) {
        super(str, i);
        this.a = str;
    }

    public static EnumEntries<AppSetIdScope> getEntries() {
        return c;
    }

    public static AppSetIdScope valueOf(String str) {
        return (AppSetIdScope) Enum.valueOf(AppSetIdScope.class, str);
    }

    public static AppSetIdScope[] values() {
        return (AppSetIdScope[]) b.clone();
    }

    public final String getValue() {
        return this.a;
    }
}
