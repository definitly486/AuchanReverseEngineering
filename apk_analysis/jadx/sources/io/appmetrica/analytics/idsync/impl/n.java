package io.appmetrica.analytics.idsync.impl;

import android.text.TextUtils;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreapi.internal.identifiers.SdkIdentifiers;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.idsync.impl.n;
import io.appmetrica.analytics.idsync.internal.model.Preconditions;
import io.appmetrica.analytics.idsync.internal.model.RequestConfig;
import io.appmetrica.analytics.modulesapi.internal.service.ServiceContext;
import io.appmetrica.analytics.network.internal.NetworkClientBuilder;
import io.appmetrica.analytics.networkapi.NetworkClientSettings;
import io.appmetrica.analytics.networkapi.Request;
import io.appmetrica.analytics.networkapi.Response;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import org.json.JSONException;

/* JADX INFO: loaded from: classes3.dex */
public final class n {
    public final ServiceContext a;
    public final G b;
    public SdkIdentifiers c;
    public final SystemTimeProvider d = new SystemTimeProvider();
    public final o e;
    public final x f;
    public final q g;

    public n(ServiceContext serviceContext, G g, SdkIdentifiers sdkIdentifiers) {
        this.a = serviceContext;
        this.b = g;
        this.c = sdkIdentifiers;
        this.e = new o(serviceContext.getNetworkContext().getSslSocketFactoryProvider(), this);
        this.f = new x(serviceContext);
        this.g = new q(serviceContext);
    }

    public static final void a(D d, n nVar, RequestConfig requestConfig) throws JSONException {
        if (d.b) {
            G g = nVar.b;
            String str = d.a;
            g.d.put(str, new E(str, nVar.d.currentTimeMillis(), d.d ? A.SUCCESS : A.FAILURE));
            g.a.putString(g.c, g.b.fromModel(CollectionsKt.toList(g.d.values())));
            q qVar = nVar.g;
            SdkIdentifiers sdkIdentifiers = nVar.c;
            qVar.a.getClass();
            String strA = v.a(d);
            t tVar = qVar.b;
            tVar.getClass();
            ArrayList arrayList = new ArrayList();
            if (requestConfig.getReportEventEnabled()) {
                arrayList.add(new p(tVar.a));
            }
            String reportUrl = requestConfig.getReportUrl();
            if (reportUrl != null && !StringsKt.isBlank(reportUrl)) {
                arrayList.add(new r(tVar.a, requestConfig.getReportUrl()));
            }
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                ((s) obj).a(strA, sdkIdentifiers);
            }
        }
    }

    public final SdkIdentifiers a() {
        return this.c;
    }

    public final void a(SdkIdentifiers sdkIdentifiers) {
        this.c = sdkIdentifiers;
    }

    public static final void a(n nVar, RequestConfig requestConfig) {
        y c0106a;
        x xVar = nVar.f;
        Preconditions preconditions = requestConfig.getPreconditions();
        xVar.getClass();
        if (w.a[preconditions.getNetworkType().ordinal()] == 1) {
            c0106a = new C0107b(xVar.a);
        } else {
            c0106a = new C0106a();
        }
        if (c0106a.a()) {
            o oVar = nVar.e;
            oVar.getClass();
            Request.Builder builder = new Request.Builder(requestConfig.getUrl());
            for (Map.Entry<String, List<String>> entry : requestConfig.getHeaders().entrySet()) {
                builder.addHeader(entry.getKey(), CollectionsKt.joinToString$default(entry.getValue(), ", ", null, null, 0, null, null, 62, null));
            }
            Response responseExecute = new NetworkClientBuilder().withSettings(new NetworkClientSettings.Builder().withSslSocketFactory(oVar.a.getSslSocketFactory()).withUseCaches(false).withInstanceFollowRedirects(true).withMaxResponseSize(102400).build()).build().newCall(builder.build()).execute();
            oVar.b.a(new D(requestConfig.getType(), responseExecute.isCompleted(), responseExecute.getUrl(), requestConfig.getValidResponseCodes().contains(Integer.valueOf(responseExecute.getCode())), responseExecute.getCode(), responseExecute.getResponseData(), responseExecute.getHeaders()), requestConfig);
        }
    }

    public final void a(final D d, final RequestConfig requestConfig) {
        this.a.getExecutorProvider().getModuleExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.idsync.impl.n$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() throws JSONException {
                n.a(d, this, requestConfig);
            }
        });
    }

    public final void a(final RequestConfig requestConfig) {
        long resendIntervalForValidResponse;
        if (TextUtils.isEmpty(requestConfig.getType()) || TextUtils.isEmpty(requestConfig.getUrl()) || requestConfig.getValidResponseCodes().isEmpty()) {
            return;
        }
        E e = (E) this.b.d.get(requestConfig.getType());
        if (e != null) {
            long jCurrentTimeMillis = this.d.currentTimeMillis();
            int iOrdinal = e.c.ordinal();
            if (iOrdinal != 1) {
                resendIntervalForValidResponse = iOrdinal != 3 ? 0L : requestConfig.getResendIntervalForInvalidResponse();
            } else {
                resendIntervalForValidResponse = requestConfig.getResendIntervalForValidResponse();
            }
            if (jCurrentTimeMillis - e.b < resendIntervalForValidResponse) {
                return;
            }
        }
        this.a.getExecutorProvider().getSupportIOExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.idsync.impl.n$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                n.a(this.f$0, requestConfig);
            }
        });
    }
}
