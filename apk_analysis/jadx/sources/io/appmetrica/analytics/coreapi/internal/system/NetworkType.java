package io.appmetrica.analytics.coreapi.internal.system;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.coreapi.internal.system.NetworkType[], still in use, count: 1, list:
  (r0v1 io.appmetrica.analytics.coreapi.internal.system.NetworkType[]) from 0x0098: INVOKE (r0v1 io.appmetrica.analytics.coreapi.internal.system.NetworkType[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m), WRAPPED]
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
public final class NetworkType {
    WIFI,
    CELL,
    ETHERNET,
    BLUETOOTH,
    VPN,
    LOWPAN,
    WIFI_AWARE,
    MOBILE_DUN,
    MOBILE_HIPRI,
    MOBILE_MMS,
    MOBILE_SUPL,
    WIMAX,
    OFFLINE,
    UNDEFINED;

    private static final /* synthetic */ EnumEntries b;

    static {
        b = EnumEntriesKt.enumEntries(networkTypeArr);
    }

    private NetworkType() {
        super(str, i);
    }

    public static EnumEntries<NetworkType> getEntries() {
        return b;
    }

    public static NetworkType valueOf(String str) {
        return (NetworkType) Enum.valueOf(NetworkType.class, str);
    }

    public static NetworkType[] values() {
        return (NetworkType[]) a.clone();
    }
}
