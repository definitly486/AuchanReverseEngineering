package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.oh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0493oh extends AbstractC0131ah {
    public final Re b;
    public final ProtobufStateStorage c;
    public final L2 d;
    public final C0504p2 e;
    public final E2 f;

    public C0493oh(C0455n5 c0455n5, Re re) {
        this(c0455n5, re, ((AbstractC0343in) C0292gn.a(C0271g2.class)).create(c0455n5.getContext()), new L2(c0455n5.getContext()), new C0504p2(), new E2(c0455n5.getContext()));
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0455n5 c0455n5 = this.a;
        c0455n5.b.toString();
        if (!c0455n5.t.c() || !c0455n5.x()) {
            return false;
        }
        C0271g2 c0271g2 = (C0271g2) this.c.read();
        List list = c0271g2.a;
        K2 k2 = c0271g2.b;
        L2 l2 = this.d;
        l2.getClass();
        C0271g2 c0271g3 = null;
        K2 k2A = AndroidUtils.isApiAchieved(28) ? H2.a(l2.a, l2.b) : null;
        List list2 = c0271g2.c;
        List list3 = (List) SystemServiceUtils.accessSystemServiceSafelyOrDefault(this.f.a, "getting available providers", "location manager", Collections.EMPTY_LIST, new D2());
        Re re = this.b;
        Context context = this.a.a;
        re.getClass();
        ArrayList arrayListA = new C0211dj(context, new SafePackageManager()).a();
        if (CollectionUtils.areCollectionsEqual(arrayListA, list)) {
            arrayListA = null;
        }
        if (arrayListA != null || !Do.a(k2, k2A) || !CollectionUtils.areCollectionsEqual(list2, list3)) {
            if (arrayListA != null) {
                list = arrayListA;
            }
            c0271g3 = new C0271g2(list, k2A, list3);
        }
        if (c0271g3 != null) {
            E9 e9 = c0455n5.n;
            C0249f6 c0249f6A = C0249f6.a(c0249f6, c0271g3.a, c0271g3.b, this.e, c0271g3.c);
            e9.a(c0249f6A, C0393kl.a(e9.c.b(c0249f6A), c0249f6A.i));
            long jCurrentTimeSeconds = e9.i.currentTimeSeconds();
            e9.k = jCurrentTimeSeconds;
            e9.a.a(jCurrentTimeSeconds);
            this.c.save(c0271g3);
            return false;
        }
        if (!c0455n5.A()) {
            return false;
        }
        E9 e10 = c0455n5.n;
        C0249f6 c0249f6A2 = C0249f6.a(c0249f6, c0271g2.a, c0271g2.b, this.e, c0271g2.c);
        e10.a(c0249f6A2, C0393kl.a(e10.c.b(c0249f6A2), c0249f6A2.i));
        long jCurrentTimeSeconds2 = e10.i.currentTimeSeconds();
        e10.k = jCurrentTimeSeconds2;
        e10.a.a(jCurrentTimeSeconds2);
        return false;
    }

    public C0493oh(C0455n5 c0455n5, Re re, ProtobufStateStorage protobufStateStorage, L2 l2, C0504p2 c0504p2, E2 e2) {
        super(c0455n5);
        this.b = re;
        this.c = protobufStateStorage;
        this.d = l2;
        this.e = c0504p2;
        this.f = e2;
    }
}
