package io.appmetrica.analytics.networkokhttp.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.IntIterator;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreutils.internal.io.InputStreamUtils;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.networkapi.Call;
import io.appmetrica.analytics.networkapi.NetworkCallMetrics;
import io.appmetrica.analytics.networkapi.NetworkClientSettings;
import io.appmetrica.analytics.networkapi.Request;
import io.appmetrica.analytics.networkapi.Response;
import io.appmetrica.analytics.networkokhttp.impl.c;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.EventListener;
import okhttp3.Headers;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.RequestBody;

/* JADX INFO: loaded from: classes3.dex */
public final class c extends Call {
    public final OkHttpClient a;
    public final Request b;
    public final NetworkClientSettings c;

    public c(OkHttpClient okHttpClient, Request request, NetworkClientSettings networkClientSettings) {
        this.a = okHttpClient;
        this.b = request;
        this.c = networkClientSettings;
    }

    public static final EventListener a(d dVar, okhttp3.Call call) {
        return dVar;
    }

    @Override // io.appmetrica.analytics.networkapi.Call
    public final Response execute() {
        NetworkCallMetrics networkCallMetricsBuild;
        NetworkCallMetrics networkCallMetricsBuild2 = null;
        final d dVar = Intrinsics.areEqual(this.c.getCollectMetrics(), Boolean.TRUE) ? new d(new SystemTimeProvider()) : null;
        try {
            okhttp3.Response responseExecute = (dVar != null ? this.a.newBuilder().eventListenerFactory(new EventListener.Factory() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.networkokhttp.impl.c$$ExternalSyntheticLambda0
                @Override // okhttp3.EventListener.Factory
                public final EventListener create(okhttp3.Call call) {
                    return c.a(dVar, call);
                }
            }).build() : this.a).newCall(a(this.b)).execute();
            Response.Builder builderWithUrl = new Response.Builder(true, responseExecute.code(), InputStreamUtils.INSTANCE.readSafelyApprox(this.c.getMaxResponseSize(), new b(responseExecute))).withHeaders(a(responseExecute.headers())).withUrl(responseExecute.request().url().toString());
            if (dVar != null) {
                Long lA = d.a(dVar.b, dVar.c);
                Long lA2 = d.a(dVar.d, dVar.e);
                networkCallMetricsBuild = new NetworkCallMetrics.Builder().withDnsLookup(lA).withTcpConnect(lA2).withTlsHandshake(d.a(dVar.f, dVar.g)).withTimeToFirstByte(d.a(dVar.h, dVar.i)).withResponse(d.a(dVar.i, dVar.j)).withConnectionReused(dVar.l).withProtocol(dVar.k).build();
            } else {
                networkCallMetricsBuild = null;
            }
            return builderWithUrl.withMetrics(networkCallMetricsBuild).build();
        } catch (Throwable th) {
            Response.Builder builder = new Response.Builder(th);
            if (dVar != null) {
                Long lA3 = d.a(dVar.b, dVar.c);
                Long lA4 = d.a(dVar.d, dVar.e);
                networkCallMetricsBuild2 = new NetworkCallMetrics.Builder().withDnsLookup(lA3).withTcpConnect(lA4).withTlsHandshake(d.a(dVar.f, dVar.g)).withTimeToFirstByte(d.a(dVar.h, dVar.i)).withResponse(d.a(dVar.i, dVar.j)).withConnectionReused(dVar.l).withProtocol(dVar.k).build();
            }
            return builder.withMetrics(networkCallMetricsBuild2).build();
        }
    }

    public static LinkedHashMap a(Headers headers) {
        IntRange intRangeUntil = RangesKt.until(0, headers.size());
        LinkedHashMap linkedHashMap = new LinkedHashMap();
        Iterator it = intRangeUntil.iterator();
        while (it.hasNext()) {
            int iNextInt = ((IntIterator) it).nextInt();
            String strName = headers.name(iNextInt);
            Object arrayList = linkedHashMap.get(strName);
            if (arrayList == null) {
                arrayList = new ArrayList();
                linkedHashMap.put(strName, arrayList);
            }
            ((List) arrayList).add(headers.value(iNextInt));
        }
        return linkedHashMap;
    }

    public static okhttp3.Request a(Request request) {
        okhttp3.Request.Builder builderUrl = new okhttp3.Request.Builder().url(request.getUrl());
        switch (a.a[request.getMethod().ordinal()]) {
            case 1:
                builderUrl.get();
                break;
            case 2:
                builderUrl.head();
                break;
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                builderUrl.method(request.getMethod().getMethodName(), RequestBody.Companion.create$default(RequestBody.Companion, request.getBody(), (MediaType) null, 0, 0, 7, (Object) null));
                break;
        }
        for (Map.Entry<String, String> entry : request.getHeaders().entrySet()) {
            builderUrl.addHeader(entry.getKey(), entry.getValue());
        }
        return builderUrl.build();
    }
}
