package io.appmetrica.analytics.networkapi;

import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class Response {
    private final boolean a;
    private final int b;
    private final byte[] c;
    private final Map d;
    private final Throwable e;
    private final String f;
    private final NetworkCallMetrics g;

    public /* synthetic */ Response(boolean z, int i, byte[] bArr, Map map, Throwable th, String str, NetworkCallMetrics networkCallMetrics, DefaultConstructorMarker defaultConstructorMarker) {
        this(z, i, bArr, map, th, str, networkCallMetrics);
    }

    public final int getCode() {
        return this.b;
    }

    public final Throwable getException() {
        return this.e;
    }

    public final Map<String, List<String>> getHeaders() {
        return this.d;
    }

    public final NetworkCallMetrics getMetrics() {
        return this.g;
    }

    public final byte[] getResponseData() {
        return this.c;
    }

    public final String getUrl() {
        return this.f;
    }

    public final boolean isCompleted() {
        return this.a;
    }

    public String toString() {
        return "Response(isCompleted=" + this.a + ", code=" + this.b + ", responseDataLength=" + this.c.length + ", headers=" + this.d + ", exception=" + this.e + ", url=" + this.f + ", metrics=" + this.g + ')';
    }

    private Response(boolean z, int i, byte[] bArr, Map map, Throwable th, String str, NetworkCallMetrics networkCallMetrics) {
        this.a = z;
        this.b = i;
        this.c = bArr;
        this.d = map;
        this.e = th;
        this.f = str;
        this.g = networkCallMetrics;
    }

    public static final class Builder {
        private final boolean a;
        private final int b;
        private final byte[] c;
        private final Throwable d;
        private Map e;
        private String f;
        private NetworkCallMetrics g;

        private Builder(boolean z, int i, byte[] bArr, Throwable th) {
            this.a = z;
            this.b = i;
            this.c = bArr;
            this.d = th;
            this.e = MapsKt.emptyMap();
        }

        public final Response build() {
            return new Response(this.a, this.b, this.c, this.e, this.d, this.f, this.g, null);
        }

        public final Builder withHeaders(Map<String, ? extends List<String>> map) {
            this.e = MapsKt.toMap(map);
            return this;
        }

        public final Builder withMetrics(NetworkCallMetrics networkCallMetrics) {
            this.g = networkCallMetrics;
            return this;
        }

        public final Builder withUrl(String str) {
            this.f = str;
            return this;
        }

        public Builder(Throwable th) {
            this(false, 0, new byte[0], th);
        }

        public Builder(boolean z, int i, byte[] bArr) {
            this(z, i, bArr, null);
        }
    }
}
