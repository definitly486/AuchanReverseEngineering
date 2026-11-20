package io.appmetrica.analytics.screenshot.impl;

import android.app.ActivityManager;
import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;
import io.appmetrica.analytics.screenshot.impl.a0;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a0 implements Runnable {
    public final /* synthetic */ d0 a;

    public a0(d0 d0Var) {
        this.a = d0Var;
    }

    public static final Boolean a(d0 d0Var, a0 a0Var, C0800n c0800n, ActivityManager activityManager) {
        Object next;
        List<ActivityManager.RunningServiceInfo> runningServices = activityManager.getRunningServices(200);
        if (runningServices == null) {
            runningServices = CollectionsKt.emptyList();
        }
        for (ActivityManager.RunningServiceInfo runningServiceInfo : runningServices) {
        }
        Iterator<T> it = runningServices.iterator();
        do {
            if (!it.hasNext()) {
                next = null;
                break;
            }
            next = it.next();
        } while (!Intrinsics.areEqual(((ActivityManager.RunningServiceInfo) next).process, "com.android.systemui:screenshot"));
        if (((ActivityManager.RunningServiceInfo) next) != null) {
            ((C0809x) d0Var.b).a("ServiceScreenshotCaptor");
        }
        return Boolean.valueOf(d0Var.c.postDelayed(a0Var, TimeUnit.SECONDS.toMillis(c0800n.b)));
    }

    @Override // java.lang.Runnable
    public final void run() {
        final C0800n c0800n = this.a.e;
        if (this.a.d || c0800n == null || !c0800n.a) {
            return;
        }
        Context context = this.a.a.getContext();
        final d0 d0Var = this.a;
        SystemServiceUtils.accessSystemServiceByNameSafely(context, "activity", "running service screenshot captor", "ActivityManager", new FunctionWithThrowable() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.screenshot.impl.a0$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable
            public final Object apply(Object obj) {
                return a0.a(d0Var, this, c0800n, (ActivityManager) obj);
            }
        });
    }
}
