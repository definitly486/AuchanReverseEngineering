package io.appmetrica.analytics.impl;

import android.os.Bundle;
import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.coreapi.internal.identifiers.SdkIdentifiers;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint;
import io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigExtensionConfiguration;
import io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigUpdateListener;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueCollector;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessor;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CopyOnWriteArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.p4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0506p4 {
    public X5 c;
    public final C0480o4 a = new C0480o4();
    public final CopyOnWriteArrayList b = new CopyOnWriteArrayList();
    public final CopyOnWriteArrayList d = new CopyOnWriteArrayList();

    public static void a(String str, String str2, Throwable th) {
        C0263fk c0263fk = Dj.a;
        Map mapMapOf = MapsKt.mapOf(TuplesKt.to(str, MapsKt.mapOf(TuplesKt.to(str2, ExceptionsKt.stackTraceToString(th)))));
        c0263fk.getClass();
        c0263fk.a(new C0237ek("client_module_errors", mapMapOf));
    }

    public final ModuleAdRevenueProcessor b() {
        C0120a6 c0120a6;
        X5 x5 = this.c;
        if (x5 == null || (c0120a6 = ((C0144b4) x5).b) == null) {
            return null;
        }
        return c0120a6.a;
    }

    public final void c() {
        for (ModuleClientEntryPoint moduleClientEntryPoint : this.b) {
            try {
                moduleClientEntryPoint.onActivated();
            } catch (Throwable th) {
                a(moduleClientEntryPoint.getIdentifier(), "onActivated", th);
            }
        }
        CopyOnWriteArrayList copyOnWriteArrayList = this.d;
        CopyOnWriteArrayList copyOnWriteArrayList2 = this.b;
        ArrayList arrayList = new ArrayList();
        Iterator it = copyOnWriteArrayList2.iterator();
        while (it.hasNext()) {
            AdRevenueCollector adRevenueCollector = ((ModuleClientEntryPoint) it.next()).getAdRevenueCollector();
            if (adRevenueCollector != null) {
                arrayList.add(adRevenueCollector);
            }
        }
        ArrayList arrayList2 = new ArrayList();
        int size = arrayList.size();
        int i = 0;
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            if (((AdRevenueCollector) obj).getEnabled()) {
                arrayList2.add(obj);
            }
        }
        ArrayList arrayList3 = new ArrayList(CollectionsKt.collectionSizeOrDefault(arrayList2, 10));
        int size2 = arrayList2.size();
        while (i < size2) {
            Object obj2 = arrayList2.get(i);
            i++;
            arrayList3.add(((AdRevenueCollector) obj2).getSourceIdentifier());
        }
        copyOnWriteArrayList.addAll(CollectionsKt.distinct(arrayList3));
    }

    public final List<String> a() {
        return this.d;
    }

    public final void a(ModuleClientEntryPoint<Object> moduleClientEntryPoint) {
        this.b.add(moduleClientEntryPoint);
    }

    public final void a(X5 x5) {
        this.c = x5;
        HashSet hashSet = new HashSet();
        for (ModuleClientEntryPoint moduleClientEntryPoint : this.b) {
            try {
                moduleClientEntryPoint.initClientSide(x5);
            } catch (Throwable th) {
                a(moduleClientEntryPoint.getIdentifier(), "initClientSide", th);
                hashSet.add(moduleClientEntryPoint);
            }
        }
        if (hashSet.isEmpty()) {
            return;
        }
        this.b.removeAll(hashSet);
    }

    public final void a(Bundle bundle, SdkIdentifiers sdkIdentifiers) {
        if (bundle == null) {
            return;
        }
        for (ModuleClientEntryPoint moduleClientEntryPoint : this.b) {
            try {
                ServiceConfigExtensionConfiguration serviceConfigExtensionConfiguration = moduleClientEntryPoint.getServiceConfigExtensionConfiguration();
                if (serviceConfigExtensionConfiguration != null) {
                    ServiceConfigUpdateListener serviceConfigUpdateListener = serviceConfigExtensionConfiguration.getServiceConfigUpdateListener();
                    C0480o4 c0480o4 = this.a;
                    String identifier = moduleClientEntryPoint.getIdentifier();
                    c0480o4.getClass();
                    Bundle bundle2 = bundle.getBundle(identifier);
                    C0454n4 c0454n4 = bundle2 != null ? new C0454n4(sdkIdentifiers, serviceConfigExtensionConfiguration.getBundleConverter().fromBundle(bundle2)) : null;
                    if (c0454n4 != null) {
                        serviceConfigUpdateListener.onServiceConfigUpdated(c0454n4);
                    }
                }
            } catch (Throwable th) {
                a(moduleClientEntryPoint.getIdentifier(), "notifyModulesWithConfig", th);
            }
        }
    }
}
