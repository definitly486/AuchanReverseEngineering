package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0558r4 {
    public final Object a;
    public final C0611t5 b;
    public final HashMap c;
    public final Pa d;
    public final Context e;
    public final C0766z4 f;

    public C0558r4(Context context, C0611t5 c0611t5) {
        this(context, c0611t5, new C0766z4());
    }

    public final InterfaceC0688w4 a(C0273g4 c0273g4, G4 g4) {
        InterfaceC0688w4 interfaceC0688w4A;
        synchronized (this.a) {
            try {
                interfaceC0688w4A = (InterfaceC0688w4) this.c.get(c0273g4);
                if (interfaceC0688w4A == null) {
                    this.f.getClass();
                    interfaceC0688w4A = C0766z4.a(c0273g4).a(this.e, this.b, c0273g4, g4);
                    this.c.put(c0273g4, interfaceC0688w4A);
                    this.d.a(new C0533q4(c0273g4.b, c0273g4.c, c0273g4.d), c0273g4);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return interfaceC0688w4A;
    }

    public C0558r4(Context context, C0611t5 c0611t5, C0766z4 c0766z4) {
        this.a = new Object();
        this.c = new HashMap();
        this.d = new Pa();
        this.e = context.getApplicationContext();
        this.b = c0611t5;
        this.f = c0766z4;
    }

    public final void a(String str, Integer num, String str2) {
        synchronized (this.a) {
            try {
                Pa pa = this.d;
                Collection collection = (Collection) pa.a.remove(new C0533q4(str, num, str2));
                if (!Do.a(collection)) {
                    collection.size();
                    ArrayList arrayList = new ArrayList(collection.size());
                    Iterator it = collection.iterator();
                    while (it.hasNext()) {
                        arrayList.add((InterfaceC0688w4) this.c.remove((C0273g4) it.next()));
                    }
                    int size = arrayList.size();
                    int i = 0;
                    while (i < size) {
                        Object obj = arrayList.get(i);
                        i++;
                        ((InterfaceC0688w4) obj).a();
                    }
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
