package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.model.ScreenInfo;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import java.lang.ref.WeakReference;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0573rj implements InterfaceC0397l {
    public C0517pf a;
    public ScreenInfo b;
    public boolean c;
    public boolean d;
    public final C0548qj e = new C0548qj();
    public WeakReference f = new WeakReference(null);

    public final synchronized void a(Activity activity) {
        try {
            this.f = new WeakReference(activity);
            if (!this.d) {
                if (this.a == null) {
                    this.a = C0584s4.l().b(activity);
                }
                C0517pf c0517pf = this.a;
                Intrinsics.checkNotNull(c0517pf);
                this.b = c0517pf.p();
                if (this.a == null) {
                    this.a = C0584s4.l().b(activity);
                }
                C0517pf c0517pf2 = this.a;
                Intrinsics.checkNotNull(c0517pf2);
                this.c = c0517pf2.t();
                this.d = true;
            }
            if (this.b == null) {
                b(activity);
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void b(Context context) {
        if (context != null) {
            this.e.getClass();
            ScreenInfo screenInfoA = C0548qj.a(context);
            if (screenInfoA == null || Intrinsics.areEqual(screenInfoA, this.b)) {
                return;
            }
            this.b = screenInfoA;
            if (this.a == null) {
                this.a = C0584s4.l().b(context);
            }
            C0517pf c0517pf = this.a;
            Intrinsics.checkNotNull(c0517pf);
            c0517pf.a(this.b);
        }
    }

    public final synchronized ScreenInfo a(Context context) {
        try {
            if (!this.d) {
                if (this.a == null) {
                    this.a = C0584s4.l().b(context);
                }
                C0517pf c0517pf = this.a;
                Intrinsics.checkNotNull(c0517pf);
                this.b = c0517pf.p();
                if (this.a == null) {
                    this.a = C0584s4.l().b(context);
                }
                C0517pf c0517pf2 = this.a;
                Intrinsics.checkNotNull(c0517pf2);
                this.c = c0517pf2.t();
                this.d = true;
            }
            b((Context) this.f.get());
            if (this.b == null) {
                if (AndroidUtils.isApiAchieved(30)) {
                    if (!this.c) {
                        b(context);
                        this.c = true;
                        if (this.a == null) {
                            this.a = C0584s4.l().b(context);
                        }
                        C0517pf c0517pf3 = this.a;
                        Intrinsics.checkNotNull(c0517pf3);
                        c0517pf3.v();
                    }
                } else {
                    b(context);
                }
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.b;
    }

    public final void a(C0517pf c0517pf) {
        this.a = c0517pf;
    }
}
