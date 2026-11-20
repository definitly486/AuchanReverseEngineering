package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.pm.ServiceInfo;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.internal.AppMetricaService;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0586s6 extends Yg {
    public final Context f;
    public final Ih g;
    public final boolean h;
    public final J6 i;
    public final X1 j;
    public final E6 k;

    public /* synthetic */ C0586s6(Context context, C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl, Ih ih, boolean z, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(context, c0554r0, interfaceC0627tl, ih, (i & 16) != 0 ? false : z);
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final synchronized void a() {
        try {
            if (this.c) {
                return;
            }
            this.c = true;
            String strA = this.i.a.a();
            X1 x1 = this.j;
            Context context = this.f;
            x1.getClass();
            ServiceInfo serviceInfo = PackageManagerUtils.getServiceInfo(context, AppMetricaService.class);
            String str = serviceInfo != null ? serviceInfo.processName : null;
            if (this.h || !Intrinsics.areEqual(strA, str)) {
                this.a.c();
                this.c = false;
                super.a();
            } else {
                this.k.a(this.g);
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final boolean c() {
        this.k.a(this.g);
        return false;
    }

    @Override // io.appmetrica.analytics.impl.Kh, java.util.concurrent.Callable
    public final /* bridge */ /* synthetic */ Object call() {
        a();
        return Unit.INSTANCE;
    }

    public C0586s6(Context context, C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl, Ih ih, boolean z) {
        super(c0554r0, interfaceC0627tl, ih);
        this.f = context;
        this.g = ih;
        this.h = z;
        this.i = C0584s4.l().i();
        this.j = C0584s4.l().f();
        this.k = new E6(context);
    }
}
