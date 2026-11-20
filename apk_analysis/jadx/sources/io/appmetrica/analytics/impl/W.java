package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdTrackingInfoResult;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdvertisingIdsHolder;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.FutureTask;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class W implements Za {
    public final Context a;
    public final ICommonExecutor b;
    public FutureTask i;
    public final O l;
    public L n;
    public boolean o;
    public final String c = "advertising identifiers collecting is forbidden by client configuration";
    public final String d = "advertising identifiers collecting is forbidden by startup";
    public final String e = "advertising identifiers collecting is forbidden by unknown reason";
    public final K f = new K(new Hg("google"));
    public final K g = new K(new Hg("huawei"));
    public final K h = new K(new Hg("yandex"));
    public final Lazy j = LazyKt.lazy(new S(this));
    public final long k = 90;
    public volatile AdvertisingIdsHolder m = new AdvertisingIdsHolder();

    public W(Context context, ICommonExecutor iCommonExecutor, C0706wm c0706wm) {
        this.a = context;
        this.b = iCommonExecutor;
        this.l = new O(c0706wm);
        M m = M.UNKNOWN;
        this.n = new L(m, m, m);
    }

    public static final Void f(W w) {
        w.m = new AdvertisingIdsHolder(w.a(w.n.a, new T(w)), w.a(w.n.b, new U(w)), w.a(w.n.c, new V(w, new C0594se())));
        w.b.executeDelayed((FutureTask) w.j.getValue(), w.k, TimeUnit.SECONDS);
        return null;
    }

    public static final Void g(W w) {
        w.b();
        return null;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.identifiers.AdvertisingIdsProvider
    public final synchronized AdvertisingIdsHolder getIdentifiers() {
        FutureTask futureTask = this.i;
        if (futureTask == null) {
            Intrinsics.throwUninitializedPropertyAccessException("blockingRefreshTask");
            futureTask = null;
        }
        try {
            futureTask.get();
        } catch (InterruptedException | ExecutionException unused) {
        }
        return this.m;
    }

    @Override // io.appmetrica.analytics.impl.Za
    public final synchronized void init() {
        if (this.i == null) {
            this.n = this.l.a();
            FutureTask futureTask = new FutureTask(new Callable() { // from class: io.appmetrica.analytics.impl.W$$ExternalSyntheticLambda0
                @Override // java.util.concurrent.Callable
                public final Object call() {
                    return W.f(this.f$0);
                }
            });
            this.i = futureTask;
            this.b.execute(futureTask);
        }
    }

    @Override // io.appmetrica.analytics.impl.Za, io.appmetrica.analytics.impl.Bm
    public final synchronized void a(C0706wm c0706wm) {
        this.l.a(c0706wm);
        a();
    }

    @Override // io.appmetrica.analytics.impl.Za
    public final synchronized void b(boolean z) {
        this.o = true;
        this.l.b.update(z);
        a();
    }

    @Override // io.appmetrica.analytics.impl.Za
    public final synchronized void c(boolean z) {
        if (!this.o) {
            b(z);
        }
    }

    public final void a() {
        L lA = this.l.a();
        if (!Intrinsics.areEqual(lA, this.n)) {
            this.b.remove((FutureTask) this.j.getValue());
            this.n = lA;
            this.i = new FutureTask(new Callable() { // from class: io.appmetrica.analytics.impl.W$$ExternalSyntheticLambda1
                @Override // java.util.concurrent.Callable
                public final Object call() {
                    return W.g(this.f$0);
                }
            });
        }
        ICommonExecutor iCommonExecutor = this.b;
        FutureTask futureTask = this.i;
        if (futureTask == null) {
            Intrinsics.throwUninitializedPropertyAccessException("blockingRefreshTask");
            futureTask = null;
        }
        iCommonExecutor.execute(futureTask);
        if (this.i == null) {
            Intrinsics.throwUninitializedPropertyAccessException("blockingRefreshTask");
        }
    }

    public final void b() {
        AdTrackingInfoResult adTrackingInfoResultA = a(this.n.a, new T(this));
        AdTrackingInfoResult google = this.m.getGoogle();
        IdentifierStatus identifierStatus = adTrackingInfoResultA.mStatus;
        IdentifierStatus identifierStatus2 = IdentifierStatus.UNKNOWN;
        if (identifierStatus == identifierStatus2) {
            adTrackingInfoResultA = new AdTrackingInfoResult(google.mAdTrackingInfo, identifierStatus, adTrackingInfoResultA.mErrorExplanation);
        }
        AdTrackingInfoResult adTrackingInfoResultA2 = a(this.n.b, new U(this));
        AdTrackingInfoResult huawei = this.m.getHuawei();
        IdentifierStatus identifierStatus3 = adTrackingInfoResultA2.mStatus;
        if (identifierStatus3 == identifierStatus2) {
            adTrackingInfoResultA2 = new AdTrackingInfoResult(huawei.mAdTrackingInfo, identifierStatus3, adTrackingInfoResultA2.mErrorExplanation);
        }
        AdTrackingInfoResult adTrackingInfoResultA3 = a(this.n.c, new V(this, new C0164bo(3, 500)));
        AdTrackingInfoResult yandex = this.m.getYandex();
        IdentifierStatus identifierStatus4 = adTrackingInfoResultA3.mStatus;
        if (identifierStatus4 == identifierStatus2) {
            adTrackingInfoResultA3 = new AdTrackingInfoResult(yandex.mAdTrackingInfo, identifierStatus4, adTrackingInfoResultA3.mErrorExplanation);
        }
        this.m = new AdvertisingIdsHolder(adTrackingInfoResultA, adTrackingInfoResultA2, adTrackingInfoResultA3);
        this.b.executeDelayed((FutureTask) this.j.getValue(), this.k, TimeUnit.SECONDS);
    }

    public final AdTrackingInfoResult a(M m, Function0 function0) {
        int iOrdinal = m.ordinal();
        if (iOrdinal == 0) {
            return (AdTrackingInfoResult) function0.invoke();
        }
        if (iOrdinal == 1) {
            return new AdTrackingInfoResult(null, IdentifierStatus.FORBIDDEN_BY_CLIENT_CONFIG, this.c);
        }
        if (iOrdinal == 2) {
            return new AdTrackingInfoResult(null, IdentifierStatus.FEATURE_DISABLED, this.d);
        }
        if (iOrdinal != 3) {
            throw new NoWhenBranchMatchedException();
        }
        return new AdTrackingInfoResult(null, IdentifierStatus.UNKNOWN, this.e);
    }
}
