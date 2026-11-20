package io.appmetrica.analytics.impl;

import android.content.Context;
import com.google.common.net.HttpHeaders;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.networktasks.internal.NetworkTask;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Rm {
    public final Sm a;
    public final Object b = new Object();
    public volatile NetworkTask c;

    public Rm(Sm sm) {
        this.a = sm;
    }

    public final Context b() {
        return this.a.a;
    }

    public final NetworkTask c() {
        NetworkTask networkTaskA;
        synchronized (this.b) {
            try {
                if (g()) {
                    networkTaskA = this.c;
                    if (networkTaskA == null || networkTaskA.isRemoved()) {
                        networkTaskA = C0543qe.a(this, d());
                        this.c = networkTaskA;
                    }
                } else {
                    networkTaskA = null;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return networkTaskA;
    }

    public final C0602sm d() {
        return (C0602sm) this.a.l.a();
    }

    public final C0706wm e() {
        C0706wm c0706wm;
        Zl zl = this.a.l;
        synchronized (zl) {
            c0706wm = zl.c.a;
        }
        return c0706wm;
    }

    public final void f() {
        C0706wm c0706wm;
        Zl zl = this.a.l;
        synchronized (zl) {
            c0706wm = zl.c.a;
        }
        Am am = c0706wm.c;
        C0784zm c0784zmA = am.a(am.m);
        String strA = c0706wm.a;
        String str = c0706wm.b;
        String str2 = this.a.m.a().id;
        if (str2 == null || (StringUtils.isNotNullOrEmpty(c0706wm.d) && !Intrinsics.areEqual(str2, c0706wm.d))) {
            String str3 = c0706wm.d;
            C0263fk c0263fk = Dj.a;
            c0263fk.reportError((str2 == null ? "null_uuid" : "wrong_uuid").concat("_on_service"), "The only true uuid: " + str2 + "; backup uuid: " + str3);
        }
        if (str2 == null) {
            str2 = c0706wm.d;
        }
        c0784zmA.a = str2;
        String str4 = c0706wm.a;
        if (str4 == null || str4.length() == 0) {
            strA = this.a.h.a();
            str = "";
        }
        List<String> list = this.a.c.e;
        if (list == null || list.isEmpty()) {
            list = null;
        }
        c0784zmA.g = list;
        C0706wm c0706wm2 = new C0706wm(strA, str, new Am(c0784zmA));
        b(c0706wm2);
        a(c0706wm2);
    }

    /* JADX WARN: Code duplicated, block: B:11:0x002e  */
    public final boolean g() {
        boolean z;
        boolean z2 = false;
        if (Ka.I.h().isRestrictedForSdk()) {
            return false;
        }
        C0706wm c0706wmE = e();
        Set set = AbstractC0628tm.a;
        if (c0706wmE.w) {
            z = true;
        } else {
            if (AbstractC0628tm.b.currentTimeSeconds() > c0706wmE.o + ((long) c0706wmE.z.a)) {
                z = true;
            } else {
                z = false;
            }
        }
        if (!z) {
            if (AbstractC0628tm.a(c0706wmE.d) && AbstractC0628tm.a(c0706wmE.a) && AbstractC0628tm.a(c0706wmE.b)) {
                z2 = true;
            }
            z = !z2;
            T3 t3 = this.a.k;
            Map map = d().h;
            Q3 q3 = this.a.j;
            t3.getClass();
            boolean zA = T3.a(map, c0706wmE, q3);
            if (z2 && !zA) {
                return true;
            }
        }
        return z;
    }

    public final C0274g5 a() {
        return this.a.f;
    }

    public final void b(C0706wm c0706wm) {
        this.a.l.a(c0706wm);
        C0680vm c0680vm = this.a.g;
        c0680vm.b.a(c0706wm.a);
        c0680vm.b.b(c0706wm.b);
        Qo qo = c0680vm.b.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
        c0680vm.a.save(c0706wm.c);
        this.a.e.a(c0706wm);
    }

    public final boolean a(List<String> list, Map<String, String> map) {
        return !AbstractC0628tm.a(e(), list, map, new Qm(this));
    }

    /* JADX WARN: Code duplicated, block: B:15:0x003c  */
    public final C0706wm a(C0654um c0654um, C0602sm c0602sm, long j) {
        String str;
        boolean zEquals;
        String strA = Wm.a(c0602sm.h);
        Map map = c0602sm.i.a;
        String str2 = c0654um.j;
        String str3 = e().k;
        if (!Wm.a(Wm.a(str2))) {
            str2 = Wm.a(Wm.a(str3)) ? str3 : null;
        }
        String str4 = e().a;
        if (str4 != null) {
            str = StringsKt.isBlank(str4) ? null : str4;
            if (str == null) {
                str = c0654um.h;
            }
        } else {
            str = c0654um.h;
        }
        C0784zm c0784zm = new C0784zm(c0654um.b);
        String str5 = c0654um.i;
        c0784zm.o = this.a.i.currentTimeSeconds();
        c0784zm.a = e().d;
        c0784zm.c = c0654um.d;
        c0784zm.f = c0654um.c;
        c0784zm.g = c0602sm.e;
        c0784zm.b = c0654um.e;
        c0784zm.d = c0654um.f;
        c0784zm.e = c0654um.g;
        c0784zm.h = c0654um.n;
        c0784zm.i = c0654um.o;
        c0784zm.j = str2;
        c0784zm.k = strA;
        this.a.k.getClass();
        HashMap mapA = Wm.a(str2);
        if (Do.a(map)) {
            zEquals = Do.a((Map) mapA);
        } else {
            zEquals = mapA.equals(map);
        }
        c0784zm.q = zEquals;
        c0784zm.l = Wm.a(map);
        c0784zm.r = c0654um.m;
        c0784zm.n = c0654um.k;
        c0784zm.s = c0654um.p;
        c0784zm.p = true;
        c0784zm.t = j;
        C0602sm c0602smD = d();
        if (c0602smD.n == 0) {
            c0602smD.n = j;
        }
        c0784zm.u = c0602smD.n;
        c0784zm.v = false;
        c0784zm.w = c0654um.q;
        c0784zm.x = c0654um.r;
        c0784zm.y = c0654um.s;
        c0784zm.z = c0654um.t;
        c0784zm.A = c0654um.u;
        c0784zm.B = c0654um.v;
        return new C0706wm(str, str5, new Am(c0784zm));
    }

    public final void a(C0706wm c0706wm) {
        ArrayList arrayList;
        Sm sm = this.a;
        Wl wl = sm.d;
        String str = sm.b;
        synchronized (wl.a.b) {
            try {
                Yl yl = wl.a;
                yl.c = c0706wm;
                Collection collection = (Collection) yl.a.a.get(str);
                if (collection == null) {
                    arrayList = new ArrayList();
                } else {
                    arrayList = new ArrayList(collection);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((InterfaceC0317hm) obj).a(c0706wm);
        }
    }

    public final void a(EnumC0136am enumC0136am) {
        ArrayList arrayList;
        this.c = null;
        Sm sm = this.a;
        Wl wl = sm.d;
        String str = sm.f.a;
        C0706wm c0706wmE = e();
        synchronized (wl.a.b) {
            try {
                Collection collection = (Collection) wl.a.a.a.get(str);
                if (collection == null) {
                    arrayList = new ArrayList();
                } else {
                    arrayList = new ArrayList(collection);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((InterfaceC0317hm) obj).a(enumC0136am, c0706wmE);
        }
    }

    public final void a(C0551qm c0551qm) {
        this.a.l.a(c0551qm);
        C0602sm c0602smD = d();
        if (c0602smD.k) {
            List list = c0602smD.j;
            if (list != null && !list.isEmpty()) {
                if (Do.a(list, c0602smD.e)) {
                    return;
                }
                C0706wm c0706wmE = e();
                Am am = c0706wmE.c;
                C0784zm c0784zmA = am.a(am.m);
                String str = c0706wmE.a;
                String str2 = c0706wmE.b;
                c0784zmA.g = list;
                C0706wm c0706wm = new C0706wm(str, str2, new Am(c0784zmA));
                b(c0706wm);
                a(c0706wm);
                return;
            }
            List list2 = c0602smD.e;
            if (list2 == null || !(!list2.isEmpty())) {
                return;
            }
            C0706wm c0706wmE2 = e();
            Am am2 = c0706wmE2.c;
            C0784zm c0784zmA2 = am2.a(am2.m);
            String str3 = c0706wmE2.a;
            String str4 = c0706wmE2.b;
            c0784zmA2.g = null;
            C0706wm c0706wm2 = new C0706wm(str3, str4, new Am(c0784zmA2));
            b(c0706wm2);
            a(c0706wm2);
        }
    }

    /* JADX WARN: Code duplicated, block: B:9:0x0032  */
    public final void a(C0654um c0654um, C0602sm c0602sm, Map<String, ? extends List<String>> map) {
        Long lValueOf;
        if (Do.a((Map) map)) {
            lValueOf = null;
        } else {
            List list = (List) CollectionUtils.getFromMapIgnoreCase(map, HttpHeaders.DATE);
            if (Do.a((Collection) list)) {
                lValueOf = null;
            } else {
                try {
                    lValueOf = Long.valueOf(new SimpleDateFormat("E, d MMM yyyy HH:mm:ss z", Locale.US).parse((String) list.get(0)).getTime());
                } catch (Throwable unused) {
                    lValueOf = null;
                }
            }
        }
        long jLongValue = lValueOf != null ? lValueOf.longValue() : 0L;
        AbstractC0470nk.a.a(jLongValue, c0654um.l);
        C0706wm c0706wmA = a(c0654um, c0602sm, jLongValue);
        this.c = null;
        b(c0706wmA);
        a(c0706wmA);
    }
}
