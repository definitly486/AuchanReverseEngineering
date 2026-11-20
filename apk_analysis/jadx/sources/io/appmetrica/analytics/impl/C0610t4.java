package io.appmetrica.analytics.impl;

import android.content.Context;
import java.io.File;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.t4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0610t4 {
    public final C0561r7 a;
    public Ob b;
    public Pb c;
    public C0670vc d;

    public C0610t4(File file) {
        this.a = new C0561r7(file);
    }

    public final synchronized InterfaceC0280gb a(Context context) {
        Pb pb;
        pb = this.c;
        if (pb == null) {
            pb = new Pb(c(context));
            this.c = pb;
        }
        return pb;
    }

    public final synchronized InterfaceC0280gb b(Context context) {
        return c(context);
    }

    public final InterfaceC0280gb c(Context context) {
        C0670vc c0670vc;
        Ob ob = this.b;
        if (ob != null) {
            return ob;
        }
        synchronized (this) {
            c0670vc = this.d;
            if (c0670vc == null) {
                C0561r7 c0561r7 = this.a;
                String strA = new C0536q7(c0561r7.a, c0561r7.b, true).a(context, new C0221e4());
                C0199d7 c0199d7 = M5.c;
                c0199d7.getClass();
                HashMap map = new HashMap();
                map.put("preferences", J5.a);
                C0733xn c0733xn = c0199d7.c;
                C0457n7 c0457n7 = c0199d7.a;
                C0353j7 c0353j7 = c0457n7.c;
                C0379k7 c0379k7 = c0457n7.d;
                Pa pa = new Pa(false);
                pa.a(112, new C0247f4());
                An an = new An("service database", map);
                c0733xn.getClass();
                c0670vc = new C0670vc(context, strA, new C0642ua(strA), new C0759yn(c0353j7, c0379k7, pa, an));
                this.d = c0670vc;
            }
        }
        Ob ob2 = new Ob("preferences", c0670vc, C0584s4.l().c.b());
        this.b = ob2;
        return ob2;
    }
}
