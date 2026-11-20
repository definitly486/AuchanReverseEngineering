package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentsInitializer;
import io.appmetrica.analytics.coreutils.internal.reflection.ReflectionUtils;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Ba {
    public static final Ba d = new Ba();
    public final Md a = new Md();
    public final ServiceComponentsInitializer b = AbstractC0600sk.a();
    public boolean c = false;

    public final void a(Context context) {
        C0671vd c0671vd;
        Ka.a(context);
        this.b.onCreate(context);
        this.a.getClass();
        List<String> listA = Ka.I.s.a();
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(listA, 10));
        for (String str : listA) {
            Object objLoadAndInstantiateClassWithDefaultConstructor = ReflectionUtils.loadAndInstantiateClassWithDefaultConstructor(str, ModuleServiceEntryPoint.class);
            if (objLoadAndInstantiateClassWithDefaultConstructor == null) {
                c0671vd = new C0671vd(str, false);
            } else {
                Ka.I.p().a((ModuleServiceEntryPoint<Object>) objLoadAndInstantiateClassWithDefaultConstructor);
                c0671vd = new C0671vd(str, true);
            }
            arrayList.add(c0671vd);
        }
        new Ek(Ka.I.D().d).a(context);
        Oo oo = Ka.I.D().c;
        synchronized (oo) {
            oo.a.a();
        }
        Ka.I.q().a();
        new C0697wd(Ka.I.d.b(), Ka.I.y(), "service_modules", new SystemTimeProvider()).a(arrayList);
    }

    public final void b(Context context) {
        if (this.c) {
            return;
        }
        synchronized (this) {
            try {
                if (!this.c) {
                    a(context);
                    this.c = true;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
