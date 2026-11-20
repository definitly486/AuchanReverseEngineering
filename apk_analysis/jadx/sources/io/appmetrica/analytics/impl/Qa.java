package io.appmetrica.analytics.impl;

import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class Qa extends P2 {
    public final Ta b;

    public Qa(int i) {
        this(i, null);
    }

    public int b(Object obj) {
        return 0;
    }

    public Qa(int i, Ta ta) {
        super(i);
        this.b = ta;
    }

    @Override // io.appmetrica.analytics.impl.P2, io.appmetrica.analytics.impl.Ta
    public final C0241eo a(List<Object> list) {
        int iB;
        int i = 0;
        if (list == null || (list.size() <= this.a && this.b == null)) {
            iB = 0;
        } else {
            ArrayList arrayList = new ArrayList();
            iB = 0;
            int i2 = 0;
            for (Object obj : list) {
                if (i2 < this.a) {
                    Ta ta = this.b;
                    if (ta != null) {
                        C0241eo c0241eoA = ta.a(obj);
                        Object obj2 = c0241eoA.a;
                        iB += c0241eoA.b.getBytesTruncated();
                        Do.a(obj, c0241eoA.a);
                        obj = obj2;
                    }
                    arrayList.add(obj);
                } else {
                    i++;
                    iB += b(obj);
                }
                i2++;
            }
            list = arrayList;
        }
        return new C0241eo(list, new E4(i, iB));
    }

    public final Ta b() {
        return this.b;
    }
}
