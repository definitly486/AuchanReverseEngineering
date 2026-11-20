package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.nj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0469nj extends AbstractC0131ah {
    public C0469nj(C0455n5 c0455n5) {
        super(c0455n5);
        c0455n5.a().a();
    }

    /* JADX WARN: Code duplicated, block: B:11:0x0038  */
    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        Object objRemove;
        for (Map.Entry entry : c0249f6.p.entrySet()) {
            C0161bl c0161bl = this.a.u;
            String str = (String) entry.getKey();
            byte[] bArr = (byte[]) entry.getValue();
            if (bArr != null) {
                c0161bl.getClass();
                if (bArr.length == 0) {
                    objRemove = c0161bl.b.remove(str);
                } else {
                    objRemove = c0161bl.b.put(str, bArr);
                }
            } else {
                objRemove = c0161bl.b.remove(str);
            }
            C0264fl c0264fl = c0161bl.a;
            c0264fl.d.insert(c0264fl.a, c0264fl.c.toByteArray(c0264fl.b.fromModel(c0161bl.b)));
        }
        return true;
    }
}
