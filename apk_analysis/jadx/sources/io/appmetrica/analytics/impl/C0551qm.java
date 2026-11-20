package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0551qm extends BaseRequestConfig.BaseRequestArguments {
    public final String a;
    public final String b;
    public final Map<String, String> c;
    public final boolean d;
    public final List<String> e;

    public C0551qm(Y3 y3) {
        this(y3.a().c(), y3.a().d(), y3.a().a(), y3.a().h(), y3.a().b());
    }

    public final boolean a(C0551qm c0551qm) {
        return false;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.ArgumentsMerger
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final C0551qm mergeFrom(C0551qm c0551qm) {
        return new C0551qm((String) WrapUtils.getOrDefaultNullable(this.a, c0551qm.a), (String) WrapUtils.getOrDefaultNullable(this.b, c0551qm.b), (Map) WrapUtils.getOrDefaultNullable(this.c, c0551qm.c), this.d || c0551qm.d, c0551qm.d ? c0551qm.e : this.e);
    }

    @Override // io.appmetrica.analytics.networktasks.internal.ArgumentsMerger
    public final boolean compareWithOtherArguments(Object obj) {
        return false;
    }

    public final String toString() {
        return "Arguments{distributionReferrer='" + this.a + "', installReferrerSource='" + this.b + "', clientClids=" + this.c + ", hasNewCustomHosts=" + this.d + ", newCustomHosts=" + this.e + '}';
    }

    public C0551qm(String str, String str2, Map<String, String> map, boolean z, List<String> list) {
        this.a = str;
        this.b = str2;
        this.c = map;
        this.d = z;
        this.e = list;
    }

    public C0551qm() {
        this(null, null, null, false, null);
    }
}
