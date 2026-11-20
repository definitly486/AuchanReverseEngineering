package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.BuildConfig;
import java.util.ArrayList;
import java.util.Collection;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0602sm extends C0198d6 {
    public List d;
    public List e;
    public String f;
    public String g;
    public Map h;
    public I3 i;
    public List j;
    public boolean k;
    public boolean l;
    public String m;
    public long n;
    public final C0778zg o;
    public final Z7 p;

    public C0602sm() {
        this(Ka.k().u(), new Z7());
    }

    public final long a(long j) {
        if (this.n == 0) {
            this.n = j;
        }
        return this.n;
    }

    public final I3 c() {
        return this.i;
    }

    public final Map<String, String> d() {
        return this.h;
    }

    public final String e() {
        return this.m;
    }

    public final String f() {
        return this.f;
    }

    public final long g() {
        return this.n;
    }

    public final String h() {
        return this.g;
    }

    public final List<String> i() {
        return this.j;
    }

    public final C0778zg j() {
        return this.o;
    }

    /* JADX WARN: Code duplicated, block: B:27:0x0055  */
    /* JADX WARN: Code duplicated, block: B:29:0x005f  */
    /* JADX WARN: Code duplicated, block: B:34:0x006a  */
    /* JADX WARN: Code duplicated, block: B:36:0x006d  */
    /* JADX WARN: Code duplicated, block: B:45:0x0070 A[SYNTHETIC] */
    /* JADX WARN: Instruction removed from duplicated block: B:27:0x0055, please report this as an issue */
    public final List<String> k() {
        String[] strArr;
        ArrayList arrayList;
        LinkedHashSet linkedHashSet = new LinkedHashSet();
        if (!Do.a((Collection) this.d)) {
            linkedHashSet.addAll(this.d);
        }
        if (!Do.a((Collection) this.e)) {
            linkedHashSet.addAll(this.e);
        }
        String[] strArr2 = (String[]) this.p.a.a();
        if (strArr2 != null) {
            arrayList = new ArrayList();
            for (String str : strArr2) {
                if (str == null || StringsKt.isBlank(str)) {
                    str = null;
                }
                if (str != null) {
                    arrayList.add(str);
                }
            }
            if (arrayList.isEmpty()) {
                arrayList = null;
            }
            if (arrayList == null) {
                strArr = BuildConfig.DEFAULT_HOSTS;
                arrayList = new ArrayList();
                for (String str2 : strArr) {
                    if (str2 != null || StringsKt.isBlank(str2)) {
                        str2 = null;
                    }
                    if (str2 != null) {
                        arrayList.add(str2);
                    }
                }
            }
        } else {
            strArr = BuildConfig.DEFAULT_HOSTS;
            arrayList = new ArrayList();
            while (i < r5) {
                if (str2 != null) {
                    str2 = null;
                } else {
                    str2 = null;
                }
                if (str2 != null) {
                    arrayList.add(str2);
                }
            }
        }
        linkedHashSet.addAll(arrayList);
        return new ArrayList(linkedHashSet);
    }

    public final List<String> l() {
        return this.e;
    }

    public final List<String> m() {
        return this.d;
    }

    public final boolean n() {
        return this.k;
    }

    public final boolean o() {
        return this.l;
    }

    @Override // io.appmetrica.analytics.impl.C0198d6, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig
    public final String toString() {
        return "StartupRequestConfig{mStartupHostsFromStartup=" + this.d + ", mStartupHostsFromClient=" + this.e + ", mDistributionReferrer='" + this.f + "', mInstallReferrerSource='" + this.g + "', mClidsFromClient=" + this.h + ", mNewCustomHosts=" + this.j + ", mHasNewCustomHosts=" + this.k + ", mSuccessfulStartup=" + this.l + ", mCountryInit='" + this.m + "', mFirstStartupTime=" + this.n + "} " + super.toString();
    }

    public C0602sm(C0778zg c0778zg, Z7 z7) {
        this.i = new I3(null, EnumC0406l8.d);
        this.n = 0L;
        this.o = c0778zg;
        this.p = z7;
    }

    public final void a(List<String> list) {
        this.j = list;
    }

    public final void a(boolean z) {
        this.k = z;
    }

    public final void a(String str) {
        this.m = str;
    }
}
