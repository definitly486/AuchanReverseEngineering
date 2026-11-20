package io.appmetrica.analytics.idsync.internal.model;

import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class RequestConfig {
    private final String a;
    private final String b;
    private final Preconditions c;
    private final Map d;
    private final long e;
    private final long f;
    private final List g;
    private final boolean h;
    private final String i;

    public RequestConfig(String str, String str2, Preconditions preconditions, Map<String, ? extends List<String>> map, long j, long j2, List<Integer> list, boolean z, String str3) {
        this.a = str;
        this.b = str2;
        this.c = preconditions;
        this.d = map;
        this.e = j;
        this.f = j2;
        this.g = list;
        this.h = z;
        this.i = str3;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(RequestConfig.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.idsync.internal.model.RequestConfig");
        RequestConfig requestConfig = (RequestConfig) obj;
        return this.e == requestConfig.e && this.f == requestConfig.f && Intrinsics.areEqual(this.a, requestConfig.a) && Intrinsics.areEqual(this.b, requestConfig.b) && Intrinsics.areEqual(this.c, requestConfig.c) && Intrinsics.areEqual(this.d, requestConfig.d) && Intrinsics.areEqual(this.g, requestConfig.g) && this.h == requestConfig.h && Intrinsics.areEqual(this.i, requestConfig.i);
    }

    public final Map<String, List<String>> getHeaders() {
        return this.d;
    }

    public final Preconditions getPreconditions() {
        return this.c;
    }

    public final boolean getReportEventEnabled() {
        return this.h;
    }

    public final String getReportUrl() {
        return this.i;
    }

    public final long getResendIntervalForInvalidResponse() {
        return this.f;
    }

    public final long getResendIntervalForValidResponse() {
        return this.e;
    }

    public final String getType() {
        return this.a;
    }

    public final String getUrl() {
        return this.b;
    }

    public final List<Integer> getValidResponseCodes() {
        return this.g;
    }

    public int hashCode() {
        int iHashCode = (Boolean.hashCode(this.h) + ((this.g.hashCode() + ((this.d.hashCode() + ((this.c.hashCode() + ((this.b.hashCode() + ((this.a.hashCode() + ((Long.hashCode(this.f) + (Long.hashCode(this.e) * 31)) * 31)) * 31)) * 31)) * 31)) * 31)) * 31)) * 31;
        String str = this.i;
        return iHashCode + (str != null ? str.hashCode() : 0);
    }

    public String toString() {
        return "RequestConfig(type='" + this.a + "', url='" + this.b + "', preconditions=" + this.c + ", headers=" + this.d + ", resendIntervalForValidResponse=" + this.e + ", resendIntervalForInvalidResponse=" + this.f + ", validResponseCodes=" + this.g + ", reportEventEnabled=" + this.h + ", reportUrl=" + this.i + ')';
    }
}
