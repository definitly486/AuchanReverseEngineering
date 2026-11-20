package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreutils.internal.toggle.ConjunctiveCompositeThreadSafeToggle;
import io.appmetrica.analytics.coreutils.internal.toggle.OuterStateToggle;
import io.appmetrica.analytics.coreutils.internal.toggle.SavableToggle;
import io.appmetrica.analytics.coreutils.internal.toggle.SimpleThreadSafeToggle;

/* JADX INFO: loaded from: classes3.dex */
public final class O {
    public final C0621tf a = Ka.k().y();
    public final SavableToggle b;
    public final OuterStateToggle c;
    public final OuterStateToggle d;
    public final ConjunctiveCompositeThreadSafeToggle e;
    public final ConjunctiveCompositeThreadSafeToggle f;
    public final SavableToggle g;

    public O(C0706wm c0706wm) {
        SavableToggle savableToggle = new SavableToggle("advIdsFromClientApi", new N(this));
        this.b = savableToggle;
        OuterStateToggle outerStateToggle = new OuterStateToggle(false, "GAID-remote-config");
        this.c = outerStateToggle;
        OuterStateToggle outerStateToggle2 = new OuterStateToggle(false, "HOAID-remote-config");
        this.d = outerStateToggle2;
        this.e = new ConjunctiveCompositeThreadSafeToggle(CollectionsKt.listOf((Object[]) new SimpleThreadSafeToggle[]{savableToggle, outerStateToggle}), "GAID");
        this.f = new ConjunctiveCompositeThreadSafeToggle(CollectionsKt.listOf((Object[]) new SimpleThreadSafeToggle[]{savableToggle, outerStateToggle2}), "HOAID");
        this.g = savableToggle;
        a(c0706wm);
    }

    public final void a(C0706wm c0706wm) {
        boolean z = c0706wm.p;
        boolean z2 = true;
        this.c.update(!z || c0706wm.n.c);
        OuterStateToggle outerStateToggle = this.d;
        if (z && !c0706wm.n.e) {
            z2 = false;
        }
        outerStateToggle.update(z2);
    }

    public final L a() {
        M m;
        M m2;
        M m3;
        if (this.e.getActualState()) {
            m = M.ALLOWED;
        } else if (this.b.getActualState()) {
            m = !this.c.getActualState() ? M.FORBIDDEN_BY_REMOTE_CONFIG : M.UNKNOWN;
        } else {
            m = M.FORBIDDEN_BY_CLIENT_CONFIG;
        }
        if (this.f.getActualState()) {
            m2 = M.ALLOWED;
        } else if (this.b.getActualState()) {
            m2 = !this.d.getActualState() ? M.FORBIDDEN_BY_REMOTE_CONFIG : M.UNKNOWN;
        } else {
            m2 = M.FORBIDDEN_BY_CLIENT_CONFIG;
        }
        if (this.g.getActualState()) {
            m3 = M.ALLOWED;
        } else {
            m3 = !this.b.getActualState() ? M.FORBIDDEN_BY_CLIENT_CONFIG : M.UNKNOWN;
        }
        return new L(m, m2, m3);
    }
}
