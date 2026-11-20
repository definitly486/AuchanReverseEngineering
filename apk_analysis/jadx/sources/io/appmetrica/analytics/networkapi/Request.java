package io.appmetrica.analytics.networkapi;

import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import java.util.LinkedHashMap;
import java.util.Map;
import kotlin.enums.EnumEntries;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class Request {
    private final String a;
    private final Method b;
    private final byte[] c;
    private final Map d;

    public static final class Builder {
        private final String a;
        private Method b = Method.GET;
        private byte[] c = new byte[0];
        private final LinkedHashMap d = new LinkedHashMap();

        public Builder(String str) {
            this.a = str;
        }

        public final Builder addHeader(String str, String str2) {
            this.d.put(str, str2);
            return this;
        }

        public final Request build() {
            return new Request(this.a, this.b, this.c, MapsKt.toMap(this.d), null);
        }

        public final Builder withBody(byte[] bArr) {
            this.c = bArr;
            return this;
        }

        public final Builder withMethod(Method method) {
            this.b = method;
            return this;
        }
    }

    /* JADX WARN: Enum visitor error
    jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v1 io.appmetrica.analytics.networkapi.Request$Method[], still in use, count: 1, list:
      (r0v1 io.appmetrica.analytics.networkapi.Request$Method[]) from 0x004c: INVOKE (r0v1 io.appmetrica.analytics.networkapi.Request$Method[]) STATIC call: com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt.enumEntries(java.lang.Enum[]):kotlin.enums.EnumEntries A[MD:(java.lang.Enum[]):kotlin.enums.EnumEntries (m), WRAPPED]
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
    public static final class Method {
        GET("GET"),
        POST("POST"),
        HEAD("HEAD"),
        PUT("PUT"),
        DELETE("DELETE"),
        PATCH("PATCH"),
        OPTIONS("OPTIONS");

        private static final /* synthetic */ EnumEntries c;
        private final String a;

        static {
            c = EnumEntriesKt.enumEntries(methodArr);
        }

        private Method(String str) {
            super(str, i);
            this.a = str;
        }

        public static EnumEntries<Method> getEntries() {
            return c;
        }

        public static Method valueOf(String str) {
            return (Method) Enum.valueOf(Method.class, str);
        }

        public static Method[] values() {
            return (Method[]) b.clone();
        }

        public final String getMethodName() {
            return this.a;
        }
    }

    public /* synthetic */ Request(String str, Method method, byte[] bArr, Map map, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, method, bArr, map);
    }

    public final byte[] getBody() {
        return this.c;
    }

    public final Map<String, String> getHeaders() {
        return this.d;
    }

    public final Method getMethod() {
        return this.b;
    }

    public final String getUrl() {
        return this.a;
    }

    public String toString() {
        return "Request(url='" + this.a + "', method='" + this.b + "', bodyLength=" + this.c.length + ", headers=" + this.d + ')';
    }

    private Request(String str, Method method, byte[] bArr, Map map) {
        this.a = str;
        this.b = method;
        this.c = bArr;
        this.d = map;
    }
}
