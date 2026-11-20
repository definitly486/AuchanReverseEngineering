package io.appmetrica.analytics.coreutils.internal.services;

import androidx.core.location.LocationRequestCompat;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.FirstExecutionConditionService;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.FirstExecutionDelayedTask;
import java.util.ArrayList;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes3.dex */
public class FirstExecutionConditionServiceImpl implements FirstExecutionConditionService {
    private final ArrayList a = new ArrayList();
    private UtilityServiceConfiguration b;
    final UtilityServiceProvider c;

    public static class FirstExecutionConditionChecker {
        private boolean a = false;
        private long b;
        private long c;
        private long d;
        private final FirstExecutionDelayChecker e;
        public final String tag;

        public FirstExecutionConditionChecker(UtilityServiceConfiguration utilityServiceConfiguration, FirstExecutionDelayChecker firstExecutionDelayChecker, String str) {
            this.e = firstExecutionDelayChecker;
            this.c = utilityServiceConfiguration == null ? 0L : utilityServiceConfiguration.getInitialConfigTime();
            this.b = utilityServiceConfiguration != null ? utilityServiceConfiguration.getLastUpdateConfigTime() : 0L;
            this.d = LocationRequestCompat.PASSIVE_INTERVAL;
            this.tag = str;
        }

        final void a(long j) {
            this.d = TimeUnit.SECONDS.toMillis(j);
        }

        final boolean b() {
            if (this.a) {
                return true;
            }
            return this.e.delaySinceFirstStartupWasPassed(this.c, this.b, this.d);
        }

        final void a() {
            this.a = true;
        }

        final void a(UtilityServiceConfiguration utilityServiceConfiguration) {
            this.c = utilityServiceConfiguration.getInitialConfigTime();
            this.b = utilityServiceConfiguration.getLastUpdateConfigTime();
        }
    }

    public static class FirstExecutionDelayChecker {
        public boolean delaySinceFirstStartupWasPassed(long j, long j2, long j3) {
            return j2 - j >= j3;
        }
    }

    public static class FirstExecutionHandler implements FirstExecutionDelayedTask {
        private final FirstExecutionConditionChecker a;
        private final WaitForActivationDelayBarrier.ActivationBarrierHelper b;
        private final ICommonExecutor c;

        /* synthetic */ FirstExecutionHandler(ICommonExecutor iCommonExecutor, WaitForActivationDelayBarrier.ActivationBarrierHelper activationBarrierHelper, FirstExecutionConditionChecker firstExecutionConditionChecker, int i) {
            this(iCommonExecutor, activationBarrierHelper, firstExecutionConditionChecker);
        }

        public boolean canExecute() {
            boolean zB = this.a.b();
            if (zB) {
                this.a.a();
            }
            return zB;
        }

        @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.FirstExecutionDelayedTask
        public void setInitialDelaySeconds(long j) {
            this.a.a(j);
        }

        @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.FirstExecutionDelayedTask
        public boolean tryExecute(long j) {
            if (!this.a.b()) {
                return false;
            }
            this.b.subscribeIfNeeded(TimeUnit.SECONDS.toMillis(j), this.c);
            this.a.a();
            return true;
        }

        public void updateConfig(UtilityServiceConfiguration utilityServiceConfiguration) {
            this.a.a(utilityServiceConfiguration);
        }

        private FirstExecutionHandler(ICommonExecutor iCommonExecutor, WaitForActivationDelayBarrier.ActivationBarrierHelper activationBarrierHelper, FirstExecutionConditionChecker firstExecutionConditionChecker) {
            this.b = activationBarrierHelper;
            this.a = firstExecutionConditionChecker;
            this.c = iCommonExecutor;
        }
    }

    public FirstExecutionConditionServiceImpl(UtilityServiceProvider utilityServiceProvider) {
        this.c = utilityServiceProvider;
    }

    final synchronized FirstExecutionHandler a(ICommonExecutor iCommonExecutor, WaitForActivationDelayBarrier.ActivationBarrierHelper activationBarrierHelper, FirstExecutionConditionChecker firstExecutionConditionChecker) {
        FirstExecutionHandler firstExecutionHandler;
        firstExecutionHandler = new FirstExecutionHandler(iCommonExecutor, activationBarrierHelper, firstExecutionConditionChecker, 0);
        this.a.add(firstExecutionHandler);
        return firstExecutionHandler;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.FirstExecutionConditionService
    public synchronized FirstExecutionDelayedTask createDelayedTask(String str, ICommonExecutor iCommonExecutor, Runnable runnable) {
        return a(iCommonExecutor, new WaitForActivationDelayBarrier.ActivationBarrierHelper(runnable, this.c.getActivationBarrier()), new FirstExecutionConditionChecker(this.b, new FirstExecutionDelayChecker(), str));
    }

    public void updateConfig(UtilityServiceConfiguration utilityServiceConfiguration) {
        ArrayList arrayList;
        synchronized (this) {
            this.b = utilityServiceConfiguration;
            arrayList = new ArrayList(this.a);
        }
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((FirstExecutionHandler) obj).updateConfig(utilityServiceConfiguration);
        }
    }
}
