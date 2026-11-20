package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.HashMap;

/* JADX INFO: loaded from: classes3.dex */
public final class Yl {
    public final Pa a = new Pa();
    public final HashMap b = new HashMap();
    public C0706wm c = null;
    public final Wl d = new Wl(this);

    public static final Yl a() {
        return Xl.a;
    }

    public final Rm a(Context context, C0274g5 c0274g5, C0551qm c0551qm) {
        Rm rm = (Rm) this.b.get(c0274g5.a);
        boolean z = true;
        if (rm == null) {
            synchronized (this.b) {
                try {
                    rm = (Rm) this.b.get(c0274g5.a);
                    if (rm == null) {
                        rm = new Rm(new Sm(context, c0274g5.a, c0551qm, this.d));
                        rm.f();
                        this.b.put(c0274g5.a, rm);
                        z = false;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        if (z) {
            rm.a(c0551qm);
        }
        return rm;
    }

    public final void a(C0274g5 c0274g5, InterfaceC0317hm interfaceC0317hm) {
        synchronized (this.b) {
            try {
                this.a.a(c0274g5.a, interfaceC0317hm);
                C0706wm c0706wm = this.c;
                if (c0706wm != null) {
                    interfaceC0317hm.a(c0706wm);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
