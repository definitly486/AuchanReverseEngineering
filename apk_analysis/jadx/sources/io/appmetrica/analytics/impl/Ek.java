package io.appmetrica.analytics.impl;

import android.util.SparseArray;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Ek extends AbstractC0230ed {
    public final Oo a;

    public Ek() {
        this(Ka.k().D().b());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final void a(int i) {
        Oo oo = this.a;
        synchronized (oo) {
            JSONObject jSONObjectA = oo.a.a();
            if (jSONObjectA.optInt("last_migration_api_level", -1) != i) {
                oo.a.a(jSONObjectA.put("last_migration_api_level", i));
            }
            Qo qo = oo.a;
            Qo.a(qo.a);
            Qo.a(qo.b);
        }
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final int b() {
        int iOptInt;
        Oo oo = this.a;
        synchronized (oo) {
            iOptInt = oo.a.a().optInt("last_migration_api_level", -1);
        }
        return iOptInt;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final SparseArray<InterfaceC0205dd> c() {
        SparseArray<InterfaceC0205dd> sparseArray = new SparseArray<>(1);
        sparseArray.put(112, new Fk(this.a));
        sparseArray.put(115, new Gk());
        sparseArray.put(116, new Jk());
        return sparseArray;
    }

    public Ek(Oo oo) {
        this.a = oo;
    }
}
