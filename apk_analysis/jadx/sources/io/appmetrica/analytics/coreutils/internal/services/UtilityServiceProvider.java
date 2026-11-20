package io.appmetrica.analytics.coreutils.internal.services;

import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import io.appmetrica.analytics.coreutils.impl.l;

/* JADX INFO: loaded from: classes3.dex */
public final class UtilityServiceProvider {
    private final Lazy a = LazyKt.lazy(new l(this));
    private final WaitForActivationDelayBarrier b = new WaitForActivationDelayBarrier();

    public final WaitForActivationDelayBarrier getActivationBarrier() {
        return this.b;
    }

    public final FirstExecutionConditionServiceImpl getFirstExecutionService() {
        return (FirstExecutionConditionServiceImpl) this.a.getValue();
    }

    public final void initAsync() {
        this.b.activate();
    }

    public final void updateConfiguration(UtilityServiceConfiguration utilityServiceConfiguration) {
        getFirstExecutionService().updateConfig(utilityServiceConfiguration);
    }
}
