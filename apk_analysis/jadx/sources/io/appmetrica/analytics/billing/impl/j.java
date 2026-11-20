package io.appmetrica.analytics.billing.impl;

import io.appmetrica.analytics.billing.impl.j;
import io.appmetrica.analytics.billinginterface.internal.ProductInfo;
import io.appmetrica.analytics.billinginterface.internal.storage.BillingInfoSender;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleReporter;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleCounterReport;
import java.util.List;
import java.util.concurrent.Executor;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class j implements BillingInfoSender {
    public final ServiceComponentModuleReporter a;
    public final Executor b;
    public final o c;

    public j(ServiceComponentModuleReporter serviceComponentModuleReporter, Executor executor, o oVar) {
        this.a = serviceComponentModuleReporter;
        this.b = executor;
        this.c = oVar;
    }

    public static final void a(j jVar, ProductInfo productInfo) {
        ServiceComponentModuleReporter serviceComponentModuleReporter = jVar.a;
        ServiceModuleCounterReport.Builder builderWithType = ServiceModuleCounterReport.Companion.newBuilder().withType(40976);
        jVar.c.getClass();
        serviceComponentModuleReporter.handleReport(builderWithType.withValueBytes(o.a(productInfo)).build());
    }

    @Override // io.appmetrica.analytics.billinginterface.internal.storage.BillingInfoSender
    public final void sendInfo(List<? extends ProductInfo> list) {
        for (final ProductInfo productInfo : list) {
            this.b.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.billing.impl.j$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    j.a(this.f$0, productInfo);
                }
            });
        }
    }

    public /* synthetic */ j(ServiceComponentModuleReporter serviceComponentModuleReporter, Executor executor, o oVar, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(serviceComponentModuleReporter, executor, (i & 4) != 0 ? new o() : oVar);
    }
}
