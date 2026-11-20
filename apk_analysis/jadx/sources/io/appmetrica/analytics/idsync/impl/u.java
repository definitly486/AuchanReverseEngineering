package io.appmetrica.analytics.idsync.impl;

import com.google.common.net.HttpHeaders;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.modulesapi.internal.service.ServiceContext;
import io.appmetrica.analytics.network.internal.NetworkClientBuilder;
import io.appmetrica.analytics.networkapi.NetworkClientSettings;
import io.appmetrica.analytics.networkapi.Request;
import io.appmetrica.analytics.networkapi.Response;

/* JADX INFO: loaded from: classes3.dex */
public final class u {
    public final ServiceContext a;

    public u(ServiceContext serviceContext) {
        this.a = serviceContext;
    }

    public final boolean a(String str, String str2) {
        int code;
        try {
            Response responseExecute = new NetworkClientBuilder().withSettings(new NetworkClientSettings.Builder().withSslSocketFactory(this.a.getNetworkContext().getSslSocketFactoryProvider().getSslSocketFactory()).withUseCaches(false).withInstanceFollowRedirects(true).withMaxResponseSize(10240).build()).build().newCall(new Request.Builder(str).withMethod(Request.Method.POST).withBody(str2.getBytes(Charsets.UTF_8)).addHeader(HttpHeaders.CONTENT_TYPE, "application/json").build()).execute();
            return responseExecute.isCompleted() && (responseExecute.getCode() == 200 || (400 <= (code = responseExecute.getCode()) && code < 500));
        } catch (Exception unused) {
        }
    }
}
